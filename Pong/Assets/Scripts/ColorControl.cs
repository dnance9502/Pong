using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class ColorControl : MonoBehaviour
{

    public Material[] wallColors;
    public Material[] playerColors;
    public Material[] ballColors;
    public Material[] floorColors;
    

    private int cycle = 1;

    public void setColor(GameObject ball)
    {
        
        ball.GetComponent<MeshRenderer>().material = ballColors[cycle % 6];

        GameObject floor = GameObject.FindGameObjectWithTag("floor");
        floor.GetComponent<MeshRenderer>().material = floorColors[cycle % 6];

        GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");
        foreach(GameObject wall in walls)
        {
            wall.GetComponent<MeshRenderer>().material = wallColors[cycle % 6];
        }
        
        GameObject player1 = GameObject.FindGameObjectWithTag("player1");
        GameObject player2 = GameObject.FindGameObjectWithTag("player2");

        player1.GetComponent<MeshRenderer>().material = playerColors[cycle % 6];
        player2.GetComponent<MeshRenderer>().material = playerColors[cycle % 6];

        cycle++;

    }

    public void defaultColor(GameObject ball)
    {
        ball.GetComponent<MeshRenderer>().material = ballColors[0];

        GameObject floor = GameObject.FindGameObjectWithTag("floor");
        floor.GetComponent<MeshRenderer>().material = floorColors[0];

        GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");
        foreach(GameObject wall in walls)
        {
            wall.GetComponent<MeshRenderer>().material = wallColors[0];
        }
        
        GameObject player1 = GameObject.FindGameObjectWithTag("player1");
        GameObject player2 = GameObject.FindGameObjectWithTag("player2");

        player1.GetComponent<MeshRenderer>().material = playerColors[0];
        player2.GetComponent<MeshRenderer>().material = playerColors[0];
    }
}


