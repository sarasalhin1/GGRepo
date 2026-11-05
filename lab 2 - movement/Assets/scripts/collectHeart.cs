using UnityEngine;

public class collectHeart : MonoBehaviour
{

    public AudioClip heartSound; 
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerStats.lives++;
            PlayerStats.hasHeart = true;
            AudioManager.Instance.PlayMusicsfx(heartSound);
            Debug.Log("Lives: " + PlayerStats.lives);
            Destroy(gameObject);
        }
    }
}
