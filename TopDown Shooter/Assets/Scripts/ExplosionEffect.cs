using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ExplosionEffect : MonoBehaviour
{
    public void showExplosion()
    {
        ObjectPool.GetInstance().requestObject(PoolObjectType.EXPLOSION).activate(transform.position, Quaternion.identity);
    }
}
