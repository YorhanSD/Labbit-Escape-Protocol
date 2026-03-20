using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_PatchNotes : MonoBehaviour
{
    public GameObject telaPatchNotes;

    public void botaoAbrePatch()
    {
        telaPatchNotes.SetActive(true);
    }

    public void botaoFechaPatch()
    {
        telaPatchNotes.SetActive(false);
    }
}
