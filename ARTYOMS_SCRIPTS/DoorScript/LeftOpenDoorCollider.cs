using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftOpenDoorCollider : MonoBehaviour
{
    public static bool atLeftSide = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            atLeftSide = true;
            RightOpenDoorCollider.atRightSide = false;
        }
    }
}
