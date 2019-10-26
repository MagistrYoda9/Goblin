using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicJump :  IJumpRb
{
    private readonly GameObject _gameObject;
    private readonly Rigidbody2D _objectRb;
    public BasicJump(GameObject gameObject)
    {
        _gameObject = gameObject;
        _objectRb = _gameObject.GetComponent<Rigidbody2D>();
    }
    public void Jump(float jumpForce)
    {
        _objectRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
