using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  Central manager script for controlling game reset (respawning).
public class RespawnManager : MonoBehaviour
{
    //  There is a list of object to respawn.
    public List<Respawner> respawnableObjects;

    // On Awake, we clear the list.
    // List will be filled by running game as Start() time.
    void Awake()
    {
        respawnableObjects = new List<Respawner>();
    }

    //  If we decide to reset the game.
    public void ResetGame() {
        //  Log a messeage
        Debug.Log("Resetting Game");

        //  Notify each respawner scripts to do their jobs.
        foreach(Respawner resp in this.respawnableObjects) {
            resp.Respawn();
        }
    }

    //  Respawners can call this script from the outside to register.
    public void register(Respawner resp) {
        //  If someaone want to register, store it in the list of Respawnables.
        this.respawnableObjects.Add(resp);
    }
}
