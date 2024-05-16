using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    //  Prototype of item to throw.
    public Rigidbody2D itemProto = null;
    public float speed = 1.0f;      //  Speed of the thrown object.
    public Transform firePoint;     //  And where it starts (not in the middle of player)

    public Rigidbody2D player;

    public int itemPoolSize = 6;   //  Size of object pool.
    public List<Rigidbody2D> itemPool;  //  And storage for object pool.
    
    //  Limit of time before we disable the object.
    public float timeLimit = 2.0f;
    public float timeEllapsed = 0.0f;   //  Time since we were enabled (counter)


    //  When enabled we set the timer to zero
    void OnEnable() {
        this.timeEllapsed = 0.0f;
    }


    // Start is called before the first frame update
    void Start()
    {
        //  Initialize object pool
        itemPool = new List<Rigidbody2D>();
        player = this.GetComponent<Rigidbody2D>();

        //  Every item is a copy of the item prototype
        for(int i=0; i<itemPoolSize; i++) {
            Rigidbody2D itemClone = Instantiate(itemProto);
            itemClone.gameObject.SetActive(false);

            itemPool.Add(itemClone);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.timeEllapsed += Time.deltaTime;

        //  If it reaches limit, we disable self.
        if(timeEllapsed > timeLimit) {
            //  Get if there was a corresponding input.
            if(Input.GetButtonDown("Fire1")) {
                throwItem();
                this.timeEllapsed = 0.0f;
            }
        }
    }

    void throwItem() {
        //  Find something to thor that is not in use.
        Rigidbody2D itemClone = getItemFromPool();
        itemClone.transform.position = firePoint.position;

        if(player.transform.localScale.x == -1){
            Vector3 theScale = itemClone.transform.localScale;
            theScale.x = -1;
            itemClone.transform.localScale = theScale;
        }

        if(player.transform.localScale.x == 1){
            Vector3 theScale = itemClone.transform.localScale;
            theScale.x = 1;
            itemClone.transform.localScale = theScale;
        }
        //  Activate it
        itemClone.gameObject.SetActive(true);
        
        //  Set parameters
        float direction = CharacterMovement.facingRight ? +1 : -1;

        //  And throw
        Vector3 force = transform.right * speed * direction;
        itemClone.velocity = force;

    }

    //  Function to find an inactive object in the pool.
    private Rigidbody2D getItemFromPool() {
        
        foreach(Rigidbody2D item in itemPool) {
            //  Return with first inactive object.
            if(!item.gameObject.activeSelf)
            {
                return item;
            }
        }

        return null;
    }
}
