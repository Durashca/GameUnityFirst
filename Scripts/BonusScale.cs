using UnityEngine;

public class BonusScale : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Player>().BonusScale();
        
            Destroy(gameObject);
        }


    }
}
