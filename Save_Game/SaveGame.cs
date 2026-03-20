using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveGame
{
    [SerializeField] private bool jaJogou;
    private float playerPosicaoX;
    private float playerPosicaoY;
    private int salvaQuantidade;

    public int minuto;
    public int saveMortes = 0;
    public int saveCenourasColetadas = 0;
    public int saveInimigosAbatidos = 0;
    public int saveDNAsColetados = 0;

    public bool conquistaIfeita = false;
    public bool conquistaIIfeita = false;
    public bool conquistaIIIfeita = false;
    public bool conquistaIVfeita = false;
    public bool conquistaVfeita = false;
    public bool conquistaVIfeita = false;
    public bool conquistaVIIfeita = false;
    public bool conquistaVIIIfeita = false;
    public bool conquistaIXfeita = false;

    public void SetJaJogou(bool _jaJogou)
    {
        jaJogou = _jaJogou;
    }
    public bool GetJaJogou()
    {
        return jaJogou;
    }
    public void SetPlayerPosicaoX(float _playerPosicaoX)
    {
        playerPosicaoX = _playerPosicaoX;
    }
    public float GetPlayerPosicaoX()
    {
        return playerPosicaoX;
    }

    public void SetPlayerPosicaoY(float _playerPosicaoY)
    {
        playerPosicaoY = _playerPosicaoY;
    }
    public float GetPlayerPosicaoY()
    {
        return playerPosicaoY;
    }

    public void SetSalvaQuantidade(int _salvaQuantidade)
    {
        salvaQuantidade = _salvaQuantidade;
    }

    public int GetSalvaQuantidade()
    {
        return salvaQuantidade;
    }

}
