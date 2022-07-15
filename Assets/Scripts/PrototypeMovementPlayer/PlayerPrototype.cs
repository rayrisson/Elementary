using System.Threading;
using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPrototype : MonoBehaviour
{
    //Movement

    public float Speed = 5;
    public float JumpForce = 10;

    public bool isJumping;
    public bool DoubleJump;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        UnityEngine.Vector3 movement = new UnityEngine.Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {

                rb.AddForce(new UnityEngine.Vector2(0f, JumpForce), ForceMode2D.Impulse);
                DoubleJump = true;
            }
            else if (DoubleJump)
            {
                rb.AddForce(new UnityEngine.Vector2(0f, JumpForce), ForceMode2D.Impulse);
                DoubleJump = false;
            }
        };
    }

    // Detects every time the character touches something
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 7)
        {
            isJumping = false;
        }
    }

    // Detects every time the character stop touching something
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == 7)
        {
            isJumping = true;
        }
    }
}

/* About jumps: Open Unity -> edit -> Project Settings -> Input */

/**
 * About GetAxis -> https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
 */
