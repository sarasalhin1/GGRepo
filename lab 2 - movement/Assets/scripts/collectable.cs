using UnityEngine;

public class collectable : MonoBehaviour
{

public AudioClip coinSound;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && AudioManager.Instance!=null)
        {
            PlayerStats.score++;
            AudioManager.Instance.PlayMusicsfx(coinSound);
            Debug.Log("Score: " + PlayerStats.score);
            Destroy(gameObject);
        }
    }
}





















