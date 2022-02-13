using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class CardManager : MonoBehaviour


{
    public Button PadllePlus;
    public Button PaddleMinus;

    public GameObject spawn;
    public GameObject goal1;
    public GameObject goal2;
    
    // Start is called before the first frame update
    public void Start()
    {

        PaddleMinus.GameObject().SetActive(false);
        PadllePlus.GameObject().SetActive(false);
        
    }
    

    public void CardSelect(GameObject playerTag)
    {
        
        if (playerTag.CompareTag("goal1"))
        {
            PaddleMinus.GameObject().SetActive(true);
            PadllePlus.GameObject().SetActive(true);
        }

        if (playerTag.CompareTag("goal2"))
        {
            PaddleMinus.GameObject().SetActive(true);
            PadllePlus.GameObject().SetActive(true);
        }
        
    }

    public void CardClose()
    {
        PaddleMinus.GameObject().SetActive(false);
        PadllePlus.GameObject().SetActive(false);

        goal1.GetComponent<Goal>().isSelectingCard = false;
        goal2.GetComponent<Goal>().isSelectingCard = false;
        
        spawn.GetComponent<SpawnerScript>().Start();
    }
}
