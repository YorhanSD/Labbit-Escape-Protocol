using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Segue : MonoBehaviour
{
    public float segueVelocidade;
    public float yOffSet = 1f;
    public Transform playerPosicao;
    Vector3 novaPosicao;
    Controle_Emocional cE;
    public Camera cam;
    [SerializeField] private Aldus_Especial aldusEspecial;

    void Awake()
    {
        cE = GameObject.FindObjectOfType<Controle_Emocional>();
    }
    private void Start()
    {
        gameObject.transform.position = playerPosicao.position;
    }

    private void FixedUpdate()
    {
        if (aldusEspecial.GetEspecial() == false)
        {
            if (cE.emocaoSlider.value >= 100)
            {
                camFar();
            }
            else if (cE.emocaoSlider.value <= 0)
            {
                camNear();
            }
            else
            {
                camNormal();
            }
        }
        else
        {
            CameraAldusEspecial();
        }

        if (playerPosicao != null)
        {
            transform.position = Vector3.Slerp(transform.position, novaPosicao, segueVelocidade * Time.deltaTime);

            novaPosicao = new Vector3(playerPosicao.position.x, playerPosicao.position.y + yOffSet, -60);
        }
    }

    public void CameraAldusEspecial()
    {

        if (cam.orthographicSize < 50)
        {
            cam.orthographicSize += 10f * Time.deltaTime;
        }
    }

    public void camNear()
    {
        segueVelocidade = 10f;

        if (cam.orthographicSize < 25)
        {
            cam.orthographicSize += 0.7f * Time.deltaTime;
        }
    }

    public void camNormal()
    {
        segueVelocidade = 1f;

        if (cam.orthographicSize > 21)
        {
            cam.orthographicSize -= 3f * Time.deltaTime;
        }
    }

    public void camFar()
    {
        segueVelocidade = 10f;

        if (cam.orthographicSize < 35)
        {
            cam.orthographicSize += 0.7f * Time.deltaTime;
        }
    }

}
