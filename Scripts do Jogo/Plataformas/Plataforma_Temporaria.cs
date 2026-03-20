using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma_Temporaria : MonoBehaviour
{
    public GameObject plataformaTemporaria;
    public float tempoSome = 1.5f;
    public AudioSource aS;
    public AudioClip somQuebrando;

    public void OnTriggerEnter2D(Collider2D _player)
    {
        if (_player.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Sumir());
        }
    }
    public IEnumerator Sumir()
    {
        StartCoroutine(EsperaAudio());

        if(plataformaTemporaria != null) 
        {
        yield return new WaitForSeconds(tempoSome);
        plataformaTemporaria.SetActive(false);
        yield return new WaitForSeconds(tempoSome);
        plataformaTemporaria.SetActive(true);
        }
    }
    public IEnumerator EsperaAudio()
    {
        yield return new WaitForSeconds(1f);
        if (aS != null)
        {
            aS.clip = somQuebrando;
            aS.Play();
        }
    }
}
