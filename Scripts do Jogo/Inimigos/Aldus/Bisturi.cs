using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bisturi : MonoBehaviour
{
    public int dano = 20;
    public float tempoDestruicao = 3f;

    public AudioSource aS;
    public AudioClip swordSlice;
    private Player_Vida playerVida;
    private Player_Suffering pS;

    public void Awake()
    {
        playerVida = FindObjectOfType<Player_Vida>();
        pS = FindObjectOfType<Player_Suffering>();
    }
    public void Start()
    {
        Destruir();
    }
 
    public void OnTriggerEnter2D(Collider2D _player)
    {
        
        if (_player.gameObject.tag == "Player" && playerVida.GetImuneDano() == false)
        {
            pS.SofrendoDano();

            aS.clip = swordSlice;
            aS.Play();
        }
        
    }
   
    void Destruir()
    {
        Destroy(gameObject, tempoDestruicao);
    }
}
