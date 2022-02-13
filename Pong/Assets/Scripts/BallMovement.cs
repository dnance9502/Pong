using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Playables;
using UnityEngine.Playables;
using Random = UnityEngine.Random;

public class BallMovement : MonoBehaviour
{
    public Rigidbody rb;
    public bool pStart;
    
    public float InitialSpeed;
    private Vector3 Initialdirection;

    private Vector3 LastVelocity;

    public AudioClip hitsound;
    private float lowVol = 0.5f;
    private float highVol = 1f;
    
    void Start()
    {
        float rand = Random.Range(-1.0f, 1.0f);
        
        Initialdirection = new Vector3(-1, 0, rand);
        KickOff(pStart, rb);
    }

    private void FixedUpdate()
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

        var speed = LastVelocity.magnitude;
        var direction = Vector3.Reflect(LastVelocity.normalized, other.contacts[0].normal);

        float volume = Random.Range(lowVol, highVol) * (speed / 160);
        GetComponent<AudioSource>().PlayOneShot(hitsound, volume);
        

        if (other.gameObject.CompareTag("wall"))
        {
            if (speed < 200f)
            {
                speed *= 1.1f;
            }
            
            rb.velocity = direction * speed;
            GetComponent<ColorControl>().setColor(this.GameObject());
        }
        
        
        if (other.gameObject.CompareTag("player1"))
        {
            
            if (speed < 200f)
            {
                speed *= 1.2f;
            }
            
            rb.velocity = direction * speed;
            GetComponent<ColorControl>().setColor(this.GameObject());
            
        }
      
        if (other.gameObject.CompareTag("player2"))
        {
            
            if (speed < 200f)
            {
                speed *= 1.2f;
            }
    
            rb.velocity = direction * speed;
            GetComponent<ColorControl>().setColor(this.GameObject());
       
        }
        
    }
}
