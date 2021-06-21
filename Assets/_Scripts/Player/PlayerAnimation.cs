using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator Animator;
    float PlayAfkAnimationAfterSeconds = 120;
    float AfkTimer;

    private void Start()
    {
        Animator = gameObject.GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        Animator.SetBool("RightorLeft", InputManager.isMoving());
    }
    bool isAFK()
    {
        if (!InputManager.isMoving())
        {
            AfkTimer += 1 * Time.deltaTime;
            if (AfkTimer > PlayAfkAnimationAfterSeconds)
            {
                AfkTimer = 0;
                return true;
            }
        }
        else
        {
            AfkTimer = 0;
        }
        return false;
    }
}
