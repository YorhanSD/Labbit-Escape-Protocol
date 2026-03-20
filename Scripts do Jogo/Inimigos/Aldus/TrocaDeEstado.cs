using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaDeEstado : MonoBehaviour
{
    public GameObject aldosTunado;
    public GameObject plataformasPrimeiroEstado;
    public GameObject plataformasSegundoEstado;
    public void AtivarAldosTunado()
    {
        aldosTunado.SetActive(true);
        plataformasPrimeiroEstado.SetActive(false);
        plataformasSegundoEstado.SetActive(true);
    }
}
