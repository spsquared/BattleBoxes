using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Physics : MonoBehaviour
{
    // Define object
    Rigidbody Player;
    // Declare variables
    float xVelocity = 0;
    float horizontalspeed = 1;
    float verticalspeed = 20;
    bool touchingGround = false;

    void Start()
    {
        // Initialize Player
        Player = GetComponent<Rigidbody>();
        Player.useGravity = true;
        Player.velocity = new Vector3(0, 0, 0);
    }

    void Update()
    {   
        // Define Input
        var Input = Keyboard.current;

        // Check position of Player
        if (transform.position.x < -8.85)
        {
            Player.position = new Vector3(-8.85f, transform.position.y, transform.position.z);
            xVelocity = 0;
        }
        if (transform.position.x > 8.85)
        {
            Player.position = new Vector3(8.85f, transform.position.y, transform.position.z);
            xVelocity = 0;
        }
        if (transform.position.y > 5)
        {
            Player.position = new Vector3(transform.position.x, 5, transform.position.z);
        }
        if (transform.position.y < -50)
        {
            Player.position = new Vector3(transform.position.x, -4, transform.position.z);
            Player.velocity = new Vector3(0, 0, 0);
        }

        // Move x position of Player
        if (Input.dKey.isPressed)
        {
            xVelocity += 1;
        }
        if (Input.aKey.isPressed)
        {
            xVelocity -= 1;
        }
        if (xVelocity >= 10)
        {
            xVelocity = 10;
        }
        if (xVelocity <= -10)
        {
            xVelocity = -10;
        }
        xVelocity *= 0.99f;
        transform.Translate(xVelocity*Time.deltaTime*horizontalspeed, 0, 0);

        // Walljump task
        if (touchingGround)
        {
            transform.Translate(0, 2*verticalspeed, 0);
            if (touchingGround)
            {
                transform.Translate(0, 2*verticalspeed, 0);
                if (touchingGround)
                {
                    transform.Translate(0, 2*verticalspeed, 0);
                    if (touchingGround)
                    {
                        transform.Translate(0, 2*verticalspeed, 0);
                        if (touchingGround)
                        {
                            transform.Translate(0, 2*verticalspeed, 0);
                            if (touchingGround)
                            {
                                transform.Translate(xVelocity*Time.deltaTime*-1, -10*verticalspeed, 0);
                                if (Input.wKey.isPressed)
                                {
                                    xVelocity *= -1;
                                    Player.AddForce(Vector3.up*10*verticalspeed);
                                }
                            }
                        }
                    }
                }
            }
        }

        // Jump task
        transform.Translate(0, -0.2f, 0);
        if (touchingGround && Input.wKey.isPressed)
        {
            Player.AddForce(Vector3.up*15*verticalspeed);
        }
        transform.Translate(0, 0.2f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Map")
        {
            // Touching the map
            touchingGround = true;
            Player.useGravity = false;
            Player.velocity = new Vector3(Player.velocity.x, -Player.velocity.y, Player.velocity.z);
            while (touchingGround) {
                System.Threading.Thread.Sleep(10);
            }
            Player.velocity = new Vector3(Player.velocity.x, 0, Player.velocity.z);
        }
        if (other.tag == "Player2Bullet")
        {
            // Touching enemy projectile
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Map")
        {
            // Still touching the map
            touchingGround = true;
            Player.useGravity = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Map")
        {
            // Leaving the map
            touchingGround = false;
            Player.useGravity = true;
        }
    }
}
