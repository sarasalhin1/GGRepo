using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public /*static*/ int health = 3;
	public static int lives = 3;
	public static int score = 0;

	public Image healthBar; //Green Bar to indicate health level
	public TextMeshProUGUI scoreUI; //TextMeshPro text field to show number of coins collected on HUD
	public TextMeshProUGUI livesUI; //TextMeshPro text field to show number of lives on HUD

	public static bool hasHeart = false;

    private float flickerTime = 0f; 
    public float flickerDuration = 0.1f;

	private SpriteRenderer sr;

	public bool isImmune = false;
    private float immunityTime = 0f; 
    public float immunityDuration = 1.5f; 
    void Start()
    {
       sr = GetComponent<SpriteRenderer>();
    }

	void Update()
	{
		if(isImmune == true)
		{
			SpriteFlicker();
			immunityTime = immunityTime + Time.deltaTime; 
			if(immunityTime >= immunityDuration)
			{
				isImmune = false;
				sr.enabled = true;
			}
		}

		scoreUI.text = " " + score; //convert number of coins to string to show on HUD
		
		livesUI.text = " " + lives; //convert number of lives to string to show on HUD
	}

	public void TakeDamage(int damage)
	{
		if (isImmune == false )
		{
			health = health - damage;
			healthBar.fillAmount = this.health/3f; //reflect health points on green bar. When player loses
			//health points, the green bar shrinks

			if (health < 0)
				health = 0;
            if (lives > 0 && health == 0)
            {
                FindObjectOfType<LevelManager>().RespawnPlayer();
                health = 3;
				healthBar.fillAmount = this.health/3f; //replenish the health bar so it's fully green again
                lives--;
            }
            else if (lives == 0 && health == 0)
            {
                Debug.Log("Gameover");	
                Destroy(this.gameObject);
            }

			Debug.Log("Player Health:" + health.ToString());
			Debug.Log("Player Lives:" + lives.ToString());
		}
		
		isImmune = true;
		immunityTime = 0f;
	}


	/*public void TakeDamage2(int damage)
{
	Debug.Log("I GOT HIT BY AN ENEMY :(");
    health = health - damage;

    if (health < 0){
        health = 0; 
		Debug.Log("LOST ALL MY HEALTH ");
	}
    if (lives > 0 && health == 0)
    {
        FindObjectOfType<LevelManager>().RespawnPlayer();
        health = 3;
        lives--;
		Debug.Log(" oops , that caused me a life, GOTTA RESPWAN");
	}
	else if (lives == 0 && health == 0)
	{
		Debug.Log("Goodbye :( Gameover");
		Destroy(this.gameObject);
    }
 
    Debug.Log("Player Health:" + health.ToString());
    Debug.Log("Player Lives:" + lives.ToString());
}*/
	
	void SpriteFlicker()
	{
		if(flickerTime < flickerDuration)
		{
			flickerTime = flickerTime + Time.deltaTime;
		}
		else if (flickerTime >= flickerDuration)
		{
            sr.enabled = !(sr.enabled);
		    flickerTime = 0;
		}
	}

}
