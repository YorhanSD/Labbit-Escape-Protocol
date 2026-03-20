using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinho_Dano : MonoBehaviour
{
    public int danoEspinho = 50;

    [SerializeField] Controle_Emocional controleEmocional;
    [SerializeField] Player_Vida playerVida;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && playerVida.GetImuneDano() == false)
        {
            playerVida.SetImuneDano(true);

            playerVida.barraDeVida.value -= danoEspinho;

            controleEmocional.Medo(50);

        }
    }
}
