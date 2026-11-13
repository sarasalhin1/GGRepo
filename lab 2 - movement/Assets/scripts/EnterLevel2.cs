using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLevel2 : MonoBehaviour
{
   //GameObject imageGameObject;
    //public Animator transitionAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        //The animation we wanna reference/use is on the Image gamebject, so we can locate it in the scene by tag
        //imageGameObject = GameObject.FindGameObjectWithTag("FadingBlack");
        //Once we've located the image, we can now reference its Animator
        //transitionAnim = imageGameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && PlayerStats.hasHeart == true) 
        {
            //Play the Fade Out animation
            
            //AudioManager.Instance.FadeToMusic(AudioManager.Instance.caveMusic, AudioManager.Instance.BetweenFades);
            //transitionAnim.SetTrigger("LevelEnd");
            SceneManager.LoadScene(2);
            //SceneManager.LoadScene(2); //This code will be amended later to connect all your levels together
        }else{
            FindObjectOfType<LevelManager>().RespawnPlayer();
        }
    }
}