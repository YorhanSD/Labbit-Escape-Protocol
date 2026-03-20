using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour
{
    public string nome;
    public string descricao;
    public string habilidade;
    public bool ePerfurante;
    public int quantidade;
    public int dano;
    public int cura;
    public float velocidade = 35f; //35f é o limite seguro para não causar bugs de colisão
    public Rigidbody2D rigid;
    private Vector2 direcao;
    [SerializeField] public Animator anim;

    public void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
    public void VerificaCenouraPerfurante()
    {
        if (ePerfurante)
        {
            StartCoroutine(DestruicaoConometrada());
        }
    }
    public void FixedUpdate() //Velocidade da cenoura
    {
        rigid.linearVelocity = direcao * velocidade;
    }
    public virtual void GirarCenoura()
    {
        anim.SetTrigger("Girar");
    }
    public void Direcao(Vector2 recebeDirecao) //Direcao da cenoura
    {
        direcao = recebeDirecao;
    }

    //--- Metodos Getters e Setters ---//

    public virtual void SetNome(string _nome) //Recebe o nome da cenoura
    {
        nome = _nome;
    }
    public virtual string GetNome() //Guarda o nome da cenoura
    {
        return nome;
    }
    public virtual void SetDano(int _dano)
    {
        dano = _dano;
    }
    public virtual int GetDano()
    {
        return dano;
    }
    public virtual void SetCura(int _cura)
    {
        cura = _cura;
    }
    public virtual int GetCura()
    {
        return cura;
    }
    public virtual void SetQuantidade(int _quantidade)
    {
        quantidade += _quantidade;
    }
    public virtual int GetQuantidade()
    {
        return quantidade;
    }
    public virtual void SetHabilidade(string _habilidade)
    {
        habilidade = _habilidade;
    }
    public virtual string GetHabilidade()
    {
        return habilidade;
    }
    public virtual void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.CompareTag("Inimigo") && ePerfurante == false)
        {
            DestruirCenoura();
        }

        if (_other.CompareTag("Parede"))
        {
            DestruirCenoura();
        }
    }
   public virtual void DestruirCenoura()
   {
        Destroy(gameObject); //Destroi cenoura
   }

   IEnumerator DestruicaoConometrada()
    {
        yield return new WaitForSecondsRealtime(2);
        Destroy(gameObject);
    }

}
