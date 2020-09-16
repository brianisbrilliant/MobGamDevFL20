using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    void Update()
    {
        this.transform.Rotate(0,0, 180 * Time.deltaTime);
    }
}
