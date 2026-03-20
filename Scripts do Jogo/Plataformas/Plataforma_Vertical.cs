using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma_Vertical : Movimento
{
    void FixedUpdate()
    {
        MovimentoVertical(); //Plataformas devem usar FixedUpdate e Rigidbody com Kinematic
    }

    public override bool MovimentoVertical()
    {
        return base.MovimentoVertical();
    }

}
