using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  Base class of respawner. Can be specialized for more complex objects.
public class Respawner : MonoBehaviour
{
    //  Basic bata we want to reset on level restart
    private Vector3 original_position;      //  Original opsition
    private bool original_active;           //  And state of activeness

    //  Respawnmanager to controlling game reset. We have to register to it.
    private RespawnManager rm;
    
    // Initializing the Respawn
    protected virtual void Start()
    {
        //  Store original values of variables we want to reset.
        original_position = this.transform.position;
        original_active = this.gameObject.activeSelf;

        //  Get Manager and notify it, that we are here.
        rm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RespawnManager>();
        rm.register(this);
    }

    //  What we want to do on respawn
    public virtual void Respawn() {
        //  Send notification to console
        Debug.Log("Object Respawning");

        //  Then reset state to original.
        this.transform.position = original_position;
        this.gameObject.SetActive(original_active);
    }
}
