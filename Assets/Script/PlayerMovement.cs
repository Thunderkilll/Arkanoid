using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 30f;
     

   void FixedUpdate()
   {
       float h = Input.GetAxisRaw("Horizontal");

       GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
   }
}
