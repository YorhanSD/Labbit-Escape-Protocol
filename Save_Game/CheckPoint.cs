using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject player;
    public GameObject feedbackSalvamento;

    public bool podeAbrir;

    private void Awake()
    {
        carregaJogoSalvo();
    }
    public void carregaJogoSalvo()
    {
        SaveGame carregar = JogoSalvo();

        if (carregar != null && carregar.GetJaJogou())
        {
            player.transform.position = new Vector2(
                carregar.GetPlayerPosicaoX(),
                carregar.GetPlayerPosicaoY()
            );
        }
    }

    private void OnTriggerEnter2D(Collider2D _check)
    {
        if (_check.gameObject.tag == "Player")
        {
            Salvar();
            feedbackSalvamento.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D _check)
    {
        if (_check.gameObject.tag == "Player")
        {
            feedbackSalvamento.SetActive(false);
        }
    }
    public void SalvaCronometro(int _cronometro)
    {
        SaveGame save = JogoSalvo();
        if (save == null)
            save = new SaveGame();

        save.minuto = _cronometro;

        SalvarJogoBinario(save);
    }

    public void SalvaNumeroDeVezesQueMorreu(int _numero)
    {
        SaveGame save = JogoSalvo();
        if (save == null)
            save = new SaveGame();

        save.saveMortes = _numero;

        SalvarJogoBinario(save);
    }

    public void SalvaCenouraColetadas(int _numero)
    {
        SaveGame save = JogoSalvo();
        if (save == null)
            save = new SaveGame();

        save.saveCenourasColetadas = _numero;

        SalvarJogoBinario(save);
    }

    public void SalvaInimigosAbatidos(int _numero)
    {
        SaveGame save = JogoSalvo();
        if (save == null)
            save = new SaveGame();

        save.saveInimigosAbatidos = _numero;

        SalvarJogoBinario(save);
    }

    public void SalvaDNAsColetados(int _numero)
    {
        SaveGame save = JogoSalvo();
        if (save == null)
            save = new SaveGame();

        save.saveDNAsColetados = _numero;

        SalvarJogoBinario(save);
    }

    public void SalvarConquistaI()
    {
        SalvarConquista(save => save.conquistaIfeita = true);
    }

    public void SalvarConquistaII()
    {
        SalvarConquista(save => save.conquistaIIfeita = true);
    }

    public void SalvarConquistaIII()
    {
        SalvarConquista(save => save.conquistaIIIfeita = true);
    }

    public void SalvarConquistaIV()
    {
        SalvarConquista(save => save.conquistaIVfeita = true);
    }

    public void SalvarConquistaV()
    {
        SalvarConquista(save => save.conquistaVfeita = true);
    }

    public void SalvarConquistaVI()
    {
        SalvarConquista(save => save.conquistaVIfeita = true);
    }

    public void SalvarConquistaVII()
    {
        SalvarConquista(save => save.conquistaVIIfeita = true);
    }

    public void SalvarConquistaVIII()
    {
        SalvarConquista(save => save.conquistaVIIIfeita = true);
    }
    public void SalvarConquistaIX()
    {
        SalvarConquista(save => save.conquistaIXfeita = true);
    }

    private void SalvarConquista(System.Action<SaveGame> aplicaConquista)
    {
        SaveGame save = JogoSalvo();
        if (save == null)
            save = new SaveGame();

        aplicaConquista(save);

        SalvarJogoBinario(save);
    }

    public void Salvar()
    {
        //Carrega save existente ou cria um novo
        SaveGame save = JogoSalvo();
        if (save == null)
            save = new SaveGame();

        //Salva dados básicos
        save.SetJaJogou(true);
        save.SetPlayerPosicaoX(player.transform.position.x);
        save.SetPlayerPosicaoY(player.transform.position.y);

        // AGORA SIM salva no disco
        SalvarJogoBinario(save);

    }

    public void SalvarJogoBinario(SaveGame _newSave)
    {
        BinaryFormatter bF = new BinaryFormatter();

        string caminho = Application.persistentDataPath;//AppData/LocalLow/SeuNome

        FileStream arquivo = File.Create(caminho + "/labbitJogoSalvo.save");

        bF.Serialize(arquivo, _newSave);

        arquivo.Close();

        Debug.Log("Jogo Salvo!");
    }
    public SaveGame JogoSalvo()
    {
        BinaryFormatter bF = new BinaryFormatter();

        string caminho = Application.persistentDataPath;

        FileStream arquivo;

        if (File.Exists(caminho + "/labbitJogoSalvo.save"))
        {
            arquivo = File.Open(caminho + "/labbitJogoSalvo.save", FileMode.Open);

            SaveGame carrega = (SaveGame)bF.Deserialize(arquivo);

            arquivo.Close();

            Debug.Log("Jogo Carregado");

            return carrega;
        }

        return null;
    }

}
