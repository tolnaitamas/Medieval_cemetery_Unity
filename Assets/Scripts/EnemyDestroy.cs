using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    //  Number of lifes enemy has at start
    public int life = 2;

    //  If we collide
    void OnCollisionEnter2D(Collision2D col) {
        //  If other game object is damaging.
        if(col.gameObject.tag=="Weapon") {
            //  Decrease life
            life--;

            //  Deactivate other. Do not remove because of object pooling!
            col.gameObject.SetActive(false);

            //  If life is zero, deactivate self.
            if(life <= 0) {
                this.gameObject.SetActive(false);
            }
        }
    }

}
