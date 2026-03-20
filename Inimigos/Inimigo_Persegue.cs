using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Persegue : Movimento
{
    [SerializeField] private Ataque ataque;
    
    private void Start()
    {
        SetPodeAndar(true);
    }

    public override bool GetPodeAndar()
    {
        return base.GetPodeAndar();
    }

    void FixedUpdate()
    {
        if(GetPodeAndar() == true)
        {
            base.SeguirPlayer();
        }
        else
        {
            base.rigid2D.linearVelocity = Vector2.zero;
        }
    }
}
