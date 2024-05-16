using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeChange2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHurt>().life == 1)
        {
            this.gameObject.SetActive(false);
        }
    }
}
