using UnityEngine;

public class Ativa_JogoSalvo : MonoBehaviour
{
    public GameObject botaoJogoSalvo;
    public CheckPoint checkPoint;

    [System.Obsolete]
    public void Start()
    {
        checkPoint = GetComponent<CheckPoint>();

        AtivaBotao();
    }
    public void AtivaBotao()
    {
        if (checkPoint == null)
        {
            Debug.LogError("CheckPoint não encontrado!");
            botaoJogoSalvo.SetActive(false);
            return;
        }

        SaveGame conquistaISalva = checkPoint.JogoSalvo();

        if (conquistaISalva == null)
        {
            // Primeiro boot do jogo
            botaoJogoSalvo.SetActive(false);
            return;
        }

        botaoJogoSalvo.SetActive(conquistaISalva.GetJaJogou());
    }
}
