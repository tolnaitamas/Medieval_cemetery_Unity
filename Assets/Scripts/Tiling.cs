using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiling : MonoBehaviour
{
    //  Left and right direction on X axis
    public const int LEFT = -1;
    public const int RIGHT = 1;

    //  Border at edge of creen
	public int offsetX = 2;			// the offset so that we don't get any weird errors

    // these are used for checking if we need to instantiate stuff
	public bool hasARightBuddy = false;
	public bool hasALeftBuddy = false;

    public bool reverseScale = false;	// used if the object is not tilable

    private float spriteWidth = 0f;		// the width of our element
	private Camera cam;                 //  We are tracking camera movement
	private Transform myTransform;      //  Our own transform (Where are we?)

    void Awake() {
        //  Get position of main camera and our selves
        cam = Camera.main;
        myTransform = transform;
    }


    // Start is called before the first frame update
    void Start()
    {
        //  Get the width of the image of the cirrent background
        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
		spriteWidth = Mathf.Abs(sRenderer.sprite.bounds.size.x * myTransform.localScale.x);
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasALeftBuddy || !hasARightBuddy) {
            // calculate the cameras extend (half the width) of what the camera can see in world coordinates
			float camHorizontalExtend = cam.orthographicSize * Screen.width/Screen.height;

            // calculate the x position where the camera can see the edge of the sprite (element)
			float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth/2) - camHorizontalExtend;
   			float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth/2) + camHorizontalExtend;

            // checking if we can see the edge of the element and then calling MakeNewBuddy if we can
            if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && !hasARightBuddy) {
                makeNewBuddy(RIGHT);
				hasARightBuddy = true;
            }
            else if(cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && !hasALeftBuddy) {
                makeNewBuddy (LEFT);
				hasALeftBuddy = true;
            }
        }
    }
    
    // a function that creates a buddy on the side required
    void makeNewBuddy(int rightOrLeft) {
        // calculating the new position for our new buddy
		Vector3 newPosition = new Vector3 (myTransform.position.x + spriteWidth * rightOrLeft,
                                           myTransform.position.y, myTransform.position.z);

        // instantating our new body and storing him in a variable
		Transform newBuddy = Instantiate(myTransform, newPosition, myTransform.rotation) as Transform;

        // if not tilable let's reverse the x size og our object to get rid of ugly seams
		if (reverseScale == true) {
			newBuddy.localScale = new Vector3 (newBuddy.localScale.x*-1,
                                               newBuddy.localScale.y,
                                               newBuddy.localScale.z);
        }

        //  New buddy has a buddy (that we are).
        newBuddy.parent = myTransform.parent;
        if (rightOrLeft > 0) {
			newBuddy.GetComponent<Tiling>().hasALeftBuddy = true;
		}
		else {
			newBuddy.GetComponent<Tiling>().hasARightBuddy = true;
		}
    }
}
