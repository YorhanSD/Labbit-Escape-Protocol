using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Patrulha : Movimento
{
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
        if (GetPodeAndar() == true)
        {
            MovimentoHorizontalInimigo();
        }
    }
    public override bool MovimentoHorizontalInimigo()
    {
        if (GetPodeAndar() == true)
        {
            return base.MovimentoHorizontalInimigo();
        }

        return false;
    }
}
