using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TiltPlayer : MonoBehaviour
{
	public float speed = 10, rotSpeed = 60;
	public TextMeshProUGUI healthText;

	Transform body;
	int health = 5;
	bool canBeHurt = true;

	void Start() {
		body = transform.GetChild(0);
	}
  
    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;

		dir.x = Input.acceleration.x;		// x to x
		dir.y = Input.acceleration.z;		// y to z
		dir.z = 1;

		// clamp acceleration vector to unit sphere
		if(dir.sqrMagnitude > 1) {
			dir.Normalize();
		}

		// make it move 10 meters per second instead of 10 meters per frame
		dir *= Time.deltaTime;

		// move object
		transform.Translate(dir * speed);
		body.Rotate(0,0,-dir.x * rotSpeed);
    }


	void OnTriggerEnter(Collider other) {
		Debug.Log("I've hit something!");
		if(canBeHurt){
			Debug.Log("I've been hurt! Health: " + health);
			health -= 1;
			healthText.text = "Health: " + health;
			if(health <= 0) {
				Application.LoadLevel(4);
			}
			Debug.Log("I've been hurt! Health: " + health);
			StartCoroutine(Invulnerable());
		}
	}

	IEnumerator Invulnerable() {
		canBeHurt = false;
		yield return new WaitForSeconds(0.5f);
		canBeHurt = true;
	}
}
