using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
	Rigidbody ballRigidBody;
	public bool shot = false;

    void Start()
    {
		ballRigidBody = GetComponent<Rigidbody>();
	}

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
				Vector3 forceVector = Camera.main.transform.forward;
				forceVector.y *= 1.25f;
				ballRigidBody.AddForce(150f * forceVector);
			}
		}
	}
}
