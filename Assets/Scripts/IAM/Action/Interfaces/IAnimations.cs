using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimations
{
    void MovementAnimation(string boolName, bool isActive, float direction);
    void JumpAnimations();
    void AttackAnimations();
}
