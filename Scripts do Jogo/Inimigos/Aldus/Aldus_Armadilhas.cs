using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aldus_Armadilhas : MonoBehaviour
{
    private bool ativarLeituraMoviemento;
    private int contagemLaser;
    public bool podeCriar;
    public float intervalo;
    public Transform[] pontoCriacao;
    public GameObject[] lasers;
    public void SetAtivaLeitura(bool _ativarLeitura)
    {
        ativarLeituraMoviemento = _ativarLeitura;
    }
    public bool GetAtivaLeitura()
    {
        return ativarLeituraMoviemento;
    }
    void Update()
    {
        if (GetAtivaLeitura() == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                contagemLaser++;

                if (contagemLaser == 45)
                {
                    podeCriar = true;

                    CriaLaser();

                    contagemLaser = 0;
                }
            }
        }
    }
    public void CriaLaser()
    {
        if (podeCriar == true)
        {
            //Cria um laser esquerdo na posição definida pelo pontoCriação 
            GameObject laserEsqTemp = (GameObject)(Instantiate(lasers[0], pontoCriacao[0].transform.position, pontoCriacao[0].transform.rotation));

            //Cria um laser direito no posição definida pelo pontoCriação
            GameObject laserDirTemp = (GameObject)(Instantiate(lasers[1], pontoCriacao[1].transform.position, pontoCriacao[1].transform.rotation));

            podeCriar = false;
        }
    }
}
