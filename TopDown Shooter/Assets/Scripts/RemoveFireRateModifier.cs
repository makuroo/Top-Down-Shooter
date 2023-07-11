using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveFireRateModifier : MonoBehaviour
{
    public FireRateModifier[] modifier;
    private void Start()
    {
        ClearModifier();
    }

    public void ClearModifier()
    {
        modifier = GetComponents<FireRateModifier>();

        if (modifier.Length> 1)
        {
            for (int i = 0; i < modifier.Length - 1; i++)
            {
                Destroy(modifier[i]);
            }
        }
    }

}