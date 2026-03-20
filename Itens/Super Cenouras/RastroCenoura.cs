using UnityEngine;

public class RastroCenoura : MonoBehaviour
{
    public GameObject pivot;
    public GameObject particulaRegeneracao;

    void Update()
    {
        //particulaRegeneracao.SetActive(true);
        particulaRegeneracao.transform.position = pivot.transform.position;
    }
}
