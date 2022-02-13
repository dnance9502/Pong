


using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public partial class Goal : MonoBehaviour
{
    public static int P1Score;
    public static int P2Score;

    public TextMeshProUGUI p1ScoreText;
    public TextMeshProUGUI p2ScoreText;
    private Transform p1scorePos;
    private Transform p2scorePos;

    public GameObject P1winText;
    public GameObject P2winText;

    public GameObject p1Prefab;
    public GameObject p2Prefab;
    
    public GameObject spawner;

    public BallMovement playerstart;

    public AudioClip goalSound;

    public bool isSelectingCard;

    private Transform playerDefault;

    public GameObject controll;


    void Start()
    {
        playerDefault = p1Prefab.transform;
        
        P1Score = 0;
        P2Score = 0;
        P1winText.SetActive(false);
        P2winText.SetActive(false);
        
        p1scorePos = p1ScoreText.transform;
        p2scorePos = p2ScoreText.transform;

        p1ScoreText.GetComponent<Animator>().enabled = false;
        p2ScoreText.GetComponent<Animator>().enabled = false;
        
    }


    void FixedUpdate()
    {

        if (P1Score == 10)
        {
            p1ScoreText.GetComponent<Animator>().enabled = true;
        }

        if (P2Score == 10)
        {
            p2ScoreText.GetComponent<Animator>().enabled = true;
        }
        
        if (P1Score == 11)
        {
            
            P1winText.SetActive(true);
            P1Score = 0;
            P2Score = 0;

            p1ScoreText.text = P1Score.ToString();
            p2ScoreText.text = P2Score.ToString();

            p1Prefab.transform.localScale = (playerDefault.localScale);
            p2Prefab.transform.localScale = (playerDefault.localScale);
            
            p1ScoreText.GetComponent<Animator>().enabled = false;
            p2ScoreText.GetComponent<Animator>().enabled = false;

            p1ScoreText.transform.position = p1scorePos.position;
            p2ScoreText.transform.position = p2scorePos.position;
            
        }

        if (P2Score == 11)
        {
            
            P2winText.SetActive(true);
            P1Score = 0;
            P2Score = 0;

            p1ScoreText.text = P1Score.ToString();
            p2ScoreText.text = P2Score.ToString();
            
            p1Prefab.transform.localScale = (playerDefault.localScale);
            p2Prefab.transform.localScale = (playerDefault.localScale);
            
            p1ScoreText.GetComponent<Animator>().enabled = false;
            p2ScoreText.GetComponent<Animator>().enabled = false;
            
            p1ScoreText.transform.position = p1scorePos.position;
            p2ScoreText.transform.position = p2scorePos.position;
        }

    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("ball"))
        {

            GetComponent<AudioSource>().PlayOneShot(goalSound);

            if (CompareTag("goal1"))
            {
                P1winText.SetActive(false);
                P2winText.SetActive(false);

                P1Score++;
                p1ScoreText.text = P1Score.ToString();
                playerstart.pStart = true;
                controll.GetComponent<ColorControl>().defaultColor(this.GameObject());

            }

            if (CompareTag("goal2"))
            {
                P1winText.SetActive(false);
                P2winText.SetActive(false);

                P2Score++;
                p2ScoreText.text = P2Score.ToString();
                playerstart.pStart = false;
                controll.GetComponent<ColorControl>().defaultColor(this.GameObject());

            }

            Destroy(other.gameObject);

            
            if (playerstart.pStart && ((P1Score == 3) || (P1Score == 6)  || (P1Score == 9)))
            {
                isSelectingCard = true;
                GetComponent<CardManager>().CardSelect(this.GameObject());
            }

            if (!playerstart.pStart && ((P2Score == 3) || (P2Score == 6)  || (P2Score == 9)))
            {
                isSelectingCard = true;
                GetComponent<CardManager>().CardSelect(this.GameObject());
            }
            
            if (!isSelectingCard)
            {
                spawner.GetComponent<SpawnerScript>().Start();
            }
            
        }

    }
}
