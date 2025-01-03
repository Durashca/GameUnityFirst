using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int count;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {    
            Destroy(gameObject);
            collision.GetComponent<Player>().AddCoid(count); 
        }
    }
}
