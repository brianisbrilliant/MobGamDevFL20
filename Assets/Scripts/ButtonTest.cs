using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    public enum direction {Right, Left};

    public direction dir;

    public Transform playerShip;

    [Range(10,360)]
    public int rotSpeed = 30;

    bool rotateRight, rotateLeft;

    void Update() {
        if(rotateRight) {
            playerShip.Rotate(0,0, -1 * rotSpeed * Time.deltaTime);
        } else if (rotateLeft) {
            playerShip.Rotate(0,0, 1 * rotSpeed * Time.deltaTime);
        }
    }

    public void ButtonDown(string givenDir) {
        print(givenDir + " button Down.");
        if(givenDir == "Right") {
            rotateRight = true;
        } else if(givenDir == "Left"){
            rotateLeft = true;
        }
    }

    public void ButtonUp(string givenDir) {
        print(givenDir + " button Up.");
        if(givenDir == "Right") {
            rotateRight = false;
        } else if(givenDir == "Left"){
            rotateLeft = false;
        }
    }
}
