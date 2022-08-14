using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public int health = 1;
    public int scoreBlock = 1;
    public GameObject deathEffect;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "ball")
        {
            if (health == 1)
            {
                GameManager.score += scoreBlock;
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
          
            }
            else
            {
                health--;
            }
        }
        
    }
}
