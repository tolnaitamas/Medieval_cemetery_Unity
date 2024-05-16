using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRespawner : Respawner
{
    //  Data to be stored on start

    // On start
    protected override void Start()
    {
        //  Run start of superclass
        base.Start();

    }

    //  If respawning
    public override void Respawn()
    {
        //  Call Respawning script of superclass
        base.Respawn();

    }
}
