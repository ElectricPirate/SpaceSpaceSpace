using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public GameObject ScoreText;
    private int Score = 0;
    void Start()
    {
        
    }

    public void IncreaseScore(int increment)
    {
        Score += increment;
        ScoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + Score;
    }
    
    void Update()
    {
        
    }
}
