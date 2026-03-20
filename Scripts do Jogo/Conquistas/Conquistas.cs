using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class Conquistas : MonoBehaviour
{
    public AudioSource aS;
    public AudioClip somConquista;

    public int contaCenourasComidas;
    public int contaRatosAbatidos;
    public int contaInimigosAbatidosComAtaqueBasico;
    public int contaAnotacoesLidas;
    public int contaInimigosDerrotados;
    public int contaDNAs;

    public bool conquistaICompleta = false;
    public bool conquistaIVCompleta = false;
    public bool conquistaVIIICompleta = false;

    public bool atingidoPeloGasToxico;
    public bool atingidoPeloLaser;
    public bool pegoPelaPresa;
    public bool caiuNosEspinhos;

    public GameObject telaConquista;
    public TextMeshProUGUI textoDaConquista;
    public CheckPoint checkPoint;
    public void Start()
    {
        checkPoint = GetComponent<CheckPoint>();


    }
    public void AtivaTelaConquista()
    {
        StartCoroutine(TempoTelaConquista());
    }

    public IEnumerator TempoTelaConquista()
    {
        aS.clip = somConquista;
        aS.Play();

        telaConquista.SetActive(true);
        yield return new WaitForSeconds(5f);
        telaConquista.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (conquistaICompleta == false && collision.gameObject.name == "CheckPoint Fase 1")
        {
            UmPequenoPulo();
            StartCoroutine(TempoTelaConquista());

            //collision.gameObject.name = "CheckPoint Conquistado";

            conquistaICompleta = true;
        }
        if (collision.gameObject.tag == "Anotacao")
        {
            contaAnotacoesLidas++;

            if (contaAnotacoesLidas == 9)
            {
                LeitorAssiduo();
                StartCoroutine(TempoTelaConquista());
            }
        }
        if (collision.gameObject.tag == "DNA Preto" || collision.gameObject.tag == "DNA Azul" || collision.gameObject.tag == "DNA Verde" || collision.gameObject.tag == "DNA Laranja")
        {
            contaDNAs++;

            if (contaDNAs == 25)
            {
                ColecionadorGenetico();
                StartCoroutine(TempoTelaConquista());
            }
        }
        if (collision.gameObject.tag == "BioHazard")
        {
            atingidoPeloGasToxico = true;
        }
        if (collision.gameObject.tag == "Presa De Urso")
        {
            pegoPelaPresa = true;
        }
        if (collision.gameObject.tag == "Ultravioleta")
        {
            atingidoPeloLaser = true;
        }
        if (collision.gameObject.tag == "Espinhos")
        {
            caiuNosEspinhos = true;
        }
        if (conquistaVIIICompleta == false && atingidoPeloLaser == true && atingidoPeloGasToxico == true && caiuNosEspinhos == true && pegoPelaPresa == true)
        {
            Sobrevivente();
            StartCoroutine(TempoTelaConquista());

            conquistaVIIICompleta = true;
        }
    }
    public void UmPequenoPulo()
    {
        string idioma = LocalizationSettings.SelectedLocale.Identifier.CultureInfo.TwoLetterISOLanguageName;

        switch (idioma)
        {
            case "en":
                textoDaConquista.text = "A small jump for a rabbit, A giant leap for the Colony";
                break;

            case "de":
                textoDaConquista.text = "Ein kleiner Sprung für einen Hasen, ein riesiger Sprung für die Kolonie";
                break;

            case "es":
                textoDaConquista.text = "Un pequeño salto para un conejo, un gran salto para la Colonia";
                break;

            case "pt":
                textoDaConquista.text = "Um pequeno pulo para um coelho, Um grante salto para a Colônia";
                break;

            default:
                textoDaConquista.text = "Um pequeno pulo para um coelho, Um grante salto para a Colônia";
                break;
        }

        checkPoint.SalvarConquistaI();
    }
    public void AlimentacaoBalanceada()
    {
        string idioma = LocalizationSettings.SelectedLocale.Identifier.CultureInfo.TwoLetterISOLanguageName;

        switch (idioma)
        {
            case "en":
                textoDaConquista.text = "Balanced Diet";
                break;

            case "de":
                textoDaConquista.text = "Ausgewogene Ernährung";
                break;

            case "es":
                textoDaConquista.text = "Alimentación Balanceada";
                break;

            case "pt":
                textoDaConquista.text = "Alimentação Balanceada";
                break;

            default:
                textoDaConquista.text = "Alimentação Balanceada";
                break;
        }

        checkPoint.SalvarConquistaII();
    }
    public void ControleDePragas()
    {
        string idioma = LocalizationSettings.SelectedLocale.Identifier.CultureInfo.TwoLetterISOLanguageName;

        switch (idioma)
        {
            case "en":
                textoDaConquista.text = "Pest Control";
                break;

            case "de":
                textoDaConquista.text = "Schädlingsbekämpfung";
                break;

            case "es":
                textoDaConquista.text = "Control de Plagas";
                break;

            case "pt":
                textoDaConquista.text = "Controle De Pragas";
                break;

            default:
                textoDaConquista.text = "Controle De Pragas";
                break;
        }

        checkPoint.SalvarConquistaIII();
    }
    public void Nocaute()
    {
        string idioma = LocalizationSettings.SelectedLocale.Identifier.CultureInfo.TwoLetterISOLanguageName;

        switch (idioma)
        {
            case "en":
                textoDaConquista.text = "Nocaute!";
                break;

            case "de":
                textoDaConquista.text = "K.o.!";
                break;

            case "es":
                textoDaConquista.text = "¡Nocaut!";
                break;

            case "pt":
                textoDaConquista.text = "Nocaute!";
                break;

            default:
                textoDaConquista.text = "Nocaute!";
                break;
        }

        checkPoint.SalvarConquistaIV();
    }
    public void LeitorAssiduo()
    {
        string idioma = LocalizationSettings.SelectedLocale.Identifier.CultureInfo.TwoLetterISOLanguageName;

        switch (idioma)
        {
            case "en":
                textoDaConquista.text = "Avid Reader";
                break;

            case "de":
                textoDaConquista.text = "Eifriger Leser";
                break;

            case "es":
                textoDaConquista.text = "Lector Asiduo";
                break;

            case "pt":
                textoDaConquista.text = "Leitor Assíduo";
                break;

            default:
                textoDaConquista.text = "Leitor Assíduo";
                break;
        }

        checkPoint.SalvarConquistaV();
    }
    public void ColecionadorGenetico()
    {
        string idioma = LocalizationSettings.SelectedLocale.Identifier.CultureInfo.TwoLetterISOLanguageName;

        switch (idioma)
        {
            case "en":
                textoDaConquista.text = "Genetic Collector";
                break;

            case "de":
                textoDaConquista.text = "Genetischer Sammler";
                break;

            case "es":
                textoDaConquista.text = "Coleccionista Genético";
                break;

            case "pt":
                textoDaConquista.text = "Colecionador Genético";
                break;

            default:
                textoDaConquista.text = "Colecionador Genético";
                break;
        }

        checkPoint.SalvarConquistaVI();
    }
    public void ResolvendoTudoNoDialago()
    {
        string idioma = LocalizationSettings.SelectedLocale.Identifier.CultureInfo.TwoLetterISOLanguageName;

        switch (idioma)
        {
            case "en":
                textoDaConquista.text = "Solving Everything in Dialogue";
                break;

            case "de":
                textoDaConquista.text = "Alles im Dialog lösen";
                break;

            case "es":
                textoDaConquista.text = "Resolviendo Todo En El Diálogo";
                break;

            case "pt":
                textoDaConquista.text = "Resolvendo Tudo No Diálago";
                break;

            default:
                textoDaConquista.text = "Resolvendo Tudo No Diálago";
                break;
        }

        checkPoint.SalvarConquistaVII();
    }
    public void Sobrevivente()
    {
        string idioma = LocalizationSettings.SelectedLocale.Identifier.CultureInfo.TwoLetterISOLanguageName;

        switch (idioma)
        {
            case "en":
                textoDaConquista.text = "Survivor";
                break;

            case "de":
                textoDaConquista.text = "Überlebender";
                break;

            case "es":
                textoDaConquista.text = "Superviviente";
                break;

            case "pt":
                textoDaConquista.text = "Sobrevivente";
                break;

            default:
                textoDaConquista.text = "Sobrevivente";
                break;
        }

        checkPoint.SalvarConquistaVIII();
    }
    public void SemRemorso()
    {

        string idioma = LocalizationSettings.SelectedLocale.Identifier.CultureInfo.TwoLetterISOLanguageName;

        switch (idioma)
        {
            case "en":
                textoDaConquista.text = "No Remorse";
                break;

            case "de":
                textoDaConquista.text = "Keine Reue";
                break;

            case "es":
                textoDaConquista.text = "Sin Remordimientos";
                break;

            case "pt":
                textoDaConquista.text = "Sem Remorso";
                break;

            default:
                textoDaConquista.text = "Sem Remorso";
                break;
        }

        checkPoint.SalvarConquistaIX();
    }
}
