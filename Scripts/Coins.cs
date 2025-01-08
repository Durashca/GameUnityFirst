using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int count;

    public AudioClip audioclip;
    private GameObject player;
    private AudioSource audioSource;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().AddCoid(count);
            audioSource.PlayOneShot(audioclip);
            
            Destroy(gameObject, 1);
        }
    }
}
