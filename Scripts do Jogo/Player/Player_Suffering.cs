using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Suffering : MonoBehaviour
{
    public Animator anim;

    [SerializeField] private Player_Movimento playerMovimento;
    [SerializeField] private Aldus_Especial aldusEspecial;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void SofrendoDano()
    {
        anim.SetTrigger("Suffering");
        aldusEspecial.Celebrating();
    }

    public void PlayerParalizado()
    {
        playerMovimento.SetPlayerImobilizado(true);
    }
}
