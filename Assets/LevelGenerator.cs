using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        cube.transform.localScale = Vector3.one * cubeSize * Random.Range(cubeRange.x, cubeRange.y);
        cube.transform.rotation = Random.rotation;
    }

    IEnumerator BuildCubes() {
        for(int i = 0; i <= maxCubes; i += cubeZInterval) {
            BuildCube(i);
            yield return new WaitForSeconds(buildCubesWaitTime);
        }
    }
}
