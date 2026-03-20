using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lampada_Pisca : MonoBehaviour
{
    public GameObject luz;
    void Start()
    {
        StartCoroutine(PiscarLuz());
    }

    
    void Update()
    {
        
    }
    IEnumerator PiscarLuz()
    {
        luz.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        luz.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        luz.SetActive(false);
        yield return new WaitForSeconds(3f);
        luz.SetActive(true);

        StartCoroutine(Intervalo());
    }

    IEnumerator Intervalo()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(PiscarLuz());
    }
}
