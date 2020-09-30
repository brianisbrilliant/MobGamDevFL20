using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LevelGenerator : MonoBehaviour
{

    public float cubeSize = 15;
    public Vector2 cubeRange = new Vector2(.5f, 1.5f);
    public float translateRange = 20;
    [Header("BuildCubes()")]
    [Range(0,1f)]
    public float buildCubesWaitTime = 0.25f;
    public int maxCubes = 1000;
    public int cubeZInterval = 10;
    [Range(0.01f, 0.2f)]
    public float lerpSpeed = 0.1f;
    [Header("BuildPickups")]
    [Tooltip("Check this box if you want to build Pickups instead of Cubes.")]
    public bool buildPickups = false;

    public GameObject pickup;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BuildCubes());
    }

    void BuildCube(int zPos) {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = this.transform.position;
        cube.transform.Translate(   Random.Range(-translateRange,translateRange),   // x
                                    Random.Range(-translateRange,translateRange),   // y
                                    Random.Range(-translateRange/2,translateRange/2) + zPos);                                          // z
        StartCoroutine(GrowCube(cube.transform));
        cube.transform.rotation = Random.rotation;
        Color newColor = Random.ColorHSV(0f, .25f, 0f, 0.5f, 0.2f, 0.6f);
        cube.GetComponent<Renderer>().material.color = newColor;
    }

    IEnumerator BuildCubes() {
        for(int i = 0; i <= maxCubes; i += cubeZInterval) {
            BuildCube(i);
            yield return new WaitForSeconds(buildCubesWaitTime);
        }
    }

    IEnumerator GrowCube(Transform givenCube){
        // setting the starting scale to zero.
        givenCube.localScale = Vector3.zero;

        // setting the final scale
        Vector3 finalScale = Vector3.one * cubeSize * Random.Range(cubeRange.x, cubeRange.y);

        int counter = 0;
        while (givenCube.localScale.x < finalScale.x) {
            givenCube.localScale += (finalScale - givenCube.localScale) * 0.05f;
            yield return new WaitForEndOfFrame();
            if(counter++ > 50) {
                Debug.Log("<color=red>FinalScale.x = " + finalScale.x + "</color>, <color=blue>current localScale.x = " + givenCube.localScale.x + "</color>.");
                break;
            }
        }
    }
}
