using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 3;
	public int lives = 3;

    /*private float flickerTime = 0f; //counteer
    public float flickerDuration = 0.1f;

	private SpriteRenderer sr;

	public bool isImmune = false;
    private float immunityTime = 0f; //counter
    public float immunityDuration = 1.5f;*/
    //private SpriteRenderer sr;
    void Start()
    {
       // sr = GetComponent<SpriteRenderer>();
    }

	void Update()
	{
		/*if(isImmune == true)
		{
			SpriteFlicker();
			immunityTime = immunityTime + Time.deltaTime; //starting the counter for immunity
			if(immunityTime >= immunityDuration)
			{
				isImmune = false;
				sr.enabled = true;
			}
		}*/
	}

	/*public void TakeDamage(int damage)
	{
		if (isImmune == false )
		{
			health = health - damage;
			if (health < 0)
				health = 0;
            if (lives > 0 && health == 0)
            {
                FindObjectOfType<LevelManager>().RespawnPlayer();
                health = 3;
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
	}*/


	public void TakeDamage(int damage)
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
}
	
	/*void SpriteFlicker()
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
	}*/

}
