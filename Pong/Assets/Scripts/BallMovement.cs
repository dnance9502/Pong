using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Playables;
using Random = UnityEngine.Random;

public class BallMovement : MonoBehaviour
{
    public Rigidbody rb;
    public bool pStart;
    
    public float InitialSpeed;
    private Vector3 Initialdirection;

    private Vector3 LastVelocity;
    
    void Start()
    {
        float rand = Random.Range(-1.0f, 1.0f);
        
        Initialdirection = new Vector3(-1, 0, rand);
        KickOff(pStart, rb);
    }

    private void Update()
    {
        LastVelocity = rb.velocity;

    }


    private void KickOff(bool player1, Rigidbody ball)
    {
        if (player1)
        {
            ball.velocity = (Initialdirection * InitialSpeed);
            
        }
        else
        {
            ball.velocity = (-Initialdirection * InitialSpeed);
            
        }
    }
    
    
    private void OnCollisionEnter(Collision other)
    {
        //Reflect direction and find current speed
        var speed = LastVelocity.magnitude;
        var direction = Vector3.Reflect(LastVelocity.normalized, other.contacts[0].normal);
        
        //Change velocity of hit a wall
        if (other.gameObject.CompareTag("wall"))
        {
            rb.velocity = direction * speed;
        }

        //Change velocity if hit paddle #1
        if (other.gameObject.CompareTag("player1"))
        {
            Debug.Log("contact with paddle");
            
            //Max speed set
            if (speed < 180f)
            {
                speed *= 1.2f;
            }
            
            rb.velocity = direction * speed;
            
            //Update color
            var color = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = new Color(color.r, color.g * 0.9f, color.b);

        }
        
        //Change Velocity if hit paddle #2
        if (other.gameObject.CompareTag("player2"))
        {
            Debug.Log("contact with paddle");
            
            //Max speed set
            if (speed < 180f)
            {
                speed *= 1.2f;
            }
    
            rb.velocity = direction * speed;
            
            //Update color
            var color = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = new Color(color.r, color.g * 0.9f, color.b);

        }
        
    }
}
