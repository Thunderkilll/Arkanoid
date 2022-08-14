using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BallMove : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb;

    public Text gameOver;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector2.up * speed;
        gameOver.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    float Hitfactor(Vector2 ballPos, Vector2 playerPos, float playerWidth)
    {
        return (ballPos.x - playerPos.x) / playerWidth;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            float x = Hitfactor(transform.position, col.transform.position, col.collider.bounds.size.x);

            Vector2 direction = new Vector2(x, 1).normalized;

            rb.velocity = direction * speed;

        }

        if (col.gameObject.name == "down")
        {
            // 1 Game Over 
            gameOver.gameObject.SetActive(true);
            // 2 Load Scene -> Replay

            Time.timeScale = 0;
        }
    }
}
