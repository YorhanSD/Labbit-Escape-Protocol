using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ataque : MonoBehaviour
{
    [Header("Conquistas")]

    public Conquistas conquistas;

    [Header("Atributos de Ataque")]

    public GameObject[] cenouraPrefab;
    private int contador = 0;
    [SerializeField] private Inventario inventario;
    [SerializeField] private Player_Bencaos playerBencaos;
    [SerializeField] private Atirar_Cenoura atirarCenoura;
    [SerializeField] private Player_Movimento playerMovimento;
    [SerializeField] private Controle_Emocional controleEmocional;
    [SerializeField] private Player_Vida playerVida;

    public bool ladoDireito;
    public float raioAtaque;
    public Transform areaDano;
    public LayerMask inimigoLayer;

    private Animator anim;
    public AudioSource aS;
    public AudioClip audioGolpeKarate;
    public AudioClip audioChuteChicote;
    public AudioClip audioTacandoCenoura;
    public AudioClip audioCura;
    public float forcaEmpurraoX = 28;
    public float forcaEmpurraoY = 18;

    bool podeDispararCenoura = true;

    bool podeUsarAtaqueBasico = true;

    [System.Obsolete]
    public void Awake()
    {
        atirarCenoura = GameObject.FindObjectOfType<Atirar_Cenoura>();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        aS = GetComponent<AudioSource>();
        conquistas = GetComponent<Conquistas>();
    }

    IEnumerator EsperaAnimacaoTacandoCenoura()
    {
        //anim.SetTrigger("Hitting");
        yield return new WaitForSeconds(0.3f);
        //CenouraMovimento();
    }
    IEnumerator EsperaAnimacaoChuteChicote()
    {
        anim.SetTrigger("Kicking");
        aS.clip = audioGolpeKarate;
        aS.Play();
        yield return new WaitForSeconds(0.3f);
        aS.clip = audioChuteChicote;
        aS.Play();
    }
    IEnumerator VelocidadeAtaque()
    {
        yield return new WaitForSeconds(1.2f);
        podeUsarAtaqueBasico = true;
    }
    IEnumerator VelocidadeAtirarCenoura()
    {
        yield return new WaitForSeconds(0.3f);
        podeDispararCenoura = true;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && podeUsarAtaqueBasico == true)
        {
            podeUsarAtaqueBasico = false;

            if (controleEmocional.emocaoSlider.value == 0 || controleEmocional.emocaoSlider.value == 100)
            {
                PlayerAtaquePlus();
            }
            else
            {
                PlayerAtaque();
            }
        }

        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown("joystick button 5")) // Controle do tiro
        {
            if (atirarCenoura.GetPodeAtirar() == true && podeDispararCenoura == true)
            {
                podeDispararCenoura = false;

                aS.clip = audioTacandoCenoura;
                aS.Play();

                if (atirarCenoura.GetItem().GetQuantidade() > 0)
                {
                    VerificaCenoura(atirarCenoura.GetItem());
                    atirarCenoura.SetPodeAtirar(false);
                    atirarCenoura.GetPodeAtirar();
                    inventario.TiraItem(atirarCenoura.GetItem(), -1);

                    //StartCoroutine(EsperaAnimacaoTacandoCenoura());
                    StartCoroutine(VelocidadeAtirarCenoura());

                    anim.SetTrigger("Hitting");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown("joystick button 4")) // Controle comer cenoura
        {
            if (atirarCenoura.GetPodeAtirar() == true)
            {
                if (atirarCenoura.GetItem().GetQuantidade() > 0)
                {
                    playerVida.TocaMusicaCura();

                    atirarCenoura.SetPodeAtirar(false);

                    conquistas.contaCenourasComidas++;

                    if (conquistas.contaCenourasComidas == 6)
                    {
                        conquistas.AtivaTelaConquista();
                        conquistas.AlimentacaoBalanceada();
                    }

                    playerVida.barraDeVida.value += atirarCenoura.GetItem().GetCura();

                    if (atirarCenoura.GetItem().GetNome() == "Super Cenoura Preta")
                    {
                        playerBencaos.SetRessuscitar(true);
                    }
                    else if (atirarCenoura.GetItem().GetNome() == "Super Cenoura Laranja")
                    {
                        playerBencaos.SetRegeneracao(true);
                    }
                    else if (atirarCenoura.GetItem().GetNome() == "Super Cenoura Azul")
                    {
                        playerBencaos.SetImunidadeUltravioleta(true);
                    }
                    else if (atirarCenoura.GetItem().GetNome() == "Super Cenoura Verde")
                    {
                        playerBencaos.SetImunidadeToxicidade(true);
                    }

                    inventario.TiraItem(atirarCenoura.GetItem(), -1);

                    playerBencaos.SuperCoelho();
                }
            }
        }
    }
    void PlayerAtaque()
    {
        anim.SetTrigger("Punch");
        aS.clip = audioGolpeKarate;
        aS.Play();
        StartCoroutine(VelocidadeAtaque());
    }

    void PlayerAtaquePlus()
    {
        StartCoroutine(EsperaAnimacaoChuteChicote());
        StartCoroutine(VelocidadeAtaque());
    }

    private void AplicarEmpurrao() //Chamado na Animação
    {
        Collider2D hit = Physics2D.OverlapCircle(areaDano.position, raioAtaque, inimigoLayer);

        if (hit != null)
        {
            Rigidbody2D rbInimigo = hit.GetComponent<Rigidbody2D>();

            if (rbInimigo != null)
            {
                Vector2 direcao;

                if (ladoDireito)
                    direcao = new Vector2(-forcaEmpurraoX, forcaEmpurraoY);
                else
                    direcao = new Vector2(forcaEmpurraoX, forcaEmpurraoY);

                rbInimigo.linearVelocity = direcao;
                //rbInimigo.AddForce(direcao, ForceMode2D.Impulse);
            }
        }
    }

    public void VerificaCenoura(Item _item)
    {
        switch (_item.GetNome())
        {
            case "Cenoura Azul":
                contador = 0;
                break;
            case "Cenoura Laranja":
                contador = 1;
                break;
            case "Cenoura Preta":
                contador = 2;
                break;
            case "Cenoura Verde":
                contador = 3;
                break;
            case "Super Cenoura Azul":
                contador = 4;
                break;
            case "Super Cenoura Laranja":
                contador = 5;
                break;
            case "Super Cenoura Preta":
                contador = 6;
                break;
            case "Super Cenoura Verde":
                contador = 7;
                break;
        }
    }

    public void CenouraMovimento() //Chamado na Animação
    {
        //cria um clone de uma cenoura no ponto de disparo
        //Atira a cenoura conforme a direcao do player
        GameObject cenouraTemp = (GameObject)(Instantiate(cenouraPrefab[contador], playerMovimento.pontoDisparo.transform.position, Quaternion.identity));

        if (playerMovimento.ladoDireito)
        {
            cenouraTemp.GetComponent<Item>().Direcao(Vector2.right);
            cenouraTemp.GetComponent<Item>().GirarCenoura();
            cenouraTemp.GetComponent<Item>().VerificaCenouraPerfurante();
        }
        else
        {
            //Direciona a cenoura conforme a direcao que o personagem aponta
            //Chama o metodo inicializar com o componente de direcao do script da cenoura 
            cenouraTemp.GetComponent<Item>().Direcao(Vector2.left);
            cenouraTemp.GetComponent<Item>().GirarCenoura();
            cenouraTemp.GetComponent<Item>().VerificaCenouraPerfurante();
        }
    }
}
