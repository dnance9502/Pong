using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (CompareTag("player1"))
        {
            if (Input.GetKey(KeyCode.W))
            {
                GetComponent<Rigidbody>().AddForce(Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse);
            }

            if (Input.GetKey(KeyCode.S))
            {
                GetComponent<Rigidbody>().AddForce(Vector3.back * speed * Time.deltaTime, ForceMode.Impulse);
            }

        }

        if (CompareTag("player2"))
        {
            if (Input.GetKey(KeyCode.I))
            {
                GetComponent<Rigidbody>().AddForce(Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse);
            }

            if (Input.GetKey(KeyCode.K))
            {
                GetComponent<Rigidbody>().AddForce(Vector3.back * speed * Time.deltaTime, ForceMode.Impulse);
            }

        }
    }
    
}
