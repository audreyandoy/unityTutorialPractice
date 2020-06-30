using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser: MonoBehaviour {

	private Transform bullet;
	public float speed;

	// Use this for initialization
	void Start () {
		bullet = GetComponent<Transform> ();
	}

	void FixedUpdate(){
		bullet.position += Vector3.up * -speed;

		if (bullet.position.y <= -10)
			Destroy (bullet.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			Destroy (other.gameObject);
			Destroy (gameObject);
            print("game Over");
	    }
    }
}