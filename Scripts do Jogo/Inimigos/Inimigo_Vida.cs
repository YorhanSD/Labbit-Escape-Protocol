using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inimigo_Vida : MonoBehaviour
{
    public Conquistas conquistas;

    public Rigidbody2D rigid2D;
    public float vidaCompleta = 50;
    public bool permitirDrop = true;
    public bool resistenciaCenouras = false;
    private int randomProbabilidade;

    public AudioSource audioSource;
    public AudioClip sofrendoDano;
    public Animator anim;
    public Text vidaTexto;
    public Slider barraDeVida;
    public GameObject[] dropItem;
    public GameObject inimigo;
    public bool imune = false;

    public bool isAldos;

    [SerializeField] private Player_Vida playerVida;
    [SerializeField] private Controle_Emocional controleEmocional;
    [SerializeField] private TrocaDeEstado trocaDeEstado;
    [SerializeField] private PontuacaoControle pC;

    public Movimento inimigoMovimento;

    [System.Obsolete]
    public void Start()
    {
        pC = FindObjectOfType<PontuacaoControle>();

        rigid2D = GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();

        anim = GetComponent<Animator>();

        conquistas = FindObjectOfType<Conquistas>();

        if (inimigoMovimento != null)
        {
            inimigoMovimento.GetComponent<Movimento>();
        }

        //Teclados e Mouses não podem mais interagir com o Slider

        barraDeVida.interactable = false;
        barraDeVida.navigation = new Navigation { mode = Navigation.Mode.None };
    }

    private void Update()
    {
       
    }

    public void InimigoVerificaVida()
    {
        vidaTexto.text = vidaCompleta + " / " + barraDeVida.value;

        if (barraDeVida.value <= 0)
        {
            if (inimigoMovimento != null)
            {
                inimigoMovimento.SetPodeAndar(false);
            }

            anim.SetTrigger("Death");

            GanharCoragem(50);
        }
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (resistenciaCenouras == true)
        {
            DanoMinimo(_other);
        }
        else
        {
            DanoMaximo(_other);

            if (_other.CompareTag("GolpeKarate"))
            {
                TomaDano(20);

                VerificaConquistasComAtaqueBasico();
            }
        }
    }

    void VerificaConquistasComAtaqueBasico()
    {
        if (conquistas != null)
        {
            if (barraDeVida.value == 0)
            {
                conquistas.contaInimigosAbatidosComAtaqueBasico++;

                if (conquistas.contaInimigosAbatidosComAtaqueBasico == 10)
                {
                    conquistas.AtivaTelaConquista();
                    conquistas.ResolvendoTudoNoDialago();
                }

                if (gameObject.name == "Macaco-Tóxico" && conquistas.conquistaIVCompleta == false)
                {
                    conquistas.AtivaTelaConquista();
                    conquistas.Nocaute();
                    conquistas.conquistaIVCompleta = true;
                }
            }
        }
    }

    void VerificaConquistas()
    {
        if (conquistas != null)
        {
            conquistas.contaInimigosDerrotados++;

            if (conquistas.contaInimigosDerrotados == 25)
            {
                conquistas.AtivaTelaConquista();
                conquistas.SemRemorso();
            }

            if (gameObject.name == "Rato-Queimadura")
            {
                conquistas.contaRatosAbatidos++;

                if (conquistas.contaRatosAbatidos == 3)
                {
                    conquistas.AtivaTelaConquista();
                    conquistas.ControleDePragas();
                }
            }
        }
    }

    public void DanoMinimo(Collider2D _other)
    {
        if (_other.gameObject.tag == "CenouraLaranja")
        {
            if (controleEmocional.emocaoSlider.value > 99)
            {
                TomaDano(20 / 2);
            }
            else
            {
                TomaDano(10 / 2);
            }
        }
        else if (_other.gameObject.tag == "CenouraPreta")
        {
            if (controleEmocional.emocaoSlider.value > 99)
            {
                TomaDano(60 / 2);
            }
            else
            {
                TomaDano(30 / 2);
            }
        }
        else if (_other.gameObject.tag == "SuperCenouraPreta")
        {
            if (controleEmocional.emocaoSlider.value > 99)
            {
                TomaDano(80 / 2);
            }
            else
            {
                TomaDano(40 / 2);
            }
        }
        else if (_other.gameObject.tag == "SuperCenouraVerde")
        {
            if (controleEmocional.emocaoSlider.value > 99)
            {
                TomaDano(120 / 2);
            }
            else
            {
                TomaDano(60 / 2);
            }
        }
        else if (_other.gameObject.tag == "SuperCenouraAzul")
        {
            if (controleEmocional.emocaoSlider.value > 99)
            {
                TomaDano(60 / 2);
            }
            else
            {
                TomaDano(30 / 2);
            }

            playerVida.barraDeVida.value += GameObject.FindGameObjectWithTag("SuperCenouraAzul").GetComponent<Super_CenouraAzul>().GetCura();
            playerVida.TocaMusicaCura();
        }
        else if (_other.gameObject.tag == "SuperCenouraLaranja")
        {
            if (controleEmocional.emocaoSlider.value > 99)
            {
                TomaDano(20 / 2);
            }
            else
            {
                TomaDano(10 / 2);
            }
            playerVida.barraDeVida.value += GameObject.FindGameObjectWithTag("SuperCenouraLaranja").GetComponent<Super_CenouraLaranja>().GetCura();
            playerVida.TocaMusicaCura();
        }

        InimigoVerificaVida();
    }
    public void DanoMaximo(Collider2D _other)
    {
        if (_other.gameObject.tag == "CenouraLaranja")
        {
            if (controleEmocional.emocaoSlider.value > 99)
            {
                TomaDano(20);
            }
            else
            {
                TomaDano(10);
            }
        }
        else if (_other.gameObject.tag == "CenouraPreta")
        {
            if (controleEmocional.emocaoSlider.value > 99)
            {
                TomaDano(60);
            }
            else
            {
                TomaDano(30);
            }
        }
        else if (_other.gameObject.tag == "SuperCenouraPreta")
        {
            if (controleEmocional.emocaoSlider.value > 99)
            {
                TomaDano(80);
            }
            else
            {
                TomaDano(40);
            }
        }
        else if (_other.gameObject.tag == "SuperCenouraVerde")
        {
            if (controleEmocional.emocaoSlider.value > 99)
            {
                TomaDano(120);
            }
            else
            {
                TomaDano(60);
            }
        }
        else if (_other.gameObject.tag == "SuperCenouraAzul")
        {
            if (controleEmocional.emocaoSlider.value > 99)
            {
                TomaDano(60);
            }
            else
            {
                TomaDano(30);
            }

            playerVida.barraDeVida.value += GameObject.FindGameObjectWithTag("SuperCenouraAzul").GetComponent<Super_CenouraAzul>().GetCura();
            playerVida.TocaMusicaCura();

        }
        else if (_other.gameObject.tag == "SuperCenouraLaranja")
        {
            if (controleEmocional.emocaoSlider.value > 99)
            {
                TomaDano(20);
            }
            else
            {
                TomaDano(10);
            }

            playerVida.barraDeVida.value += GameObject.FindGameObjectWithTag("SuperCenouraLaranja").GetComponent<Super_CenouraLaranja>().GetCura();
            playerVida.TocaMusicaCura();

        }

        InimigoVerificaVida();

    }
    public void Drop()
    {
        randomProbabilidade = Random.Range(0, 2);

        Instantiate(dropItem[randomProbabilidade], gameObject.transform.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y + 2f), gameObject.transform.rotation);

        Debug.Log("Dropou DNA Resultado : " + randomProbabilidade);
    }
    public void ImuneDano()
    {
        imune = !imune;
    }
    public void ReproduzirSomSofrendoDano()
    {
        if (audioSource != null)
        {
            audioSource.clip = sofrendoDano;
            audioSource.Play();
        }
    }
    private void TomaDano(int _dano)
    {
        if (imune != true)
        {
            barraDeVida.value -= _dano;
          
            StartCoroutine(AnimacaoSofrendoDano());
            ReproduzirSomSofrendoDano();

            InimigoVerificaVida();
        }
    }

    private IEnumerator AnimacaoSofrendoDano()
    {
        anim.SetTrigger("Suffering");

        if (inimigoMovimento != null)
        {
            inimigoMovimento.SetPodeAndar(false);
            rigid2D.linearVelocity = Vector2.zero;
            yield return new WaitForSeconds(1.5f);
            inimigoMovimento.SetPodeAndar(true);
        }
    }

    private void GanharCoragem(int _nivelCoragem)
    {
        controleEmocional.Coragem(_nivelCoragem);
    }
    private void Morte() //Chamado na Animação
    {
        pC.AdicionaPontoPorAbate(2000);
        pC.MostraTotalDePontos();

        VerificaConquistas();

        if (permitirDrop == true)
        {
            Drop();
        }

        if (isAldos)
        {
            trocaDeEstado.AtivarAldosTunado();
        }

        Destroy(gameObject);
    }
    
}
