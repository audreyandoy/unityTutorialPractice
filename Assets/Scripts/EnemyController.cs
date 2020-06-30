using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	private Transform enemyGroup;
	public float speed;

	public GameObject shot;
	// public Text winText;
	public float fireRate = 0.997f;

	// Use this for initialization
	void Start () {
		// winText.enabled = false;
		InvokeRepeating ("MoveEnemy", 0.1f, 0.075f);
		enemyGroup = GetComponent<Transform> ();
	}

	void MoveEnemy()
	{
		enemyGroup.position += Vector3.right * speed;

		foreach (Transform enemy in enemyGroup) {
			if (enemy.position.x < -4.5 || enemy.position.x > 4.5) {
				speed = -speed;
				enemyGroup.position += Vector3.down * 0.095f;
				return;
			}

			//EnemyBulletController called too?
			if (Random.value > fireRate) {
				Instantiate (shot, enemy.position, enemy.rotation);
			}


			if (enemy.position.y <= -5) {
				// GameOver.isPlayerDead = true;
                print("player lost");
				Time.timeScale = 0;
			}
		}

		if (enemyGroup.childCount == 1) {
			CancelInvoke ();
			InvokeRepeating ("MoveEnemy", 0.1f, 0.25f);
		}

		if (enemyGroup.childCount == 0) {
			// winText.enabled = true;
            print("you win!");
		}
	}
}