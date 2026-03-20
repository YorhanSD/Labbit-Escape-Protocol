using UnityEngine;

public class Key : MonoBehaviour
{
    public AudioSource aS;
    public AudioClip somChave;
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            aS.clip = somChave;
            aS.Play();
        }
    }
}
