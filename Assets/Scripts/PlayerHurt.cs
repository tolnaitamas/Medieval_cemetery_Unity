using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  Component to controll when player is hurt
public class PlayerHurt : MonoBehaviour
{
    //  Set the life of player. (Can be changed from editor.)
    public int life = 3;

    private Rigidbody2D rb;
    void Start()
    {
        //  Look the rigidbody2D up.
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Check height in every frame
    void Update()
    {


        return;
    }

    //  If we hit somthing
    void OnCollisionEnter2D(Collision2D col) {
        //  Touching an enemy can hurt.
        if(col.gameObject.tag=="Enemy") {
            //  Decrease life.
            life--;

            //  Reset game if we ran out of lifes.
            if(life <= 0) {
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<RespawnManager>().ResetGame();
            }
        }
        if(col.gameObject.tag=="Spike") {
            //  Decrease life.
            life = 0;

            //  Reset game if we ran out of lifes.
            if(life <= 0) {
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<RespawnManager>().ResetGame();
            }
        }
    }

}
