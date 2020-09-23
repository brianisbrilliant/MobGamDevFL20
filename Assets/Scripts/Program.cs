// Brian Foster MobGamDev Fall 2020

// create a public boolean, set it to true or false, and then use an if statement in Start() to call Debug.Log() and give it's value.

// create a private float. in Start, assign it a Random.value. Use an if statement to test if it is greater than 0.5, and send the result to Debug.Log(). Use an else if() statement to test if it is above 0.9, and send that to debug.log too.

// create a function/method named 'CreateCube' with a return type of 'void'. Use 'GameObject.CreatePrimitive' to create a cube at 'Vector3.zero'. Use an if statement in Update() to run the function when you press 'R'.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program : MonoBehaviour
{

    public bool profIsMuted = true;
    [Tooltip("Set to zero to get a random value.")]
    public float testNumber = 0;

    public int cubeHeight = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(profIsMuted == true) {           // it is up to you whether you add the "== true"
            Debug.Log("I know I am muted! Thanks.");
        } else {
            Debug.Log("I'll be unmuted soon.");
        }

        // second assignment goes here.
        if(testNumber == 0) {
            testNumber = Random.value;
        }

        Debug.Log("TestNumber = " + testNumber);

        // testNumber = .95
        if(testNumber > .9) {
            Debug.Log("The Test Number is greater than 0.9! Wow!");            
        }
        else if(testNumber > 0.5) {
            Debug.Log("The Test Number is greater than 0.5!");
        }
        else {
            Debug.Log("The Test Number is less than 0.5. Oh well.");
        }

        CreateCube(4);
        CreateCube(6);
        CreateCube(8);
        CreateCube(10);
        CreateCube(12);

        Double(64);         // f(x) = y
        Double(77);         // f(77) = 154
        Double(13);         // f(13) = 26
        
        // we are building a loop here.
        // while(this test is true) { keep looping }
        int counter = 0;            // this number keeps track of how many times we've looped
        // make a random number of cubes, between 5 and 50
        while(counter < Random.Range(5, 51)) {       // while (counter is less than 20) { run this code } 
            counter += 1;           // add one to counter
            CreateCube(counter);    // call the CreateCube function and send it counter
        }

        Debug.Log("Random num betwee 0 and 50 = " + (Random.value * 100) / 2);           // a number between 0 and 50


    }       // this is the end of Start()

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            cubeHeight += 1;
            CreateCube(cubeHeight);
        }
    }

    // return type is 'void' because we are not returning anything.
    // we have one parameter, givenHeight, which changes the y position of our cube.
    void CreateCube(int givenHeight) 
    {
        // create a cube at 0,0,0 (Vector3.zero)
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        // move the cube to a different position
        cube.transform.position = new Vector3(0, givenHeight, 0);
    }

    // create a new function that accepts one parameter, an int, named givenNum.
    // have it double the number and send it to Debug.Log()
    // it doesn't need to return anything.
    // call this function from Start three times, with different numbers.
    // function names should use UpperCamelCase (aka PascalCase)

    void Double(int givenNum) {
        givenNum = givenNum * 2;
        Debug.Log("GivenNum x 2 = " + givenNum);
    }


}       // end of the entire script
