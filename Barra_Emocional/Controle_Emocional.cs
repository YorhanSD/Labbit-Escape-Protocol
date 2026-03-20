using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controle_Emocional : MonoBehaviour
{
    [SerializeField] private Buffs_Nerfs buffsNerfs;
    [SerializeField] private Efeitos_Visuais efeitosVisuais;

    public AudioSource aS;
    public AudioClip trocaEstado;
    public AudioClip musicaNormal;
    public AudioClip musicaRapida;
    public AudioClip musicaLenta;
    public Slider emocaoSlider;
    public GameObject[] indicador;
    public bool recarregar;

    public void Start()
    {
        aS = GetComponent<AudioSource>();
        emocaoSlider.value = 50;
    }

    [System.Obsolete]
    void Update()
    {
        if (emocaoSlider != null)
        {
            NivelEmocional();

            if (emocaoSlider.value == 0)
            {
                indicador[0].SetActive(true);
            }
            else
            {
                indicador[0].SetActive(false);
            }

            if (emocaoSlider.value == 100)
            {
                indicador[1].SetActive(true);
            }
            else
            {
                indicador[1].SetActive(false);
            }

            if (emocaoSlider.value < 0)
            {
                emocaoSlider.value = 0;
            }

            if (emocaoSlider.value > 100)
            {
                emocaoSlider.value = 100;
            }
        }
    }

    [System.Obsolete]
    void NivelEmocional()
    {
        if (emocaoSlider.value > 99)
        {
            buffsNerfs.CoragemMaxima();
        }

        if (emocaoSlider.value > 0 && emocaoSlider.value < 100)
        {
            buffsNerfs.AtributosNormais();
        }

        if (emocaoSlider.value < 1)
        {
            buffsNerfs.MedoMaximo();
        }
    }

    public void Medo(int _nivelMedo) //Ao tomar dano
    {
        if (emocaoSlider.value != 0 && recarregar == false)
        {
            emocaoSlider.value -= _nivelMedo;

            SoundTrack();
        }
    }

    public void Coragem(int _nivelCoragem) //Ao matar um inimigo
    {
        if (emocaoSlider.value != 100 && recarregar == false)
        {
            emocaoSlider.value += _nivelCoragem;

            SoundTrack();
        }
    }

    public bool SoundTrack()
    {
        if (emocaoSlider.value > 99)
        {
            
            aS.clip = musicaRapida;
            aS.Play();

            return false;
        }
        else if (emocaoSlider.value < 1)
        {
            
            aS.clip = musicaLenta;
            aS.Play();

            return false;
        }
        else
        {
            aS.clip = musicaNormal;
            aS.Play();
        }

        return false;
    }
}


