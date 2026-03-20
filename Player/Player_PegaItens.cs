using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_PegaItens : MonoBehaviour
{
    [SerializeField] private Cria_Itens criaItens;
    public bool pegouChave;
    public AudioSource aS;
    public AudioClip somChave;
    public PontuacaoControle pC;

    [System.Obsolete]
    public void Start()
    {
        pC = FindObjectOfType<PontuacaoControle>();
    }

    private void OnTriggerEnter2D(Collider2D _Player)
    {
        if (_Player.gameObject.tag == "CenouraLaranja")
        {
            criaItens.CriaCenouraLaranja();
            pC.AdicionaPontosPorColetaCenoura(250);
            pC.MostraTotalDePontos();
        }
        if (_Player.gameObject.tag == "CenouraPreta")
        {
            criaItens.CriaCenouraPreta();
            pC.AdicionaPontosPorColetaCenoura(250);
            pC.MostraTotalDePontos();
        }
        if (_Player.gameObject.tag == "DNA Azul")
        {
            criaItens.CriaDNAAzul();
            pC.AdicionaPontoPorDNAsColetados(500);
            pC.MostraTotalDePontos();
        }
        if (_Player.gameObject.tag == "DNA Laranja")
        {
            criaItens.CriaDNALaranja();
            pC.AdicionaPontoPorDNAsColetados(500);
            pC.MostraTotalDePontos();
        }
        if (_Player.gameObject.tag == "DNA Preto")
        {
            criaItens.CriaDNAPreto();
            pC.AdicionaPontoPorDNAsColetados(500);
            pC.MostraTotalDePontos();
        }
        if (_Player.gameObject.tag == "DNA Verde")
        {
            criaItens.CriaDNAVerde();
            pC.AdicionaPontoPorDNAsColetados(500);
            pC.MostraTotalDePontos();
        }
        if (_Player.gameObject.tag == "Chave")
        {
            pegouChave = true;
            Debug.Log("Pegou a Chave!");
            aS.clip = somChave;
            aS.Play();
        }

    }
}
