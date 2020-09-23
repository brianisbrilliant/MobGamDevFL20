using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class progTestScoreKeeper : MonoBehaviour
{

    public int score = 0;

    public TextMeshPro scoreText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // create a public method that changed score.
    public void UpdateScore(int givenScore) {
        if(givenScore <= 0) {
            Debug.Log("You cannot add a negative score.");
            return;     // return means, end the program now.
        }

        score += givenScore;
        scoreText.text = ("Score = " + score);
    }
}
