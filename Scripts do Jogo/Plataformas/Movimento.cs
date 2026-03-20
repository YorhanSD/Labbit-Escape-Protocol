using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public abstract class Movimento : MonoBehaviour
{
    public float velocidade = 8f;
    public float posicaoInicial;
    public float posicaoFinal;
    public float rangeMinimo;
    public float rangeMaximo;
    [SerializeField] private bool podeAndar;
    public bool moveDireita;
    public bool moveParaBaixo;

    public Vector3 distanciaPlayer;
    public Transform posicaoPlayer;
    public Animator anim;
    public Rigidbody2D rigid2D;
    public SpriteRenderer sr;
    public AudioSource audioSource;
    public AudioClip somMovimento;

    protected virtual void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }
    public virtual void SetPodeAndar(bool _podeAndar)
    {
        podeAndar = _podeAndar;
    }

    public virtual bool GetPodeAndar()
    {
        return podeAndar;
    }

    public virtual void SomMovimento()
    {
        if (audioSource != null)
        {
            audioSource.clip = somMovimento;
            audioSource.Play();
        }
    }

    public virtual bool MovimentoHorizontalPlataforma()
    {
        if (transform.position.x >= posicaoFinal)
        {
            moveDireita = false;
        }
        else if (transform.position.x <= posicaoInicial)
        {
            moveDireita = true;
        }

        if (moveDireita)
        {
            transform.position = new Vector2(
                transform.position.x + velocidade * Time.deltaTime,
                transform.position.y
            );
        }
        else
        {
            transform.position = new Vector2(
                transform.position.x - velocidade * Time.deltaTime,
                transform.position.y
            );
        }

        return false;
    }
    public virtual bool MovimentoHorizontalInimigo()
    {
        /*
        if (gameObject.tag == "Plataforma")
        {
            Vector2 novaPosicao = rigid2D.position;

            if (rigid2D.position.x > posicaoInicial)
                moveDireita = false;
            else if (rigid2D.position.x < posicaoFinal)
                moveDireita = true;

            if (moveDireita)
                novaPosicao.x -= velocidade * Time.fixedDeltaTime;
            else
                novaPosicao.x += velocidade * Time.fixedDeltaTime;

            rigid2D.MovePosition(novaPosicao);

            /*
            if (posicaoInicial < gameObject.transform.position.x)
            {
                moveDireita = false;
            }
            else if (posicaoFinal > gameObject.transform.position.x)
            {
                moveDireita = true;
            }

            if (moveDireita)
            {
                gameObject.transform.position = new Vector2(transform.position.x + velocidade * Time.deltaTime, transform.position.y);
            }

            gameObject.transform.position = new Vector2(transform.position.x - velocidade * Time.deltaTime, transform.position.y);
        }
            */


        if (!GetPodeAndar())
            return false;

        if (transform.position.x > posicaoInicial)
        {
            moveDireita = false;
            Flip();
        }
        else if (transform.position.x < posicaoFinal)
        {
            moveDireita = true;
            Flip();
        }

        float direcao = moveDireita ? 1f : -1f;

        rigid2D.linearVelocity = new Vector2(
            direcao * velocidade,
            rigid2D.linearVelocity.y
        );

        return false;
    }

    public void Flip()
    {
        if (sr != null)
        {
            sr.flipX = moveDireita;
        }
    }

    public virtual bool MovimentoVertical()
    {
        /*
        if (transform.position.y > posicaoInicial)
        {
            moveParaBaixo = true;
        }
        else if (transform.position.y < posicaoFinal)
        {
            moveParaBaixo = false;
        }

        if (moveParaBaixo)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - velocidade * Time.deltaTime);

            return false;
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + velocidade * Time.deltaTime);
        }

        return false;
        */

        Vector2 novaPosicao = rigid2D.position;

        if (rigid2D.position.y > posicaoInicial)
            moveParaBaixo = true;
        else if (rigid2D.position.y < posicaoFinal)
            moveParaBaixo = false;

        if (moveParaBaixo)
            novaPosicao.y -= velocidade * Time.fixedDeltaTime;
        else
            novaPosicao.y += velocidade * Time.fixedDeltaTime;

        rigid2D.MovePosition(novaPosicao);

        return false;

        //Plataforma deve estar com as seguintes Configurações no RigidBody

        //Kinematic
        //Collision Detection: Continous
        //Interpolate: Interpolate
    }

    public void SeguirPlayer()
    {
        if (!GetPodeAndar())
        {
            anim.SetFloat("velocidade", 0);
            rigid2D.linearVelocity = Vector2.zero;
            return;
        }

        anim.SetFloat("velocidade", Mathf.Abs(rigid2D.linearVelocity.x));

        distanciaPlayer = posicaoPlayer.transform.position - transform.position;

        if (Mathf.Abs(distanciaPlayer.x) < rangeMaximo && Mathf.Abs(distanciaPlayer.x) > rangeMinimo)
        {
            //inimigo se move em direcao ao player
            rigid2D.linearVelocity = new Vector2(velocidade * (distanciaPlayer.x / Mathf.Abs(distanciaPlayer.x)), rigid2D.linearVelocity.y);

        }
        else
        {
            anim.SetFloat("velocidade", 0);
            //rigid2D.linearVelocity = new Vector2(0, rigid2D.linearVelocity.y);
            rigid2D.linearVelocity = Vector2.zero; //Zera a velocidade do personagem por completo
        }

        if (rigid2D.linearVelocity.x < 0 && sr.flipX == true)//Se a velocidade do inimigo for maior que zero entao:
        {
            Flip();
        }
        else if (rigid2D.linearVelocity.x > 0 && sr.flipX == false)//Se a velocidade do inimigo for menor que zero entao:
        {
            Flip();
        }

    }
}
