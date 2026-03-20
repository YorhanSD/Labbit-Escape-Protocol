using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.SmartFormat.Utilities;
using System.Collections;

public class AtivaConquista : MonoBehaviour
{
    public TextMeshProUGUI textoConquistaIStatus;
    public TextMeshProUGUI textoConquistaIIStatus;
    public TextMeshProUGUI textoConquistaIIIStatus;
    public TextMeshProUGUI textoConquistaIVStatus;
    public TextMeshProUGUI textoConquistaVStatus;
    public TextMeshProUGUI textoConquistaVIStatus;
    public TextMeshProUGUI textoConquistaVIIStatus;
    public TextMeshProUGUI textoConquistaVIIIStatus;
    public TextMeshProUGUI textoConquistaIXStatus;

    public CheckPoint checkPoint;

    [System.Obsolete]
    IEnumerator Start()
    {
        yield return LocalizationSettings.InitializationOperation;

        MudaStatusConquistas();

        LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
    }
    void OnLocaleChanged(UnityEngine.Localization.Locale locale)
    {
        Debug.Log("Idioma mudou para: " + locale.Identifier.Code);
        MudaStatusConquistas();
    }
    void MudaStatusConquistas()
    {
        SaveGame save = Carregar.Load();

        if (save == null)
            return;

        AtualizaTexto(textoConquistaIStatus, save.conquistaIfeita);
        AtualizaTexto(textoConquistaIIStatus, save.conquistaIIfeita);
        AtualizaTexto(textoConquistaIIIStatus, save.conquistaIIIfeita);
        AtualizaTexto(textoConquistaIVStatus, save.conquistaIVfeita);
        AtualizaTexto(textoConquistaVStatus, save.conquistaVfeita);
        AtualizaTexto(textoConquistaVIStatus, save.conquistaVIfeita);
        AtualizaTexto(textoConquistaVIIStatus, save.conquistaVIIfeita);
        AtualizaTexto(textoConquistaVIIIStatus, save.conquistaVIIIfeita);
        AtualizaTexto(textoConquistaIXStatus, save.conquistaIXfeita);
    }

    void AtualizaTexto(TextMeshProUGUI txt, bool _feita)
    {
        string idioma = LocalizationSettings.SelectedLocale.Identifier.Code;

        if (_feita == true)
        {
            switch (idioma)
            {
                case "en":
                case "en-EN":
                    txt.text = "Achieved";
                    break;

                case "de":
                case "de-DE":
                    txt.text = "Erreicht";
                    break;

                case "es-AR":
                    txt.text = "Alcanzada";
                    break;

                case "pt":
                case "pt-BR":
                    txt.text = "Alcançada";
                    break;

                default:
                    txt.text = "Achieved";
                    break;
            }

            txt.color = Color.green;
        }
        else
        {
            switch (idioma)
            {
                case "en":
                case "en-EN":
                    txt.text = "No Achieved";
                    break;

                case "de":
                case "de-DE":
                    txt.text = "Nicht Erreicht";
                    break;

                case "es-AR":
                    txt.text = "No Alcanzada";
                    break;

                case "pt":
                case "pt-BR":
                    txt.text = "Não Alcançada";
                    break;

                default:
                    txt.text = "No Achieved";
                    break;
            }

            txt.color = Color.red;
        }
    }
}
