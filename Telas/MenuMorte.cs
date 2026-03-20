using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMorte : MonoBehaviour
{
    Ativa_JogoSalvo ajs;
    public GameObject telaMorte;
    public GameObject telaPergunta;
    public string restart;
    public string telaInicial;

    public void Start()
    {
        ajs = GetComponent<Ativa_JogoSalvo>();
    }
    public void AtivaTelaMorte()
    {
        Time.timeScale = 0f;
        telaMorte.SetActive(true);
    }
    public void BotaoCancelar()
    {
        telaPergunta.SetActive(false);
    }
    public void BotaoReiniciar()
    {
        SceneManager.LoadScene(restart);
    }
    public void BotaoAbrirPergunta()
    {
        telaPergunta.SetActive(true);
    }

    public void BotaoSairJogo()
    {
        // Editor unity
        //UnityEditor.EditorApplication.isPlaying = false;

        //Jogo compilado - comentar a linha acima e descomentar a debaixo antes de gerar a build
        Application.Quit();
        //Debug.Log("Saiu");
    }
    public void BotaoMenuInicial()
    {
        SceneManager.LoadScene(telaInicial);
    }
}
