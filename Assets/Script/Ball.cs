using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Ball : MonoBehaviour
{
    public float speed = 10f;
    public  GameObject gameOver;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Time.timeScale = 1f;
        GameObject.Find("Score").SetActive(true);
        rb.velocity = Vector2.down * speed;
        gameOver.SetActive(false);
    }


    float HitFactor(Vector2 ballPos , Vector2 playerPos , float playerWidth)
    {
        return (ballPos.x - playerPos.x) / playerWidth;
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name =="Player")
        {
            float y = HitFactor(transform.position, col.gameObject.transform.position, col.collider.bounds.size.x);
            // 1 0 -1

            Vector2 direction = new Vector2(y, 1).normalized;
            rb.velocity = direction * speed;
        }

        if (col.gameObject.tag == "Bottom")
        {
            //Debug.Log("Game Over");
            Time.timeScale = 0f;
            GameObject.Find("Score").SetActive(false);
            gameOver.SetActive(true);
           // text.text = GameManager.score.ToString();

        }
    }
}
