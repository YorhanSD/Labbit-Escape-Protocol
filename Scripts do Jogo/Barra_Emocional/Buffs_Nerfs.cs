using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Buffs_Nerfs : MonoBehaviour
{
    [SerializeField] private BuffNerff_Cenouras buffarAndNerffarCenouras;
    [SerializeField] private Player_Movimento playerMovimento;


    [SerializeField] private Cenoura_Laranja cenouraLaranja;
    [SerializeField] private Cenoura_Preta cenouraPreta;


    [SerializeField] private Super_CenouraAzul superCenouraAzul;
    [SerializeField] private Super_CenouraLaranja superCenouraLaranja;
    [SerializeField] private Super_CenouraVerde superCenouraVerde;
    [SerializeField] private Super_CenouraPreta superCenouraPreta;

    [System.Obsolete]
    public void CoragemMaxima() //Metodo coragem maxima
    {
        playerMovimento.SetPlayerVelocidade(20);
        playerMovimento.SetPlayerForcaPulo(37);

        buffarAndNerffarCenouras.BuffarDanoCenouras();
    }

    [System.Obsolete]
    public void AtributosNormais() //Atributos Padroes
    {
        playerMovimento.SetPlayerVelocidade(14);
        playerMovimento.SetPlayerForcaPulo(33);

        //cenouraLaranja.SetDano(10);
        cenouraLaranja.SetCura(30);

        //cenouraPreta.SetDano(30);
        cenouraPreta.SetCura(10);

        //cenouraVerde.SetDano(20);
        //cenouraVerde.SetCura(20);

        //cenouraAzul.SetDano(30);
        //cenouraAzul.SetCura(30);

        superCenouraLaranja.SetDano(10);
        superCenouraLaranja.SetCura(30);

        superCenouraPreta.SetDano(40);
        superCenouraPreta.SetCura(0);

        superCenouraVerde.SetDano(60);
        superCenouraVerde.SetCura(0);

        superCenouraAzul.SetDano(30);
        superCenouraAzul.SetCura(30);
    }

    [System.Obsolete]
    public void MedoMaximo() //Medo Maximo
    {
        playerMovimento.SetPlayerVelocidade(26);
        playerMovimento.SetPlayerForcaPulo(35);

        buffarAndNerffarCenouras.BuffarCuraCenouras();
    }


}