using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class Seleciona_Itens : MonoBehaviour
{
    public int contagem = 0;

    [SerializeField] Inventario inventario;

    [SerializeField] Atirar_Cenoura atirarCenoura;

    [SerializeField] InterfaceTextos interfaceTextos;

    [SerializeField] Player_Vida playerVida;

    public TextMeshProUGUI itemQuantidade;

    public GameObject slotItens;
    public GameObject dicasDaInterface;
    public GameObject setas;
    public AudioClip audioTrocaItem;
    public AudioSource aS;

    Cenoura_Azul cenouraAzul;
    Cenoura_Laranja cenouraLaranja;
    Cenoura_Preta cenouraPreta;
    Cenoura_Verde cenouraVerde;

    Super_CenouraAzul superCenouraAzul;
    Super_CenouraLaranja superCenouraLaranja;
    Super_CenouraPreta superCenouraPreta;
    Super_CenouraVerde superCenouraVerde;

    void Awake()
    {
        cenouraLaranja = GameObject.FindObjectOfType<Cenoura_Laranja>();
        cenouraPreta = GameObject.FindObjectOfType<Cenoura_Preta>();

        superCenouraAzul = GameObject.FindObjectOfType<Super_CenouraAzul>();
        superCenouraLaranja = GameObject.FindObjectOfType<Super_CenouraLaranja>();
        superCenouraPreta = GameObject.FindObjectOfType<Super_CenouraPreta>();
        superCenouraVerde = GameObject.FindObjectOfType<Super_CenouraVerde>();
    }

    void Update()
    {
        if (inventario.listaItens.Count > 0)
        {
            if(cenouraLaranja.GetQuantidade() > 0 || cenouraPreta.GetQuantidade() > 0 || superCenouraAzul.GetQuantidade() > 0 || superCenouraLaranja.GetQuantidade() > 0 || superCenouraPreta.GetQuantidade() > 0 || superCenouraVerde.GetQuantidade() > 0 )
            {
                slotItens.SetActive(true);
                dicasDaInterface.SetActive(true);

                MostraInterface(inventario.listaItens[contagem]);
                InventarioAutomatico(inventario.listaItens[contagem]);
            }
            else 
            {
                slotItens.SetActive(false);
                dicasDaInterface.SetActive(false);
                playerVida.BarraDeApoio(false, 0);
                setas.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown("joystick button 9")) //Ao pressionar F o contador conta +1
        {
            if (contagem < inventario.listaItens.Count)
            {
                contagem++;

                if (inventario.listaItens.Count > 1)
                {
                    aS.clip = audioTrocaItem;
                    aS.Play();
                }
            }
        }

        if (inventario.listaItens.Count > 1)
        {
            setas.SetActive(true);
        }

            if (contagem == inventario.listaItens.Count) // Zera Contagem
        {
            contagem = 0;
        }
    }

    public void TraducaoDica(Item _cenoura)
    {
        string idioma = LocalizationSettings.SelectedLocale.Identifier.Code;

        if (_cenoura.GetNome() == "Super Cenoura Preta")
        {
            switch (idioma)
            {
                case "en":
                case "en-US":
                    _cenoura.SetHabilidade("[X] Piercing Attack [C] Activate Revive");
                    break;

                case "de":
                case "de-DE":
                    _cenoura.SetHabilidade("[X] Durchdringender Angriff [C] Wiederbeleben aktivieren");
                    break;

                case "es-AR":
                    _cenoura.SetHabilidade("[X] Ataque Perforante [C] Activa Resucitar");
                    break;

                case "pt":
                case "pt-BR":
                    _cenoura.SetHabilidade("[X] Ataque Perfurante [C] Ativa Ressuscitar");
                    break;

                default:
                    _cenoura.SetHabilidade("[X] Ataque Perfurante [C] Ativa Ressuscitar");
                    break;
            }
        }
        else if (_cenoura.GetNome() == "Super Cenoura Laranja")
        {
            switch (idioma)
            {
                case "en":
                case "en-US":
                    _cenoura.SetHabilidade("[X] When Hitting Target, Heals You [C] Activate Regenerate");
                    break;

                case "de":
                case "de-DE":
                    _cenoura.SetHabilidade("[X] Wenn Ziel getroffen, heilt es dich [C] Regenerieren aktivieren");
                    break;

                case "es-AR":
                    _cenoura.SetHabilidade("[X] Al Impactar el Objetivo, Te Cura [C] Activa Regenerar");
                    break;

                case "pt":
                case "pt-BR":
                    _cenoura.SetHabilidade("[X] Ao Atintir Alvo, Te Cura [C] Ativa Regenerar");
                    break;

                default:
                    _cenoura.SetHabilidade("[X] Ao Atintir Alvo, Te Cura [C] Ativa Regenerar");
                    break;
            }
        }
        else if (_cenoura.GetNome() == "Super Cenoura Azul")
        {
            switch (idioma)
            {
                case "en":
                case "en-US":
                    _cenoura.SetHabilidade("[X] Target Disappears for Moments [C] Immunity to Lasers");
                    break;

                case "de":
                case "de-DE":
                    _cenoura.SetHabilidade("[X] Ziel verschwindet für kurze Zeit [C] Immunität gegen Laser");
                    break;

                case "es-AR":
                    _cenoura.SetHabilidade("[X] Objetivo Desaparece Por Instantes [C] Inmunidad a Láseres");
                    break;

                case "pt":
                case "pt-BR":
                    _cenoura.SetHabilidade("[X] Alvo Some Por Instantes [C] Imunidade a Lasers");
                    break;

                default:
                    _cenoura.SetHabilidade("[X] Alvo Some Por Instantes [C] Imunidade a Lasers");
                    break;
            }
        }
        else if (_cenoura.GetNome() == "Super Cenoura Verde")
        {
            switch (idioma)
            {
                case "en":
                case "en-US":
                    _cenoura.SetHabilidade("[X] Attack [C] Immunity to Toxicity");
                    break;

                case "de":
                case "de-DE":
                    _cenoura.SetHabilidade("[X] Angriff [C] Immunität gegen Gift");
                    break;

                case "es-AR":
                    _cenoura.SetHabilidade("[X] Ataque [C] Inmunidad a Toxicidad");
                    break;

                case "pt":
                case "pt-BR":
                    _cenoura.SetHabilidade("[X] Ataque [C] Imunidade a Toxicidade");
                    break;

                default:
                    _cenoura.SetHabilidade("[X] Ataque [C] Imunidade a Toxicidade");
                    break;
            }
        }
        else
        {
            switch (idioma)
            {
                case "en":
                case "en-US":
                    _cenoura.SetHabilidade("[X] Attack [C] Heal Life");
                    break;

                case "de":
                case "de-DE":
                    _cenoura.SetHabilidade("[X] Angreifen [C] Leben heilen");
                    break;

                case "es-AR":
                    _cenoura.SetHabilidade("[X] Atacar [C] Curar Vida");
                    break;

                case "pt":
                case "pt-BR":
                    _cenoura.SetHabilidade("[X] Atacar [C] Curar Vida");
                    break;

                default:
                    _cenoura.SetHabilidade("[X] Atacar [C] Curar Vida");
                    break;
            }
        }
    }

    bool MostraInterface(Item itemSelecionado)
    {
        foreach (Item item in inventario.listaItens) // Procura na lista de itens o novo item
        {
            if (item.GetNome() == itemSelecionado.GetNome()) // Verifica se ja existe um item com esse nome
            {
                itemQuantidade.text = "" + itemSelecionado.GetQuantidade();

                TraducaoDica(item);

                interfaceTextos.SetRecebeMenssagem(item.GetHabilidade());

                playerVida.BarraDeApoio(true, itemSelecionado.GetCura());
            }
        }

        return false;
    }

    

    bool InventarioAutomatico(Item itemSelecionado)
    {
        if (itemSelecionado.GetQuantidade() < 1)
        {
            contagem++;

            return false;
        }

        foreach (Item item in inventario.listaItens)
        {
            if (item.GetNome() == itemSelecionado.GetNome())
            {
                atirarCenoura.SetItem(itemSelecionado);
                atirarCenoura.SetPodeAtirar(true);
            }
        }

        return false;
    }

    /*
    void VerificaCenouras()
    {
        switch (inventario.listaItens[contagem].GetNome())
        {
            case "Cenoura Laranja":

                atirarCenoura.SetItem(cenouraLaranja);

                atirarCenoura.SetPodeAtirar(true);

                break;

            case "Cenoura Preta":

                atirarCenoura.SetItem(cenouraPreta);

                atirarCenoura.SetPodeAtirar(true);

                break;


            case "Super Cenoura Azul":

                if (iT.GetEsperaMenssagem() == false)
                {
                    iT.SetRecebeMenssagem("[C] Ativar Imunidade Ultravioleta [X] para Atacar");
                }

                atirarCenoura.SetItem(superCenouraAzul);
                atirarCenoura.SetPodeAtirar(true);

                itemQuantidade.text = "" + superCenouraAzul.GetQuantidade();

                playerVida.BarraDeApoio(false, 0);

                if (superCenouraAzul.GetQuantidade() < 1)
                {
                    contagem++;
                }

                break;

            case "Super Cenoura Laranja":

                if (iT.GetEsperaMenssagem() == false)
                {
                    iT.SetRecebeMenssagem("[C] Ativar Regenera??o [X] para Atacar");
                }

                atirarCenoura.SetItem(superCenouraLaranja);
                atirarCenoura.SetPodeAtirar(true);

                itemQuantidade.text = "" + superCenouraLaranja.GetQuantidade();

                playerVida.BarraDeApoio(false, 0);

                if (superCenouraLaranja.GetQuantidade() < 1)
                {
                    contagem++;
                }

                break;

            case "Super Cenoura Preta":

                if (iT.GetEsperaMenssagem() == false)
                {
                    iT.SetRecebeMenssagem("[C] Ativar Ressuscitar [X] para Atacar");
                }

                atirarCenoura.SetItem(superCenouraPreta);
                atirarCenoura.SetPodeAtirar(true);

                itemQuantidade.text = "" + superCenouraPreta.GetQuantidade();

                playerVida.BarraDeApoio(false, 0);

                if (superCenouraPreta.GetQuantidade() < 1)
                {
                    contagem++;
                }

                break;

            case "Super Cenoura Verde":

                if (iT.GetEsperaMenssagem() == false)
                {
                    iT.SetRecebeMenssagem("[C] Ativar Imunidade Toxicidade [X] para Atacar");
                }

                atirarCenoura.SetItem(superCenouraVerde);
                atirarCenoura.SetPodeAtirar(true);

                itemQuantidade.text = "" + superCenouraVerde.GetQuantidade();

                playerVida.BarraDeApoio(false, 0);

                if (superCenouraVerde.GetQuantidade() < 1)
                {
                    contagem++;
                }

                break;
        }
    }
    /*
    public List<string> nomeItens = new List<string>();

    public int contagem = 0;

    [SerializeField] private Inventario inventario;

    [SerializeField] private Atirar_Cenoura atirarCenoura;

    [SerializeField] private InterfaceTextos iT;

    [SerializeField] private Player_Vida playerVida;

    Cenoura_Azul cenouraAzul;
    Cenoura_Laranja cenouraLaranja;
    Cenoura_Preta cenouraPreta;
    Cenoura_Verde cenouraVerde;

    Super_CenouraAzul superCenouraAzul;
    Super_CenouraLaranja superCenouraLaranja;
    Super_CenouraPreta superCenouraPreta;
    Super_CenouraVerde superCenouraVerde;

    public void Awake()
    {
        atirarCenoura = GameObject.FindObjectOfType<Atirar_Cenoura>();

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
        if (inventario.listaItens.Count > 0)
        {
            if (cenouraAzul.GetQuantidade() > 0 || cenouraLaranja.GetQuantidade() > 0 || cenouraPreta.GetQuantidade() > 0 || cenouraVerde.GetQuantidade() > 0 || superCenouraAzul.GetQuantidade() > 0 || superCenouraLaranja.GetQuantidade() > 0 || superCenouraPreta.GetQuantidade() > 0 || superCenouraVerde.GetQuantidade() > 0)
            {
                Filtro(inventario.listaItens[contagem]);
                VerificaCenouras();
            }
        }

        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown("joystick button 9")) //Ao pressionar F o contador conta +1
        { 
            if (contagem < inventario.listaItens.Count)
            {
                iT.SetEsperaMenssagem(false);
                contagem++;
            }
        }

        if (contagem == inventario.listaItens.Count)
        {
            contagem = 0;
        }
    }
    bool Filtro(Item itemSelecionado)
    {
        foreach (Item item in inventario.listaItens) // Procura na lista de itens o novo item
        {
            if (item.GetNome() == itemSelecionado.GetNome()) // Verifica se ja existe um item com esse nome
            {
                //Debug.Log("Foreach Nome Item: " + item.GetNome() + " Item Selecionado Nome : " + itemSelecionado.GetNome());

                if (iT.GetEsperaMenssagem() == false)
                {
                    iT.SetRecebeMenssagem("[X] para Atacar [C] para Curar");
                }

                atirarCenoura.SetNome(inventario.listaItens[contagem].GetNome());
                Debug.Log("Nome Cenoura Coringa : " + inventario.listaItens[contagem].GetNome());

                atirarCenoura.SetPodeAtirar(true);

                playerVida.BarraDeApoio(true, itemSelecionado.GetCura());
            }
        }

        return false;
    }
    void VerificaCenouras()
    {
        switch (inventario.listaItens[contagem].GetNome())
        {
            case "Cenoura Laranja":

                atirarCenoura.SetQuantidade(cenouraLaranja.GetQuantidade());

                break;

            case "Cenoura Preta":

                atirarCenoura.SetQuantidade(cenouraPreta.GetQuantidade());

                break;

            case "Super Cenoura Azul":

                atirarCenoura.SetQuantidade(superCenouraAzul.GetQuantidade());

                break;

            case "Super Cenoura Laranja":

                atirarCenoura.SetQuantidade(superCenouraLaranja.GetQuantidade());

                break;

            case "Super Cenoura Preta":

                atirarCenoura.SetQuantidade(superCenouraPreta.GetQuantidade());

                break;

            case "Super Cenoura Verde":

                atirarCenoura.SetQuantidade(superCenouraVerde.GetQuantidade());

                break;

        }
    }
    */

}

