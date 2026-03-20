using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffNerff_Cenouras : MonoBehaviour
{
    [SerializeField] private Cenoura_Laranja cenouraLaranja;
    [SerializeField] private Cenoura_Preta cenouraPreta;

    [SerializeField] private Super_CenouraAzul superCenouraAzul;
    [SerializeField] private Super_CenouraLaranja superCenouraLaranja;
    [SerializeField] private Super_CenouraVerde superCenouraVerde;
    [SerializeField] private Super_CenouraPreta superCenouraPreta;

    [System.Obsolete]
    void Awake()
    {
        //As cenouras precisam estar na cena

        cenouraLaranja = GameObject.FindObjectOfType<Cenoura_Laranja>();
        cenouraPreta = GameObject.FindObjectOfType<Cenoura_Preta>();

        superCenouraAzul = GameObject.FindObjectOfType<Super_CenouraAzul>();
        superCenouraLaranja = GameObject.FindObjectOfType<Super_CenouraLaranja>();
        superCenouraVerde = GameObject.FindObjectOfType<Super_CenouraVerde>();
        superCenouraPreta = GameObject.FindObjectOfType<Super_CenouraPreta>();
    }

    public void BuffarDanoCenouras()
    {
        //cenouraLaranja.SetDano(20);
        //cenouraPreta.SetDano(60);

        //cenouraVerde.SetDano(50);
        //cenouraAzul.SetDano(40);

        superCenouraLaranja.SetDano(20);
        superCenouraLaranja.SetCura(30);

        superCenouraPreta.SetDano(80);
        superCenouraPreta.SetCura(0);

        superCenouraVerde.SetDano(120);
        superCenouraVerde.SetCura(0);

        superCenouraAzul.SetDano(60);
        superCenouraAzul.SetCura(30);
    }
    public void BuffarCuraCenouras()
    {
        cenouraLaranja.SetCura(60);
        cenouraPreta.SetCura(20);

        superCenouraLaranja.SetDano(10);
        superCenouraLaranja.SetCura(60);

        superCenouraPreta.SetDano(40);
        superCenouraPreta.SetCura(0);

        superCenouraVerde.SetDano(60);
        superCenouraVerde.SetCura(0);

        superCenouraAzul.SetDano(30);
        superCenouraAzul.SetCura(60);
    }
}
