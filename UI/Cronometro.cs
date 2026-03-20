using System.Collections;
using TMPro;
using UnityEngine;

public class Cronometro : MonoBehaviour
{
    public PontuacaoControle pC;
    public TextMeshProUGUI cronometro;
    public int minuto = 0;
    public CheckPoint checkPoint;

    [System.Obsolete]
    void Start()
    {
        pC = FindObjectOfType<PontuacaoControle>();
        checkPoint = GetComponent<CheckPoint>();

        if (checkPoint.JogoSalvo() != null)
        {
            SaveGame jogoSalvo = checkPoint.JogoSalvo();
            minuto = jogoSalvo.minuto;
        }

        cronometro.text = "" + minuto;
        Relogio();
    }

    public void Relogio()
    {
        StartCoroutine(ContaMinuto());
    }

    IEnumerator ContaMinuto()
    {
        yield return new WaitForSeconds(60);
        minuto++;
        AtualizaCronometro();
    }

    void AtualizaCronometro()
    {
        cronometro.text = "" + minuto;
        Relogio();
        checkPoint.SalvaCronometro(minuto);
        pC.MinutosJogados(minuto);
    }
}
