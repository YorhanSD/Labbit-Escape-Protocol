using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class Cria_Itens : MonoBehaviour
{
    [SerializeField] private Inventario inventario;

    [SerializeField] private InterfaceTextos iT;

    public AudioSource aS;
    public AudioClip criaSuper;
    public AudioClip closeBag;
    public AudioClip dna;

    private Cenoura_Laranja cenouraLaranja;
    private Cenoura_Preta cenouraPreta;

    private Super_CenouraAzul superCenouraAzul;
    private Super_CenouraLaranja superCenouraLaranja;
    private Super_CenouraVerde superCenouraVerde;
    private Super_CenouraPreta superCenouraPreta;

    DNA_Azul dnaAzul;
    DNA_Laranja dnaLaranja;
    DNA_Verde dnaVerde;
    DNA_Preto dnaPreto;

    [System.Obsolete]
    private void Awake()
    {
        cenouraLaranja = GameObject.FindObjectOfType<Cenoura_Laranja>();
        cenouraPreta = GameObject.FindObjectOfType<Cenoura_Preta>();

        superCenouraAzul = GameObject.FindObjectOfType<Super_CenouraAzul>();
        superCenouraLaranja = GameObject.FindObjectOfType<Super_CenouraLaranja>();
        superCenouraVerde = GameObject.FindObjectOfType<Super_CenouraVerde>();
        superCenouraPreta = GameObject.FindObjectOfType<Super_CenouraPreta>();

        dnaAzul = GameObject.FindObjectOfType<DNA_Azul>();
        dnaLaranja = GameObject.FindObjectOfType<DNA_Laranja>();
        dnaPreto = GameObject.FindObjectOfType<DNA_Preto>();
        dnaVerde = GameObject.FindObjectOfType<DNA_Verde>();

    }

    

    public void CriaCenouraLaranja()
    {
        cenouraLaranja.SetNome("Cenoura Laranja");
        cenouraLaranja.SetQuantidade(3);
        //cenouraLaranja.SetHabilidade("[X] Atacar [C] Curar Vida");
        //TraducaoDica(cenouraLaranja);

        //iT.SetRecebeMenssagem("[X] Atacar [C] Curar Vida");

        if (inventario != null)
        {
            inventario.AdicionaItem(cenouraLaranja);
            SomPegouCenouraNormal();
        }

    }

    public void CriaCenouraPreta()
    {
        cenouraPreta.SetNome("Cenoura Preta");
        cenouraPreta.SetQuantidade(3);
        //cenouraPreta.SetHabilidade("[X] Atacar [C] Curar Vida");
        //TraducaoDica(cenouraPreta);

        //iT.SetRecebeMenssagem("[X] Atacar [C] Curar Vida");

        if (inventario != null)
        {
            inventario.AdicionaItem(cenouraPreta);
            SomPegouCenouraNormal();
        }

    }
    public void SomPegouCenouraNormal()
    {
        aS.clip = closeBag;
        aS.Play();
    }
    public void SomCriaSuper()
    {
        aS.clip = criaSuper;
        aS.Play();
    }
    public void SomCriaDNA()
    {
        aS.clip = dna;
        aS.Play();
    }
    public void CriaSuperCenouraAzul()
    {
        superCenouraAzul.SetNome("Super Cenoura Azul");
        superCenouraAzul.SetQuantidade(1);
        //superCenouraAzul.SetHabilidade("[X] Atacar [C] Imunidade a Laser");
        //TraducaoDica(superCenouraAzul);

        //iT.SetRecebeMenssagem("[X] Atacar [C] Ativa Imunidade Ultravioleta");

        if (inventario != null)
        {
            inventario.AdicionaItem(superCenouraAzul);
            SomCriaSuper();
        }
    }

    public void CriaSuperCenouraLaranja()
    {
        superCenouraLaranja.SetNome("Super Cenoura Laranja");
        superCenouraLaranja.SetQuantidade(1);
        //superCenouraLaranja.SetHabilidade("[X] Atacar [C] Ativa Regenerar");
        //TraducaoDica(superCenouraLaranja);

        //iT.SetRecebeMenssagem("[X] Atacar [C] Ativa Regenerar");

        if (inventario != null)
        {
            inventario.AdicionaItem(superCenouraLaranja);
            SomCriaSuper();
        }
    }

    public void CriaSuperCenouraPreta()
    {
        superCenouraPreta.SetNome("Super Cenoura Preta");
        superCenouraPreta.SetQuantidade(1);
        //superCenouraPreta.SetHabilidade("[X] Atacar [C] Ativa Ressuscitar");
        //TraducaoDica(superCenouraPreta);

        //iT.SetRecebeMenssagem("[X] Atacar [C] Ativa Ressuscitar");

        if (inventario != null)
        {
            inventario.AdicionaItem(superCenouraPreta);
            SomCriaSuper();
        }
    }

    public void CriaSuperCenouraVerde()
    {
        superCenouraVerde.SetNome("Super Cenoura Verde");
        superCenouraVerde.SetQuantidade(1);
        //superCenouraVerde.SetHabilidade("[X] Atacar [C] Ativa Imunidade a Toxicidade");
        //TraducaoDica(superCenouraVerde);

        //iT.SetRecebeMenssagem("[X] Atacar [C] Ativa Imunidade a Toxicidade");

        if (inventario != null)
        {
            inventario.AdicionaItem(superCenouraVerde);
            SomCriaSuper();
        }
    }

    public void CriaDNAAzul()
    {
        dnaAzul.SetNome("DNA Azul");

        Debug.Log("Criou DNA Azul");

        //iT.SetRecebeMenssagem("2x DNA Criam uma Super Cenoura");

        SomCriaDNA();

        if (inventario != null)
        {
            dnaAzul.SetQuantidade(+1);

            if (dnaAzul.GetQuantidade() > 1)
            {
                CriaSuperCenouraAzul();

                dnaAzul.SetQuantidade(-2);
            }
        }
    }

    public void CriaDNALaranja()
    {
        dnaLaranja.SetNome("DNA Laranja");

        Debug.Log("Criou DNA Laranja");

        SomCriaDNA();

        //iT.SetRecebeMenssagem("2x DNA Criam uma Super Cenoura");

        if (inventario != null)
        {
            dnaLaranja.SetQuantidade(+1);

            if (dnaLaranja.GetQuantidade() > 1)
            {
                CriaSuperCenouraLaranja();

                dnaLaranja.SetQuantidade(-2);
            }
        }
    }

    public void CriaDNAPreto()
    {
        dnaPreto.SetNome("DNA Preto");

        Debug.Log("Criou DNA Preto");

        SomCriaDNA();

        //iT.SetRecebeMenssagem("2x DNA Criam uma Super Cenoura");

        if (inventario != null)
        {
            dnaPreto.SetQuantidade(+1);

            if (dnaPreto.GetQuantidade() > 1)
            {
                CriaSuperCenouraPreta();

                dnaPreto.SetQuantidade(-2);
            }
        }
    }

    public void CriaDNAVerde()
    {
        dnaVerde.SetNome("DNA Verde");

        Debug.Log("Criou DNA Verde");

        SomCriaDNA();

        if (inventario != null)
        {
            dnaVerde.SetQuantidade(+1);

            if (dnaVerde.GetQuantidade() > 1)
            {
                CriaSuperCenouraVerde();

                dnaVerde.SetQuantidade(-2);
            }
        }
    }
}
