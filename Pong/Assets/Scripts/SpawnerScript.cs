using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnerScript : MonoBehaviour
{
    public GameObject prefab;
    
    public void Start()
    {
        GameObject ball = Instantiate(prefab, this.transform.position, this.transform.rotation) as GameObject;
    }
}
