using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma_Horizontal : Movimento
{
    private void Start()
    {
        SetPodeAndar(true);
    }
    void FixedUpdate()
    {
        MovimentoHorizontalPlataforma();
    }

    public override bool MovimentoHorizontalPlataforma()
    {
        return base.MovimentoHorizontalPlataforma();
    }
}
