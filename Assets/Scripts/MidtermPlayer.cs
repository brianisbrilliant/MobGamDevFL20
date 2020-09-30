using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MidtermPlayer : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource aud;
    public AudioClip jump, attack;

    [Header("Jump")]
    public float jumpForce = 10;
    

    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    public void Jump(){
        Debug.Log("Jump!");
        rb.AddRelativeForce(Vector3.up * jumpForce, ForceMode.Impulse);
        aud.PlayOneShot(jump);      // this can stack up to 14 times.
    }

    public void Attack(){
        Debug.Log("Attack!");
        aud.PlayOneShot(attack);
    }


}
