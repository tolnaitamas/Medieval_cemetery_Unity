using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  Respawner component of the player.
public class PlayerRespawner : Respawner
{
    //  What we want to store in addition to the Base Respawner
    public int original_life;

    // Store initial values on start
    protected override void Start()
    {
        //  Also call the Start of base class
        base.Start();

        original_life = this.GetComponent<PlayerHurt>().life;

    }

    //  If we need to respawn
    public override void Respawn() {
        //  Let Base class do it's job
        base.Respawn();

        //  Then reset our life.
        this.GetComponent<PlayerHurt>().life = original_life;
    }

}
