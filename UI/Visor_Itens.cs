using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Visor_Itens : MonoBehaviour
{
    public GameObject player;

    public int proximoItem = 0;

    public GameObject[] imagemItem;
    public Image imagemSlotDir;
    public Image imagemSlotEsq;

    [SerializeField] private Cenoura_Azul cenouraAzul;
    [SerializeField] private Cenoura_Laranja cenouraLaranja;
    [SerializeField] private Cenoura_Preta cenouraPreta;
    [SerializeField] private Cenoura_Verde cenouraVerde;

    [SerializeField] private Super_CenouraAzul superCenouraAzul;
    [SerializeField] private Super_CenouraLaranja superCenouraLaranja;
    [SerializeField] private Super_CenouraPreta superCenouraPreta;
    [SerializeField] private Super_CenouraVerde superCenouraVerde;

    [SerializeField] private Inventario inventario;
    [SerializeField] private Seleciona_Itens selecionaItens;

    [System.Obsolete]
    void Awake()
    {
        cenouraAzul = GameObject.FindObjectOfType<Cenoura_Azul>();
        cenouraLaranja = GameObject.FindObjectOfType<Cenoura_Laranja>();
        cenouraPreta = GameObject.FindObjectOfType<Cenoura_Preta>();
        cenouraVerde = GameObject.FindObjectOfType<Cenoura_Verde>();

        superCenouraAzul = GameObject.FindObjectOfType<Super_CenouraAzul>();
        superCenouraLaranja = GameObject.FindObjectOfType<Super_CenouraLaranja>();
        superCenouraPreta = GameObject.FindObjectOfType<Super_CenouraPreta>();
        superCenouraVerde = GameObject.FindObjectOfType<Super_CenouraVerde>();
    }

    void Update()
    {
        if (player != null)
        {
            if (inventario != null)
            {
                if (inventario.listaItens.Count > 0)
                {
                    MostraItem();
                }

            }
        }
    }

    void MostraItem()
    {
        //MostraProximoItem();
        
        //MostraMaoKarate();

       // MostraCenouraAzul();
        MostraCenouraLaranja();
        MostraCenouraPreta();
        //MostraCenouraVerde();

        MostraSuperCenouraAzul();
        MostraSuperCenouraLaranja();
        MostraSuperCenouraPreta();
        MostraSuperCenouraVerde();
    }
    /*
    public bool MostraProximoItem()
    {
        proximoItem = selecionaItens.contagem + 1;

        foreach (Item item in inventario.listaItens)
        {
            if(item.GetQuantidade() > 0)
            {
                if (inventario.listaItens.Count > 1)
                {
                    //imagemSlotDir = inventario.listaItens[proximoItem].imagemItem;
                }
            }
            else
            {
                return false;
            }
        }

        return false;
    }
    */

    public bool MostraCenouraLaranja()
    {
        if (inventario.listaItens[selecionaItens.contagem].GetNome() == "Cenoura Laranja" && cenouraLaranja.GetQuantidade() > 0)
        {
            imagemItem[1].SetActive(true);

            return false;
        }

        imagemItem[1].SetActive(false);

        return false;
    }

    public bool MostraCenouraPreta()
    {
        if (inventario.listaItens[selecionaItens.contagem].GetNome() == "Cenoura Preta" && cenouraPreta.GetQuantidade() > 0)
        {
            imagemItem[2].SetActive(true);

            return false;
        }

        imagemItem[2].SetActive(false);

        return false;
    }

  
    public bool MostraSuperCenouraAzul()
    {
        if (inventario.listaItens[selecionaItens.contagem].GetNome() == "Super Cenoura Azul" && superCenouraAzul.GetQuantidade() > 0)
        {
            imagemItem[4].SetActive(true);

            return false;
        }

        imagemItem[4].SetActive(false);

        return false;
    }

    public bool MostraSuperCenouraLaranja()
    {
        if (inventario.listaItens[selecionaItens.contagem].GetNome() == "Super Cenoura Laranja" && superCenouraLaranja.GetQuantidade() > 0)
        {
            imagemItem[5].SetActive(true);

            return false;
        }

        imagemItem[5].SetActive(false);

        return false;
    }

    public bool MostraSuperCenouraPreta()
    {
        if (inventario.listaItens[selecionaItens.contagem].GetNome() == "Super Cenoura Preta" && superCenouraPreta.GetQuantidade() > 0)
        {
            imagemItem[6].SetActive(true);

            return false;
        }

        imagemItem[6].SetActive(false);

        return false;
    }

    public bool MostraSuperCenouraVerde()
    {
        if (inventario.listaItens[selecionaItens.contagem].GetNome() == "Super Cenoura Verde" && superCenouraVerde.GetQuantidade() > 0)
        {
            imagemItem[7].SetActive(true);

            return false;
        }

        imagemItem[7].SetActive(false);

        return false;
    }

    void MostraMaoKarate()
    {
        if (cenouraAzul.GetQuantidade() == 0 && cenouraLaranja.GetQuantidade() == 0 && cenouraPreta.GetQuantidade() == 0 && cenouraVerde.GetQuantidade() == 0 && superCenouraAzul.GetQuantidade() == 0 && superCenouraLaranja.GetQuantidade() == 0 && superCenouraPreta.GetQuantidade() == 0 && superCenouraVerde.GetQuantidade() == 0)
        {
            imagemItem[8].SetActive(true);
        }
        else
        {
            imagemItem[8].SetActive(false);
        }
    }
}
