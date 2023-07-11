using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class MoveRandomDirection : MonoBehaviour
{
    private Moveable moveable;
    private void Awake()
    {
        moveable = GetComponent<Moveable>();
    }

    void Start()
    {

        moveable.setDirection(randomDirection(), randomDirection());
    }


    //random range untuk arah yang berbeda
    private float randomDirection()
    {
        return Random.Range(.1f, 1);
    }
}
