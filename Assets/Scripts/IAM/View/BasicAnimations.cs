using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAnimations: IAnimations
{
    private Animator animator;
    private SpriteRenderer sprite;
    private readonly GameObject _gameObject;

    public BasicAnimations(GameObject gameObject)
    {
        _gameObject = gameObject;
        animator = _gameObject.GetComponent<Animator>();
        sprite = _gameObject.GetComponent<SpriteRenderer>();

    }

    public void MovementAnimation(string boolName, bool isActive, float direction)
    {
        Debug.Log(isActive);
        animator.SetBool(boolName, isActive);

        if (direction < 0)
        {
            sprite.flipX = true;
        }
        else if (direction > 0)
        {
            sprite.flipX = false;
        }
    }

    public void JumpAnimations()
    {
        throw new System.NotImplementedException();
    }

    public void AttackAnimations()
    {
        throw new System.NotImplementedException();
    }
}
