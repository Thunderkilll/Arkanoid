using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{

    public float speed = 10;
    PlayerController controller;

    private float direction;
    [SerializeField]
    private string axis;
    [SerializeField]
    private string jumpButton;
    bool isJumping = false;
    private float move;
    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponent<PlayerController>();
    }


    void Update()
    {
        direction = Input.GetAxisRaw(axis);
        move = direction * speed;
        if (Input.GetButtonDown(jumpButton))
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }
        controller.Move(move, isJumping);
    }
   
}
