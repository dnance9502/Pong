using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class PaddlePlusCard : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public GameObject ball;
    public GameObject cardManager;

    public void ActivateCard()
    {

       if (ball.GetComponent<BallMovement>().pStart)
       {
           player2.transform.localScale += new Vector3(0f, 0f, 5f);
           //GetComponent<Button>().gameObject.SetActive(false);

       }
       else
       {
           player1.transform.localScale += new Vector3(0f, 0f, 5f);
           //GetComponent<Button>().gameObject.SetActive(false);
       } 
       
       cardManager.GetComponent<CardManager>().CardClose();
    }
}
