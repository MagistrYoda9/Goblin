using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightOpenDoorCollider : MonoBehaviour
{
    public static bool atRightSide = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            atRightSide = true;
            LeftOpenDoorCollider.atLeftSide = false;
        }
    }
}
