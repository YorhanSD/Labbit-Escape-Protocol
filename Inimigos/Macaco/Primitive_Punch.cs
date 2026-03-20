using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Primitive_Punch : MonoBehaviour
{
    public float raioArea;

    public string animacaoIdle;
    public string animacaoAtaque;

    public bool ladoDireito;
    private bool proximoAtaque = true;
    public bool isPlayer;

    public LayerMask playerLayer;
    public Transform areaAtaque;

    public Transform areaDano;

    public float pocicaoAreaDano_X;
    public float pocicaoAreaDano_Y;
    public float pocicaoAreaAtaque_X;
    public float pocicaoAreaAtaque_Y;

    public float forcaEmpurraoX;
    public float forcaEmpurraoY;

    private Animator anim;
    public AudioSource audioSource;
    public AudioClip somAtaque;

    [SerializeField] private Movimento inimigoMovimento;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        proximoAtaque = true;
    }

    void Update()
    {
        ControlePosicao();
        
        isPlayer = Physics2D.OverlapCircle(areaAtaque.position, raioArea, playerLayer); //Cria o Range de Ataque
        
        if(proximoAtaque == true && isPlayer == true)
        {
            proximoAtaque = false;
            StartCoroutine(AnimacaoAtaque());
        }
    }

    private bool ControlePosicao()
    {
        if (inimigoMovimento != null && inimigoMovimento.moveDireita)
        {
            areaAtaque.localPosition = new Vector2(pocicaoAreaAtaque_X, pocicaoAreaAtaque_Y);
            areaDano.localPosition = new Vector2(pocicaoAreaDano_X, pocicaoAreaDano_Y);
            ladoDireito = true;
        }
        else
        {
            areaAtaque.localPosition = new Vector2(-pocicaoAreaAtaque_X, pocicaoAreaAtaque_Y);
            areaDano.localPosition = new Vector2(-pocicaoAreaDano_X, pocicaoAreaDano_Y);
            ladoDireito = false;
        }

        return false;
    }
 
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(areaAtaque.position, raioArea);
    }

    private IEnumerator AnimacaoAtaque()
    {
        if (inimigoMovimento != null)
        {
            inimigoMovimento.SetPodeAndar(false);
        }

        anim.SetTrigger(animacaoAtaque);

        audioSource.clip = somAtaque;
        audioSource.Play();

        yield return new WaitForSecondsRealtime(1);

        anim.SetTrigger(animacaoIdle);

        yield return new WaitForSecondsRealtime(2);

        if (inimigoMovimento != null)
        {
            inimigoMovimento.SetPodeAndar(true);
        }

        proximoAtaque = true;
    }

    [System.Obsolete]
    private void AplicarEmpurrao()
    {
        Collider2D hit = Physics2D.OverlapCircle(areaDano.position, raioArea, playerLayer);

        if (hit != null)
        {
            Rigidbody2D rbPlayer = hit.GetComponent<Rigidbody2D>();

            if (rbPlayer != null)
            {
                Vector2 direcao;

                if (ladoDireito)
                    direcao = new Vector2(forcaEmpurraoX, forcaEmpurraoY);
                else
                    direcao = new Vector2(-forcaEmpurraoX, forcaEmpurraoY);

                rbPlayer.velocity = direcao;
            }
        }
    }
}
