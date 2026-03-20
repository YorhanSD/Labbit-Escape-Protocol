using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aldos_IA : MonoBehaviour
{
    [SerializeField] private Seringa Seringa;

    public Rigidbody2D rigid2D;
    public SpriteRenderer sprite;
    public Animator anim;
    public LayerMask playerLayer;
    private Vector3 distanciaDoPlayer;
    public AudioSource aS;
    public AudioClip roleta;
    public AudioClip metalImpacto;
    public AudioClip risada;
    public AudioClip somTiro;
    public GameObject seringa;
    public GameObject serra;
    public Transform posicaoPlayer;
    public Transform pontoDisparo;
    public Transform areaAtaque;
    public Transform areaDano;
    public string animacaoIdle;
    public string animacaoAtaque;
    public string animacaoSegundoAtaque;
    public string animacaoAtirar;
    public string animacaoSegundoAtirar;
    public float raioArea;
    public float velocidade;
    public float rangeMaximo = 20;
    public float rangeMinimo = 5;
    public float pocicaoAreaDano_X;
    public float pocicaoAreaDano_Y;
    public float pocicaoAreaAtaque_X;
    public float pocicaoAreaAtaque_Y;
    public bool disparouSerra;
    public bool podeAtacar = true;
    public bool ladoDireito;
    public bool isPlayer;
    public int numeroAleatorio;

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    public void FixedUpdate()
    {
        SeguirPlayer();
    }
    void Update()
    {
        ControlePosicao();

        isPlayer = Physics2D.OverlapCircle(areaAtaque.position, raioArea, playerLayer); //Cria o Range de Ataque

        if (podeAtacar == true && isPlayer == true)
        {
            podeAtacar = false;
           
            StartCoroutine(Parado());
        }

    }
    public void SeguirPlayer()
    {
        anim.SetFloat("velocidade", Mathf.Abs(rigid2D.linearVelocity.x));

        distanciaDoPlayer = posicaoPlayer.transform.position - transform.position;

        if (podeAtacar == true && Mathf.Abs(distanciaDoPlayer.x) < rangeMaximo && Mathf.Abs(distanciaDoPlayer.x) > rangeMinimo)
        {
            //inimigo se move em direcao ao player
            rigid2D.linearVelocity = new Vector2(velocidade * (distanciaDoPlayer.x / Mathf.Abs(distanciaDoPlayer.x)), rigid2D.linearVelocity.y);
        }
        else
        {
            //rigid2D.linearVelocity = new Vector2(0, rigid2D.linearVelocity.y);

            rigid2D.linearVelocity = Vector2.zero; //Zera a velocidade do personagem por completo
        }


        if (rigid2D.linearVelocity.x < 0 && sprite.flipX == true)//Se a velocidade do inimigo for maior que zero entao:
        {
            Flip();
        }
        else if (rigid2D.linearVelocity.x > 0 && sprite.flipX == false)//Se a velocidade do inimigo for menor que zero entao:
        {
            Flip();
        }
    }

    void Flip()
    {
        sprite.flipX =! sprite.flipX;
        ladoDireito =! ladoDireito;
    }
    void FlipSurpresa()
    {
        if (gameObject.transform.position.x < posicaoPlayer.transform.position.x)
        {
            ladoDireito = true;
            sprite.flipX = true;
        }
        else
        {
            ladoDireito = false;
            sprite.flipX = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(areaAtaque.position, raioArea);
    }

    private bool ControlePosicao()
    {
        if (podeAtacar == true && posicaoPlayer.position.x > transform.position.x)
        {
            areaAtaque.localPosition = new Vector2(pocicaoAreaAtaque_X, pocicaoAreaAtaque_Y);

            areaDano.localPosition = new Vector2(pocicaoAreaDano_X, pocicaoAreaDano_Y);

            ladoDireito = true;
        }

        if (podeAtacar == true && posicaoPlayer.position.x < transform.position.x)
        {
            areaAtaque.localPosition = new Vector2(-pocicaoAreaAtaque_X, pocicaoAreaAtaque_Y);

            areaDano.localPosition = new Vector2(-pocicaoAreaDano_X, pocicaoAreaDano_Y);

            ladoDireito = false;
        }

        return false;
    }

    public IEnumerator Parado()
    {
        aS.clip = roleta;
        aS.Play();

        anim.SetTrigger(animacaoIdle);

        yield return new WaitForSecondsRealtime(1.5f);

        probabilidadeAtaqueBasico();
    }
    public IEnumerator AtaqueBasico()
    {
        anim.SetTrigger(animacaoAtaque);

        yield return new WaitForSecondsRealtime(1);

        podeAtacar = true;
    }
    public IEnumerator AtaqueBasico_Plus()
    {
        anim.SetTrigger(animacaoSegundoAtaque);

        yield return new WaitForSecondsRealtime(2);

        podeAtacar = true;
    }
    public IEnumerator Atirar()
    {
        anim.SetTrigger(animacaoAtirar);

        yield return new WaitForSecondsRealtime(1);

        podeAtacar = true;
    }
    public IEnumerator Atirar_Plus()
    {
        anim.SetTrigger(animacaoSegundoAtirar);

        yield return new WaitForSecondsRealtime(2);

        podeAtacar = true;
    }
    public void DisparoAlto()
    {
        FlipSurpresa();

        if (ladoDireito)
        {
            pontoDisparo.localPosition = new Vector2(6, 2.5f);
        }
        else
        {
            pontoDisparo.localPosition = new Vector2(-6, 2.5f);
        }
    }
    public void DisparoMedio()
    {
        FlipSurpresa();

        if (ladoDireito)
        {
            pontoDisparo.localPosition = new Vector2(3, -1);
        }
        else
        {
            pontoDisparo.localPosition = new Vector2(-3, -1);
        }
    }
    public void DisparoBaixo()
    {
        FlipSurpresa();

        if (ladoDireito)
        {
            pontoDisparo.localPosition = new Vector2(6, -3.5f);
        }
        else
        {
            pontoDisparo.localPosition = new Vector2(-6, -3.5f);
        }
    }
    public void SomImpacto()
    {
        aS.clip = metalImpacto;
        aS.Play();
    }
    public void SomRisada()
    {
        aS.clip = risada;
        aS.Play();
    }
    public bool probabilidadeAtirar()
    {
        if (this.gameObject != null)
        {
            numeroAleatorio = Random.Range(1, 4);

            if (numeroAleatorio == 1)
            {
                StartCoroutine(Atirar());

                return false;
            }
            else
            {
                StartCoroutine(Atirar_Plus());
            }
        }

        return false;

    }
    public bool probabilidadeAtaqueBasico()
    {
        numeroAleatorio = Random.Range(1, 4);

        if (numeroAleatorio == 1)
        {
            StartCoroutine(AtaqueBasico());

            return false;
        }
        else
        {
            StartCoroutine(AtaqueBasico_Plus());
        }

        return false;
    }

    public void SeringaMovimento()
    {
        GameObject seringaTemp = (GameObject)(Instantiate(seringa, pontoDisparo.transform.position, Quaternion.identity));

        if (ladoDireito)
        {
            seringaTemp.GetComponent<Seringa>().Inicializar(Vector2.right);
        }
        else
        {
            //Direciona a cenoura conforme a direcao que o personagem aponta
            //Importa o void inicializar com o componente de direcao do script da cenoura
            seringaTemp.GetComponent<Seringa>().Inicializar(Vector2.left);
        }

        SomTiro();
    }
    public void SomTiro()
    {
        aS.clip = somTiro;
        aS.Play();
    }

    public void SerraMovimento()
    {
            GameObject serraTemp = (GameObject)(Instantiate(serra, pontoDisparo.transform.position, Quaternion.identity));

            if (ladoDireito)
            {
                serraTemp.GetComponent<Seringa>().Inicializar(Vector2.right);
            }
            else
            {
                //Direciona a cenoura conforme a direcao que o personagem aponta
                //Importa o void inicializar com o componente de direcao do script da cenoura
                serraTemp.GetComponent<Seringa>().Inicializar(Vector2.left);
            }
    }
}
