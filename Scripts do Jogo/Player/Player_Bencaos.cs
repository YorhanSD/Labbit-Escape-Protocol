using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Bencaos : MonoBehaviour
{
    [SerializeField] Controle_Emocional cE;
    [SerializeField] Player_Vida pV;

    public Efeitos_Visuais eV;
    private bool ativouLuz = false;
    public AudioSource aS;

    public AudioClip ressuscitarSom;

    public AudioClip poison;

    public SpriteRenderer sR;

    public GameObject imgSuperCoelho;

    public GameObject particulaSuperCoelho;

    public GameObject particulaRegeneracao;

    public GameObject escudoUltravioleta;

    public GameObject particulaBiohazard;

    [SerializeField] private bool ressuscitar = false;

    [SerializeField] private bool regeneracao = false;

    [SerializeField] private bool imunidadeUltravioleta = false;

    [SerializeField] private bool imunidadeToxicidade = false;

    private bool eSuperCoelho = false;
    private bool todosOsBuffsAtivos = false;

    [System.Obsolete]
    private void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        eV = FindObjectOfType<Efeitos_Visuais>();
    }

    private void OnTriggerEnter2D(Collider2D _player)
    {
        if (_player.gameObject.tag == "Bala")
        {
            ChecaDanoBala();
        }
        if (_player.gameObject.tag == "Ultravioleta")
        {
            ChecaImunidadeUltravioleta();
        }
        if (_player.gameObject.tag == "BioHazard")
        {
            ChecaImunidadeToxicidade();
        }
        if (_player.gameObject.tag == "Serra")
        {
            pV.SetImuneDano(true);
            pV.barraDeVida.value -= 60;
            pV.VerificaVida();
            cE.Medo(50);

            SetRegeneracao(false);

            SuperCoelho();
        }
        if (_player.gameObject.tag == "Bisturi")
        {
            pV.SetImuneDano(true);
            pV.barraDeVida.value -= 30;
            pV.VerificaVida();
            cE.Medo(50);

            SetImunidadeToxicidade(false);

            SuperCoelho();
        }
    }

    public bool ChecaImunidadeUltravioleta()
    {
        if (GetImuneUltravioleta() == false && pV.GetImuneDano() == false)
        {
            pV.SetImuneDano(true);
            pV.barraDeVida.value -= 40;
            pV.VerificaVida();
            cE.Medo(50);
        }

        return false;
    }
    public bool ChecaImunidadeToxicidade()
    {
        if (GetImuneToxicidade() == false && pV.GetImuneDano() == false)
        {
            pV.SetImuneDano(true);
            pV.barraDeVida.value -= 40;
            cE.Medo(50);
            pV.VerificaVida();
            aS.clip = poison;
            aS.Play();
        }

        return false;
    }

    public bool ChecaDanoBala()
    {
        pV.barraDeVida.value -= 50;
        cE.Medo(50);
        pV.VerificaVida();
        return false;
    }

    public void tocaRessuscitar()
    {
        aS.clip = ressuscitarSom;
        aS.Play();
    }
    public bool GetRessuscitar()
    {
        return ressuscitar;
    }

    public void SetRessuscitar(bool _ressuscitar)
    {
        ressuscitar = _ressuscitar;

        if (_ressuscitar == true)
        {
            sR.color = Color.mediumPurple;
        }
        else
        {
            sR.color = Color.white;
        }
    }

    public void SetRegeneracao(bool _regeneracao)
    {
        regeneracao = _regeneracao;

        if (_regeneracao == true)
        {
            particulaRegeneracao.SetActive(true);

            StartCoroutine(TempRegenerar());
        }
        else
            particulaRegeneracao.SetActive(false);
    }

    public void SetImunidadeUltravioleta(bool _imunidadeUltravioleta)
    {
        imunidadeUltravioleta = _imunidadeUltravioleta;

        if (_imunidadeUltravioleta == true)
        {
            escudoUltravioleta.SetActive(true);
        }
        else
            escudoUltravioleta.SetActive(false);
    }
    public void SetImunidadeToxicidade(bool _imunidadeToxicidade)
    {
        imunidadeToxicidade = _imunidadeToxicidade;

        if (_imunidadeToxicidade == true)
            particulaBiohazard.SetActive(true);
        else
            particulaBiohazard.SetActive(false);
    }

    public bool GetRegeneracao()
    {
        return regeneracao;
    }
    public bool GetImuneToxicidade()
    {
        return imunidadeToxicidade;
    }
    public bool GetImuneUltravioleta()
    {
        return imunidadeUltravioleta;
    }
    IEnumerator TempRegenerar()
    {
        while (GetRegeneracao() == true)
        {
            yield return new WaitForSeconds(3.5f);

            if (pV.barraDeVida.value < 100)
            {
                pV.barraDeVida.value += 20;
            }
        }
    }

    public void SuperCoelho()
    {
        if (ressuscitar == true && regeneracao == true && imunidadeToxicidade == true && imunidadeUltravioleta == true)
        {
            eSuperCoelho = true;
            todosOsBuffsAtivos = true;

            if (ativouLuz == false)
            {
                eV.EfeitoCoelhoDestemido();

                ativouLuz = true;
            }

            imgSuperCoelho.SetActive(true);

            sR.color = Color.yellow;

            particulaSuperCoelho.SetActive(true);
            
            particulaBiohazard.SetActive(false);
            escudoUltravioleta.SetActive(false);
            particulaRegeneracao.SetActive(false);
        }
        else
        {
            todosOsBuffsAtivos = false;
        }

        if (eSuperCoelho == true && todosOsBuffsAtivos == false)
        {
            ativouLuz = false;

            imgSuperCoelho.SetActive(false);

            SetRessuscitar(false);

            SetRegeneracao(false);

            SetImunidadeUltravioleta(false);

            SetImunidadeToxicidade(false);

            particulaSuperCoelho.SetActive(false);

            eSuperCoelho = false;
        }
    }


}
