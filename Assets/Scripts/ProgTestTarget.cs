using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgTestTarget : MonoBehaviour
{

    progTestScoreKeeper scoreKeeper;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(FindScoreKeeper());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void OnTriggerEnter() that adds 100 points to score.
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Enemy")) {
            scoreKeeper.UpdateScore(100);
        }
    }
    // in Start():    StartCoroutine(FindScoreKeeper());
    IEnumerator FindScoreKeeper() {
        float counter = 0;
        while(counter < 5) {
            if(GameObject.Find("ScoreKeeper").GetComponent<progTestScoreKeeper>() != null) {
                scoreKeeper = GameObject.Find("ScoreKeeper").GetComponent<progTestScoreKeeper>();
                
                Debug.Log("ScoreKeeper = " + scoreKeeper);

                scoreKeeper.UpdateScore(1);                 // testing that we have access to scoreKeeper.
                scoreKeeper.UpdateScore(-5);
                // break out of the loop and consequently, the FindScoreKeeper() method.
                break;
            }            

            // otherwise, wait for 0.1 seconds and try again.
            counter += 0.1f;
            Debug.Log("I couldn't find scorekeeper, trying again. . .");
            yield return new WaitForSeconds(0.1f);

        }// end of while loop
    }
}
