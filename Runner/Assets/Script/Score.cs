using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    public Text highScore;
    private PlayerController playerController;
    private float timeScore = 0f;
    private static float highscore = 0f;
    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        highScore.text = highscore.ToString("0");
    }
    void Update()
    {
        if (playerController.gameOver == false)
        {
            timeScore += (Time.deltaTime);
            score.text = timeScore.ToString("0");
        }
        else if (playerController.gameOver == true)
        {
            if(timeScore > highscore)
            {
                highscore = timeScore;
            }
        }
    }
}
