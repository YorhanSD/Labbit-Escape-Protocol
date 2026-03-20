using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class UI_ItemQuantidade : MonoBehaviour
{
    [SerializeField] private Cenoura_Azul cenouraAzul;
    [SerializeField] private Cenoura_Laranja cenouraLaranja;
    [SerializeField] private Cenoura_Preta cenouraPreta;
    [SerializeField] private Cenoura_Verde cenouraVerde;

    [SerializeField] private Super_CenouraAzul superCenouraAzul;
    [SerializeField] private Super_CenouraLaranja superCenouraLaranja;
    [SerializeField] private Super_CenouraPreta superCenouraPreta;
    [SerializeField] private Super_CenouraVerde superCenouraVerde;

    public GameObject player;
   
    public GameObject[] imagens;

    void TextoCenouraQuantidade()
    {
        

    }
    void ControleQuantidade()
    {
        //MudaCorCenouraAzul();
        //MudaCorCenouraLaranja();
        //MudaCorCenouraPreta();
        //MudaCorCenouraVerde();

        //MudaCorSuperCenouraAzul();
        //MudaCorSuperCenouraLaranja();
        //MudaCorSuperCenouraPreta();
        //MudaCorSuperCenouraVerde();
    }

    private bool MudaCorCenouraAzul()
    {
        if (cenouraAzul.GetQuantidade() > 0)
        {
            imagens[0].SetActive(true);

            return false;
        }

        imagens[0].SetActive(false);

        return false;
    }
    private bool MudaCorCenouraLaranja()
    {
        if (cenouraLaranja.GetQuantidade() > 0)
        {
            imagens[1].SetActive(true);

            return false;
        }

        imagens[1].SetActive(false);

        return false;
    }
    private bool MudaCorCenouraPreta()
    {
        if (cenouraPreta.GetQuantidade() > 0)
        {
            imagens[2].SetActive(true);

            return false;
        }

        imagens[2].SetActive(false);

        return false;
    }
    private bool MudaCorCenouraVerde()
    {
        if (cenouraVerde.GetQuantidade() > 0)
        {
            imagens[3].SetActive(true);

            return false;
        }

        imagens[3].SetActive(false);

        return false;
    }

    private bool MudaCorSuperCenouraAzul()
    {
        if(superCenouraAzul.GetQuantidade() > 0)
        {
            imagens[4].SetActive(true);

            return false;
        }

        imagens[4].SetActive(false);

        return false;
    }

    private bool MudaCorSuperCenouraLaranja()
    {
        if (superCenouraLaranja.GetQuantidade() > 0)
        {
            imagens[5].SetActive(true);

            return false;
        }

        imagens[5].SetActive(false);

        return false;
    }

    private bool MudaCorSuperCenouraPreta()
    {
        if (superCenouraPreta.GetQuantidade() > 0)
        {
            imagens[6].SetActive(true);

            return false;
        }

        imagens[6].SetActive(false);

        return false;
    }

    private bool MudaCorSuperCenouraVerde()
    {
        if (superCenouraVerde.GetQuantidade() > 0)
        {
            imagens[7].SetActive(true);

            return false;
        }

        imagens[7].SetActive(false);

        return false;
    }
}
