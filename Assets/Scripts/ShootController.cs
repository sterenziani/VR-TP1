using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
	Rigidbody ballRigidBody;
	bool shot = false;

    // Start is called before the first frame update
    void Start()
    {
		ballRigidBody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
    {
		float time = Mathf.Repeat(Time.time, 5.0f);
		if (time < 2.0)
		{
			ballRigidBody.position = new Vector3(0, 1.60f, 0); // No usar transform.position
			ballRigidBody.velocity = Vector3.zero;
			shot = false;
		}
		else
		{
			if (!shot)
			{
				shot = true;
				bool lookingUp = Camera.main.transform.forward.y >= 0;
				Vector3 forceVector = Camera.main.transform.forward;
				forceVector.y *= 1.25f;
				ballRigidBody.AddForce(150f * forceVector);
			}
		}
	}
}
