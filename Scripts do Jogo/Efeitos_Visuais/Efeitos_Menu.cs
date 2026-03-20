using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Efeitos_Menu : MonoBehaviour
{
    public float velocidade;
    public MeshRenderer mR;

    void Update()
    {
        mR.material.mainTextureOffset += new Vector2(0, velocidade * Time.deltaTime);
    }
}
