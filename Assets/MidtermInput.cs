using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MidtermInput : MonoBehaviour
{
    public MidtermPlayer player;

    void Update() {
        // A Button
        if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            AButtonDown();
        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow)) {
            AButtonUp();
        }
 
        // B Button
        if(Input.GetKeyDown(KeyCode.RightArrow)) {
            BButtonDown();
        }
        else if(Input.GetKeyUp(KeyCode.RightArrow)) {
            BButtonUp(); 
        }
        // Escape
        if(Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(0);
        }
    }

    // this is a method
    // it is public so that we can call it from other scripts
    // it returns nothing, so the return type is 'void'
    // it has no parameters ()
    public void AButtonDown() {
        Debug.Log("<color=blue>The A Button has been pressed!</color>");
        player.Jump();
    }

    public void AButtonUp() {
        Debug.Log("<color=red>The A Button has been let go!</color>");
    }

    public void BButtonDown() {
        Debug.Log("<color=green>The B Button has been pressed!</color>");
        player.Attack();
    }

    public void BButtonUp() {
        Debug.Log("<color=yellow>The B Button has been let go!</color>");
    }
}
