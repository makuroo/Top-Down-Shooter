using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script ini diletakkan pada gameobject/prefab Explosion
public class ExplosionBehaviour : MonoBehaviour
{
    private Animator animator;
    private PoolObject poolObject;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        poolObject = GetComponent<PoolObject>();
    }

    void Update()
    {
        if (poolObject.isActive())
        {
            if (animationIsDone())
            {
                poolObject.deactivate();
            }
        }
    }

    private bool animationIsDone()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
        {
            return true;
        }
        return false;
    }
}
