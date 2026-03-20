using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
//using UnityEditor.Localization.Plugins.XLIFF.V20;

public class Player_Vida : MonoBehaviour
{
    public PontuacaoControle pC;

    public string restart;

    public TextMeshProUGUI textoVida;

    [SerializeField] private MenuMorte menuMorte;

    [SerializeField] private Player_Suffering playerSuffering;

    [SerializeField] private Player_Bencaos playerBencaos;

    [Range (0f,100f)] public float vidaCompleta = 100;

    private bool imuneDano;

    public Slider barraDeVida;

    public Slider barraDeApoio;

    public TextMeshProUGUI textoBarraApoio;

    public Image fill;

    public SpriteRenderer sr;

    public Animator anim;

    public Transform pe;

    public AudioSource aS;

    public AudioClip audioCura;

    public AudioClip audioMorte;

    [System.Obsolete]
    private void Start()
    {
        aS = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        pC = FindObjectOfType<PontuacaoControle>();

        //Teclados e Mouses não podem mais interagir com o Slider

        barraDeVida.interactable = false;
        barraDeApoio.interactable = false;

        barraDeVida.navigation = new Navigation { mode = Navigation.Mode.None };
        barraDeApoio.navigation = new Navigation { mode = Navigation.Mode.None };
    }

    public void TocaMusicaCura()
    {
        aS.clip = audioCura;
        aS.Play();
    }
    public void SetImuneDano(bool _imuneDano)
    {
        imuneDano = _imuneDano;

        if(imuneDano == true)
        {
            StartCoroutine(tempoSemTomarDano());
        }
    }
    public bool GetImuneDano()
    {
        return imuneDano;
    }

    public bool VerificaVida()
    {
        if (barraDeVida.value <= 0)
        {
            if (playerBencaos.GetRessuscitar() == true)
            {
                barraDeVida.value += 50;
                sr.color = Color.white;
                playerBencaos.SetRessuscitar(false);
                playerBencaos.tocaRessuscitar();

                return false;
            }
            else
            {
                pC.AdicionaPontosNegativosPorMorte(2000);
                pC.MostraTotalDePontos();
                playerSuffering.PlayerParalizado();
                anim.SetTrigger("Die");
                aS.clip = audioMorte;
                aS.Play();
            }
        }

        return false;
    }
    public void TelaMorte()
    {
        menuMorte.AtivaTelaMorte();
    }

    public bool BarraDeApoio(bool _mostrar, int _recebeValorCura)
    {
        if (_mostrar == true && _recebeValorCura > 0 && barraDeVida.value < 100)
        {
            barraDeApoio.value = barraDeVida.value + _recebeValorCura;
            float valor = Mathf.PingPong(Time.time, 0.8f);
            fill.color = new Vector4(0, 255, 0, valor);

            return false;
        }

        barraDeApoio.value = 0;

        return false;
    }

    private IEnumerator tempoSemTomarDano()
    {
        yield return new WaitForSeconds(2);
        SetImuneDano(false);
    }

    public void RestauraVidaPlayer(int recebeCura)
    {
        barraDeVida.value += recebeCura;
    }
}
