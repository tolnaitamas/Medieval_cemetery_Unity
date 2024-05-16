using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveByTime : MonoBehaviour
{
    //  Limit of time before we disable the object.
    public float timeLimit = 2.0f;
    public float timeEllapsed = 0.0f;   //  Time since we were enabled (counter)

    //  When enabled we set the timer to zero
    void OnEnable() {
        this.timeEllapsed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //  Increase timer
        this.timeEllapsed += Time.deltaTime;

        //  If it reaches limit, we disable self.
        if(timeEllapsed > timeLimit) {
            this.gameObject.SetActive(false);
        }
    }
}
