using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public List<Item> listaItens = new List<Item>();

    [SerializeField] private Cria_Itens criaItens;

    public bool AdicionaItem(Item _novoItem)
    {
        Checagem(_novoItem); //Checa para ver se o item e repetido

        return true;
    }

    public bool TiraItem(Item _novoItem, int _quantidade) //Tira o item pedido de acordo com a quantidade pedida
    {
        //ItemQuantidadeControle(_novoItem, quantidade); 
        _novoItem.SetQuantidade(-1);

        return true;
    }

    public bool Checagem(Item _novoItem)
    {
        foreach (Item item in listaItens) // Procura na lista de itens o novo item
        {
            if (item.GetNome() == _novoItem.GetNome()) // Verifica se ja existe um item com esse nome
            {
                Debug.Log("O item é repetido");
                //ItemQuantidadeControle(_novoItem, ); // Controla a quantidade dos itens
                return false;
            }
        }

        // Se o item nao existir adicione-o a lista

        Debug.Log("O item não é repetido");
        listaItens.Add(_novoItem);
        //ItemQuantidadeControle(_novoItem, 1);
        return false;
    }

    /*
    public void ItemQuantidadeControle(Item _novoItem, int _quantidade)
    {
        if (_novoItem.GetNome() != null) //Se o nome do item for diferente de nulo :
        {
            if (_novoItem.GetNome() == "Cenoura Laranja")
            {
                GameObject.FindGameObjectWithTag("CenouraLaranja").GetComponent<Cenoura_Laranja>().SetQuantidade(_quantidade);
            }
            else if (_novoItem.GetNome() == "Cenoura Preta")
            {
                GameObject.FindGameObjectWithTag("CenouraPreta").GetComponent<Cenoura_Preta>().SetQuantidade(_quantidade);
            }
            else if (_novoItem.GetNome() == "Super Cenoura Azul")
            {
                GameObject.FindGameObjectWithTag("SuperCenouraAzul").GetComponent<Super_CenouraAzul>().SetQuantidade(_quantidade);
            }
            else if (_novoItem.GetNome() == "Super Cenoura Laranja")
            {
                GameObject.FindGameObjectWithTag("SuperCenouraLaranja").GetComponent<Super_CenouraLaranja>().SetQuantidade(_quantidade);
            }
            else if (_novoItem.GetNome() == "Super Cenoura Preta")
            {
                GameObject.FindGameObjectWithTag("SuperCenouraPreta").GetComponent<Super_CenouraPreta>().SetQuantidade(_quantidade);
            }
            else if (_novoItem.GetNome() == "Super Cenoura Verde")
            {
                GameObject.FindGameObjectWithTag("SuperCenouraVerde").GetComponent<Super_CenouraVerde>().SetQuantidade(_quantidade);
            }
            else if (_novoItem.GetNome() == "DNA Azul")
            {
                dnaAzul.SetQuantidade(_quantidade);

                if (dnaAzul.GetQuantidade() > 1)
                {
                    criaItens.CriaSuperCenouraAzul();

                    TiraItem(_novoItem, -2);
                }
            }
            else if (_novoItem.GetNome() == "DNA Laranja")
            {
                dnaLaranja.SetQuantidade(_quantidade);

                if (dnaLaranja.GetQuantidade() > 1)
                {
                    criaItens.CriaSuperCenouraLaranja();
                    TiraItem(_novoItem, -2);
                }
            }
            else if (_novoItem.GetNome() == "DNA Preto")
            {
                dnaPreto.SetQuantidade(_quantidade);

                if (dnaPreto.GetQuantidade() > 1)
                {
                    criaItens.CriaSuperCenouraPreta();
                    TiraItem(_novoItem, -2);
                }
            }
            else if (_novoItem.GetNome() == "DNA Verde")
            {
                dnaVerde.SetQuantidade(_quantidade);

                if (dnaVerde.GetQuantidade() > 1)
                {
                    criaItens.CriaSuperCenouraVerde();
                    TiraItem(_novoItem, -2);
                }
            }
            
        }
    */

}
