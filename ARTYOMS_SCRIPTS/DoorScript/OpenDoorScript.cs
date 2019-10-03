using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour
{
    public bool openDoor = false;
    public BoxCollider2D thisBoxCollider;
    public SpriteRenderer thisSpriteRenderer;
    public Sprite doorOpenLeft;
    public Sprite doorOpenRight;
    public Sprite doorClosed;

    void Start()
    {
        thisSpriteRenderer = GetComponent<SpriteRenderer>();
        thisBoxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }

    void OnMouseDown()
    {
            if (openDoor == false && LeftOpenDoorCollider.atLeftSide == true)
            {
                thisSpriteRenderer.sprite = doorOpenLeft;
                thisBoxCollider.isTrigger = true;
                openDoor = true;
            }
            else if (openDoor == false && RightOpenDoorCollider.atRightSide == true)
            {
                thisSpriteRenderer.sprite = doorOpenRight;
                thisBoxCollider.isTrigger = true;
                openDoor = true;
            }
            else if (openDoor == true)
            {
                thisSpriteRenderer.sprite = doorClosed;
                thisBoxCollider.isTrigger = false;
                openDoor = false;
            }
    }
}
