using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : EnemyController
{
    
    void Start()
    {
       sr = GetComponent<SpriteRenderer>();
        sr.flipX = true;
    }

    void FixedUpdate ()
	{
        if(sr.flipX==true)
		{
			this.GetComponent<Rigidbody2D>().velocity =
				new Vector2(-maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
		}
		else
		{
			this.GetComponent<Rigidbody2D>().velocity =
				new Vector2(maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
		}
	}

	//Because ghosts can pass through walls, the Trigger function is overridden from the Superclass 
	//to remove the flip function upon hitting a wall
  /*  
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            Flip();
        }
    }
    */
    
    
}
