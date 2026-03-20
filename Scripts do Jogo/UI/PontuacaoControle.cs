using TMPro;
using UnityEngine;

public class PontuacaoControle : MonoBehaviour
{
    public CheckPoint checkPoint;

    public bool jogadorAbriuEstatisticas;

    public int mutiplicadorDePunicao = 1000;

    public int pontuacaoTotal = 0;
    public int pontuacaoNegativaMortes = 0;
    public int pontuacaoNegativaTempo = 0;
    public int pontosCenourasColetadas = 0;
    public int pontosInimigosAbatidos = 0;
    public int pontosDNAsColetados = 0;

    public TextMeshProUGUI pontuacaoPlayerUI;
    public TextMeshProUGUI TXTpontuacaoTotal;
    public TextMeshProUGUI TXTpontuacaoNegativaMortes;
    public TextMeshProUGUI TXTpontuacaoNegativaTempo;
    public TextMeshProUGUI TXTpontosCenourasColetadas;
    public TextMeshProUGUI TXTpontosInimigosAbatidos;
    public TextMeshProUGUI TXTpontosDNAsColetados;


    void Start()
    {
        checkPoint = GetComponent<CheckPoint>();

        if (checkPoint.JogoSalvo() != null)
        {
            SaveGame save = new SaveGame();
            save = checkPoint.JogoSalvo();

            pontosInimigosAbatidos = save.saveInimigosAbatidos;
            pontosCenourasColetadas = save.saveCenourasColetadas;
            pontosDNAsColetados = save.saveDNAsColetados;
            pontuacaoNegativaMortes = save.saveMortes;
            pontuacaoNegativaTempo = save.minuto;
        }

        MostraTotalDePontos();
    }

    public void TelaAtivada()
    {
        if (pontuacaoTotal > 0)
        {
            TXTpontuacaoTotal.color = Color.green;
        }
        else
        {
            TXTpontuacaoTotal.color = Color.red;
        }

        TXTpontuacaoTotal.text = "     " + pontuacaoTotal;
        TXTpontosDNAsColetados.text = "     " + pontosDNAsColetados;
        TXTpontuacaoNegativaMortes.text = "   - " + pontuacaoNegativaMortes;
        TXTpontosInimigosAbatidos.text = "     " + pontosInimigosAbatidos;
        TXTpontuacaoNegativaTempo.text = "   - " + pontuacaoNegativaTempo * mutiplicadorDePunicao;
        TXTpontosCenourasColetadas.text = "     " + pontosCenourasColetadas;
    }
    public void MinutosJogados(int _minutos)
    {
        pontuacaoNegativaTempo = _minutos;
    }
    public void AdicionaPontosNegativosPorMorte(int _pontos)
    {
        pontuacaoNegativaMortes += _pontos;
        checkPoint.SalvaNumeroDeVezesQueMorreu(pontuacaoNegativaMortes);
    }
    public void AdicionaPontosPorColetaCenoura(int _pontos)
    {
        pontosCenourasColetadas += _pontos;
        checkPoint.SalvaCenouraColetadas(pontosCenourasColetadas);
    }
    public void AdicionaPontoPorAbate(int _pontos)
    {
        pontosInimigosAbatidos += _pontos;
        checkPoint.SalvaInimigosAbatidos(pontosInimigosAbatidos);
    }

    public void AdicionaPontoPorDNAsColetados(int _pontos)
    {
        pontosDNAsColetados += _pontos;
        checkPoint.SalvaDNAsColetados(pontosDNAsColetados);
    }

    public void MostraTotalDePontos()
    {
        pontuacaoTotal = 0;

        pontuacaoTotal = pontosDNAsColetados + pontosInimigosAbatidos + pontosCenourasColetadas;
        pontuacaoTotal -= pontuacaoNegativaTempo * mutiplicadorDePunicao;
        pontuacaoTotal -= pontuacaoNegativaMortes;

        if (pontuacaoTotal > 0 && pontuacaoPlayerUI != null)
        {
            pontuacaoPlayerUI.color = Color.green;
        }
        else if(pontuacaoTotal < 0 && pontuacaoPlayerUI != null)
        {
            pontuacaoPlayerUI.color = Color.red;
        }

        if (pontuacaoPlayerUI != null)
        {
            pontuacaoPlayerUI.text = "" + pontuacaoTotal;
        }
    }
}
