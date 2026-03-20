using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Dano : MonoBehaviour
{
    public int danoInimigo = 30;

    public AudioSource aS;
    public AudioClip aSClip;

    [SerializeField] private Player_Vida playerVida;
    [SerializeField] private Controle_Emocional controleEmocional;
    [SerializeField] private Player_Suffering playerSuffering;

    public void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    public void SomAttack()
    {
        if (aS != null)
        {
            aS.Stop();
            aS.clip = aSClip;
            aS.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D _player)
    {
        if (_player.CompareTag("Player"))
        {
            if (playerVida.GetImuneDano() != true)
            {
                playerSuffering.SofrendoDano();
                playerVida.SetImuneDano(true);
                playerVida.barraDeVida.value -= danoInimigo;
                controleEmocional.Medo(50);
                playerVida.VerificaVida();
                SomAttack();
            }
        }
    }

}
