using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float min_X, max_X;

    // strict shooting
    public float shoot_Timer = 0.35f;
    private float current_Shoot_Timer;
    private bool canShoot;

    [SerializeField]
    private GameObject player_Laser;
    
    [SerializeField]
    private Transform attack_Point;
    // Start is called before the first frame update
    void Start()
    {
       current_Shoot_Timer = shoot_Timer;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Attack();
    }

    void MovePlayer() {

        float h = Input.GetAxisRaw("Horizontal");
 
        GetComponent<Rigidbody2D>().velocity = new Vector2(h, 0) * speed;
        
        // if(Input.GetAxisRaw("Horizontal") > 0) {
        //     Vector3 temp = transform.position;
        //     temp.x += speed * Time.deltaTime;

        //     if(temp.x > max_X)
        //         temp.x = max_X;

        //     transform.position = temp;

        // } else if (Input.GetAxisRaw("Horizontal") < 0) {
        //     Vector3 temp = transform.position;
        //     temp.x -= speed * Time.deltaTime;

        //     if(temp.x < min_X)
        //         temp.x = min_X;

        //     transform.position = temp;

        // }
    }

    void Attack() {
        shoot_Timer += Time.deltaTime;
        if(shoot_Timer > current_Shoot_Timer) {
            canShoot = true;
        }

        if (Input.GetKeyDown(KeyCode.K)) {
            if(canShoot) {
                canShoot = false;
                shoot_Timer = 0f;
                // attack_Point.rotation = Quaternion.Euler(0,0,-90);
                Instantiate(player_Laser, attack_Point.position, Quaternion.identity);
                // pew pew SFX
            }
        }
    } // attack
} // class
