using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// adds a rigidbody component
[RequireComponent(typeof(Rigidbody))]           
public class PlayerController : MonoBehaviour
{
    [Range(5,50)]
    public float jumpSpeed = 50f;
    [Range(.25f,5)]
    public float fallSpeedMultiplier = 1f;
    [Range(1,20)]
    public float forwardSpeed = 5f;

    Rigidbody rb;
    bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player Controller Starting Up!");

        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Time since last frame = " + Time.deltaTime);

        if(Input.anyKeyDown) Jump();
    }

    // FixedUpdate is for phyiscs, it runs 50 times / second.
    void FixedUpdate() {
        // Debug.Log("Fixed Update frame time = " + Time.deltaTime);

        // adding forward force
        rb.AddRelativeForce(Vector3.right * forwardSpeed);

        if(isGrounded == false) {
            rb.AddRelativeForce(Vector3.down * jumpSpeed * fallSpeedMultiplier);
        }
    }

    void Jump() {
        if(isGrounded) {
            rb.AddRelativeForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }
}
