using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : IMovement
{
    private readonly GameObject _gameObject;
    //true directed right, false directed left
    public BasicMovement(GameObject gameObject)
    {
        _gameObject = gameObject;
        
    }
    public void HorizontalMovement(float speed, float direction)
    {
        _gameObject.transform.Translate(Vector2.right * speed * direction * Time.deltaTime);
    }
}
