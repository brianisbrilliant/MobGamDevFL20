using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTest : MonoBehaviour
{
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown) {
            rend.material.color = UnityEngine.Random.ColorHSV();
            this.transform.localScale += Vector3.one * .2f;
            Debug.Log("ASDF");
            Debug.Log("Trying to commit via cmd.");
        }
    }
}
