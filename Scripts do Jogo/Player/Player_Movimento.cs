using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_Movimento : MonoBehaviour
{
    [Header ("Atributos de Movimentação")]

    [SerializeField] public float movimento;
    [SerializeField][Range(0f,30f)] private float velocidade;
    [SerializeField][Range(0f, 50f)] private float forcaPulo;
    [SerializeField] private bool noChao;
    public bool ladoDireito = false;

    [SerializeField] private Player_Bencaos playerBencaos;
    [SerializeField] private Player_Physics playerPhysics;

    public SpriteRenderer sr;
   
    private Rigidbody2D rigid2D;
    private Animator anim;
    private bool imobilizado;
    private bool confuso;
    public Transform pe;
    public float tamanhoPe;
    public Transform pontoDisparo;
    public Transform golpeDano;
    public LayerMask chao;
    public AudioSource aS;
    public AudioClip audioPulo;

    [System.Obsolete]
    public void SetPlayerVelocidade(float _velocidade)
    {
        velocidade = _velocidade;
    }
    public void SetPlayerForcaPulo(float _forcaPulo)
    {
        forcaPulo = _forcaPulo;
    }
    public float GetPlayerVelocidade()
    {
        return velocidade;
    }
    public float GetPlayerForcaPulo()
    {
        return forcaPulo;
    }
    public void SetPlayerImobilizado(bool _imobilizado)
    {
        rigid2D.linearVelocity = Vector2.zero;
        imobilizado = _imobilizado;
    }
    public bool GetPlayerImobilizado()
    {
        return imobilizado;
    }
    public void SetPlayerConfuso(bool _confuso)
    {
        confuso = _confuso;

        if (confuso == true) 
        {
            sr.color = Color.green;
        }
        else
        {
            if (playerBencaos.GetRessuscitar() == true)
            {
                sr.color = Color.mediumPurple;
            }
            else
            {
                sr.color = Color.white;
            }
        }
    }
    public bool GetPlayerConfuso()
    {
        return confuso;
    }

    public void Start()
    {
        aS = GetComponent<AudioSource>();
        rigid2D = GetComponent<Rigidbody2D>(); //Referencia o rigidbody2D do player
        sr = GetComponent<SpriteRenderer>(); //Referencia o sprite rendenrer
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        /*
        for (int i = 0; i < 19; i++)
        {
            if (Input.GetKeyDown("joystick button " + i.ToString()))
                print("joystick button " + i.ToString());
        }
        */

        //Alteracao das teclas esta em: Edit / Project Settings / Input Manager

        noChao = Physics2D.OverlapCircle(pe.position, tamanhoPe, chao);//Cria um raio no pe e verifica o que e chao

        //Pulo
        if (Input.GetKeyDown(KeyCode.UpArrow) && noChao == true || Input.GetKeyDown(KeyCode.W) && noChao == true || Input.GetKeyDown(KeyCode.Space) && noChao == true ||(Input.GetKeyDown("joystick button 1") && noChao == true ))//Quando a tecla "UpArrow" ou "W" for pressionada e noChao for verdadeiro entao:
        {
            aS.clip = audioPulo;
            aS.Play();
            rigid2D.linearVelocity = Vector2.up * forcaPulo; //Player vai ser impulsionado para cima vezes a forcaPulo
        }

        playerPhysics.SetNoChao(noChao);
    }

    private void FixedUpdate()
    {
        PlayerMovimento();
    }

    public bool PlayerMovimento()
    {
        if (GetPlayerImobilizado() == true)
        {
            //rigid2D.linearVelocity = new Vector2(0, 0);
            rigid2D.linearVelocity = Vector2.zero;

            anim.SetFloat("Walking", Mathf.Abs(0));
            anim.SetFloat("Jump", Mathf.Abs(0));

            return false;
        }

        if (GetPlayerConfuso() == true && playerBencaos.GetRessuscitar() == false)
        {
            sr.color = Color.green; //Deixa o Player Verde

            return false;
        }

        movimento = Input.GetAxis("Horizontal");

        //Controle de Animação no Eixo X e Y

        anim.SetFloat("Walking", Mathf.Abs(rigid2D.linearVelocity.x));
        anim.SetFloat("Jump", Mathf.Abs(rigid2D.linearVelocity.y));

        rigid2D.linearVelocity = new Vector2(movimento * velocidade, rigid2D.linearVelocity.y);

        Flip(movimento);

        return false;
    }

    private void Flip(float _movimento) //Flipa o Sprite do Player de acordo com o movimento
    {
        if (_movimento > 0)
        {
            sr.flipX = true;
            pontoDisparo.localPosition = new Vector2(4.5f, 0f);
            golpeDano.localPosition = new Vector2(7, 0f);
            ladoDireito = true;
        }
        else if (_movimento < 0)
        {
            sr.flipX = false;
            pontoDisparo.localPosition = new Vector2(-4.5f, 0f);
            golpeDano.localPosition = new Vector2(-7, 0f);
            ladoDireito = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            transform.parent = collision.transform;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            transform.parent = null;
        }
    }

    public void OnTriggerEnter2D(Collider2D _player)
    {
        if (playerBencaos.GetImuneToxicidade() == false) 
        {
            if (_player.gameObject.tag == "Seringa" || _player.gameObject.tag == "BioHazard" || _player.gameObject.tag == "Serra")
            {
                StartCoroutine(Confusao());
            }
        }
    }
    IEnumerator Confusao()
    {
        SetPlayerConfuso(true);
        yield return new WaitForSeconds(2f);
        SetPlayerConfuso(false);
    }


}


