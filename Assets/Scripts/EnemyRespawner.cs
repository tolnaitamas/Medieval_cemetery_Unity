using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawner : Respawner
{
    //  Data to be stored on start
    public int original_life;       //  Original life of enemy

    // On start
    protected override void Start()
    {
        //  Run start of superclass
        base.Start();

        //  Store the life of enenmy
        original_life = this.GetComponent<EnemyDestroy>().life;
    }

    //  If respawning
    public override void Respawn() {
        //  Call Respawning script of superclass
        base.Respawn();

        //  Restore life to original value
        this.GetComponent<EnemyDestroy>().life = original_life;
    }
}
