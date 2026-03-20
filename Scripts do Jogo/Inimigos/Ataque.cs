using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ataque : MonoBehaviour
{
    public LayerMask alvo;
    public Transform playerPosicao;
    public Transform areaAtaque;
    public Transform areaDano;
    public float tamanhoRaioAtaque;
    public float[] posicaoAreaAtaque = new float[2];
    public float[] posicaoAreaDano = new float[2];
    public bool ladoDireito;
    [SerializeField] private bool podeAtacar;
    public bool verificaAlvo;

    public void SetPodeAtacar(bool _podeAtacar)
    {
        podeAtacar = _podeAtacar;
    }
    public bool GetPodeAtacar()
    {
        return podeAtacar;
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void ChecaPosicao()
    {
        if(areaAtaque != null == gameObject.transform.position.x < playerPosicao.position.x) 
        {
            ladoDireito = true;
            MudarPosicao(posicaoAreaAtaque, posicaoAreaDano);
        }
        else if(areaDano != null == gameObject.transform.position.x > playerPosicao.position.x)
        {
            ladoDireito = false;
            ConverterParaNegativo();
            MudarPosicao(posicaoAreaAtaque, posicaoAreaDano);
        }
    }
    public void ConverterParaNegativo()
    {
        for(int i = 0; i < 2; i++)
        {
            posicaoAreaAtaque[i] *= -1;
            posicaoAreaDano[i] *= -1;
        }
    }
    public void MudarPosicao(float[] _posicaoAtaque, float[] _posicaoDano)
    {
        if (posicaoAreaAtaque != null && posicaoAreaDano != null)
        {
            areaAtaque.position = new Vector2(_posicaoAtaque[0], _posicaoAtaque[1]);
            areaDano.position = new Vector2(_posicaoDano[0], _posicaoDano[1]);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(areaAtaque.position, tamanhoRaioAtaque);
    }
}
