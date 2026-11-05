using UnityEngine;

public class collectable : MonoBehaviour
{
public AudioSource sfxSource; 
public AudioClip coinSound;
 void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && AudioManager.Instance!=null)
        {
            PlayerStats.score++;
            AudioManager.Instance.PlayMusicsfx(coinSound);
            Debug.Log("Score: " + PlayerStats.score);
            Destroy(gameObject);
        }
        // this part is for testing the level individually and in the absence of the audio manager
        // instance fro the reviod level
        else if (other.tag == "Player" && AudioManager.Instance==null)
        {
            PlayerStats.score++;
            Debug.Log("I AM IN The Else in OF COLLECTABLE MANUEL MUSIC");
            sfxSource.clip = coinSound;
            sfxSource.Play();
            Debug.Log("Score: " + PlayerStats.score);
            Destroy(gameObject,0.3f);
        }
    }
}
