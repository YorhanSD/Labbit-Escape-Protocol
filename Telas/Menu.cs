using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

public class Menu : MonoBehaviour
{
    private bool ativaTraducao;

    public Ativa_JogoSalvo ajs;
    public CheckPoint checkPoint;
    public PontuacaoControle pC;

    public string cena;
    public string voltarCena;
    public string cenaFases;
    public string novoJogo;
    private bool isPaused;

    public GameObject painelPausa;
    public GameObject painelOpcoes;
    public GameObject painelControles;
    public GameObject painelResolucoes;
    public GameObject painelGraficos;
    public GameObject painelAudio;
    public GameObject painelConquistas;
    public GameObject painelIdiomas;
    public GameObject painelCreditos;
    public GameObject painelEstatisticas;

    private void Awake()
    {
        checkPoint = GetComponent<CheckPoint>();

        if (checkPoint.JogoSalvo() != null)
        {
            checkPoint.JogoSalvo();
        }
    }

    void Start()
    {
        Time.timeScale = 1f;

        if(pC != null)
        {
            pC = GetComponent<PontuacaoControle>();
        }
        if (ajs != null)
        {
            ajs = GetComponent<Ativa_JogoSalvo>();
        }
    }
    void PauseScreen()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            painelPausa.SetActive(false);
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0f;
            painelPausa.SetActive(true);
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7"))
        {
            PauseScreen();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(cena); //coloca o nome da cena em MenuManager
    }

    public void QuitGame()
    {
        // Editor unity
        //UnityEditor.EditorApplication.isPlaying = false;

        //Jogo compilado - comentar a linha acima e descomentar a abaixo antes de gerar a build
       Application.Quit();
    }

    public void IniciaTraducao(string codigoIdioma)
    {
        if (ativaTraducao)
            return;

        StartCoroutine(MudaLingua(codigoIdioma));
    }

    public IEnumerator MudaLingua(string codigoIdioma)
    {
        ativaTraducao = true;

        yield return LocalizationSettings.InitializationOperation;

        foreach (var locale in LocalizationSettings.AvailableLocales.Locales)
        {
            if (locale.Identifier.Code.StartsWith(codigoIdioma))
            {
                Debug.Log("Mudando para: " + locale.Identifier.Code);
                LocalizationSettings.SelectedLocale = locale;
                break;
            }
        }

        ativaTraducao = false;
    }
    public void ShowOptions()
    {
        painelOpcoes.SetActive(true);
    }
    public void BotaoVoltarPause()
    {
        Time.timeScale = 1f;
        painelPausa.SetActive(false);
    }
    public void BotaoVoltarMenu()
    {
        if (painelOpcoes != null)
        {
            painelOpcoes.SetActive(false);
        }
        if (painelResolucoes != null)
        {
            painelResolucoes.SetActive(false);
        }
        if (painelControles != null)
        {
            painelControles.SetActive(false);
        }
        if (painelGraficos != null)
        {
            painelGraficos.SetActive(false);
        }
        if (painelAudio != null)
        {
            painelAudio.SetActive(false);
        }
        if (painelEstatisticas != null)
        {
            painelEstatisticas.SetActive(false); 
            pC.TelaAtivada();            
            //pC.jogadorAbriuEstatisticas = false;
        }

        if(painelCreditos != null && painelConquistas != null && painelIdiomas != null)
        {
            painelConquistas.SetActive(false);
            painelIdiomas.SetActive(false);
            painelCreditos.SetActive(false);
        }
    }
    public void PainelEstasticas()
    {
        painelEstatisticas.SetActive(true);
        //pC.jogadorAbriuEstatisticas = true;
        pC.TelaAtivada();
    }
    public void PainelCreditos()
    {
        painelCreditos.SetActive(true);
    }
    public void PainelIdiomas()
    {
        painelIdiomas.SetActive(true);
    }
    public void PainelConquistas()
    {
        painelConquistas.SetActive(true);
    }
    public void PainelResolucoes()
    {
        painelResolucoes.SetActive(true);
    }

    public void PainelControles()
    {
        painelControles.SetActive(true);
    }

    public void PainelGraficos()
    {
        painelGraficos.SetActive(true);
    }

    public void PainelAudio()
    {
        painelAudio.SetActive(true);
    }

    public void JogoSalvo()
    {
        SceneManager.LoadScene(cenaFases);
    }

    public void BotaoVoltar()
    {
        SceneManager.LoadScene(voltarCena);   
    }

    public void BotaoNovoJogo()
    {
        RemoveJogoSalvo();

        StartCoroutine(Cerregamento());
    }

    public IEnumerator Cerregamento()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(novoJogo);
    }

    public void RemoveJogoSalvo()
    {
        string caminho = Application.persistentDataPath;

        if (File.Exists(caminho + "/labbitJogoSalvo.save"))
        {
            File.Delete(caminho + "/labbitJogoSalvo.save");
        }
    }
    
}
