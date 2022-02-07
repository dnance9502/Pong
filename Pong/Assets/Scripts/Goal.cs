


using TMPro;

using UnityEngine;
using UnityEngine.UI;

public partial class Goal : MonoBehaviour
{
    public static int P1Score;
    public static int P2Score;

    public TextMeshProUGUI p1ScoreText;
    public TextMeshProUGUI p2ScoreText;

    public GameObject P1winText;
    public GameObject P2winText;

    public GameObject spawner;

    public BallMovement playerstart;

    // Start is called before the first frame update
    void Start()
    {
        P1Score = 0;
        P2Score = 0;
        P1winText.SetActive(false);
        P2winText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (P1Score == 11)
        {
            Debug.Log("GAME OVER: Player 1 Wins!!");
            P1winText.SetActive(true);
            P1Score = 0;
            P2Score = 0;

            p1ScoreText.text = P1Score.ToString();
            p2ScoreText.text = P2Score.ToString();
        }

        if (P2Score == 11)
        {
            Debug.Log("GAME OVER: Player 2 Wins!!");
            P2winText.SetActive(true);
            P1Score = 0;
            P2Score = 0;

            p1ScoreText.text = P1Score.ToString();
            p2ScoreText.text = P2Score.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball"))
        {

            if (CompareTag("player1"))
            {
                P1winText.SetActive(false);
                P2winText.SetActive(false);
                
                P1Score++;
                p1ScoreText.text = P1Score.ToString();
                playerstart.pStart = true;
                Debug.Log("Player 1 scored! Score: " + P1Score.ToString() + " : " + P2Score.ToString());

            }

            if (CompareTag("player2"))
            {
                P1winText.SetActive(false);
                P2winText.SetActive(false);
                
                P2Score++;
                p2ScoreText.text = P2Score.ToString();
                playerstart.pStart = false;
                Debug.Log("Player 2 scored! Score: " + P1Score.ToString() + " : " + P2Score.ToString());

            }

            Destroy(other.gameObject);

            spawner.GetComponent<SpawnerScript>().Start();
        }

    }

}
