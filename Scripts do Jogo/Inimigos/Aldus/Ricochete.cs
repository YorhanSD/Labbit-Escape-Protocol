using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ricochete : MonoBehaviour
{
    public GameObject serra;
    public Transform pontoDisparo;
    public Transform posicaoPlayer;
    public bool ladoDireito;
    private bool podeDisparar = true;
    

    void Flip()
    {
        if (gameObject.transform.position.x < posicaoPlayer.transform.position.x)
        {
            ladoDireito = true;
        }
        else
        {
            ladoDireito = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Serra" && podeDisparar == true) 
        {
            StartCoroutine(Recarregar());

            Flip();

            SerraMovimento();
        }
    }

    public void SerraMovimento()
    {
        GameObject serraTemp = (GameObject)(Instantiate(serra, pontoDisparo.transform.position, Quaternion.identity));

        if (ladoDireito)
        {
            serraTemp.GetComponent<Seringa>().Inicializar(Vector2.right);
        }
        else
        {
            //Direciona a cenoura conforme a direcao que o personagem aponta
            //Importa o void inicializar com o componente de direcao do script da cenoura
            serraTemp.GetComponent<Seringa>().Inicializar(Vector2.left);
        }
    }

    public IEnumerator Recarregar()
    {
        podeDisparar = false;

        yield return new WaitForSecondsRealtime(1);

        podeDisparar = true;
    }

}
