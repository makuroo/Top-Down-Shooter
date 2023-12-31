using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent OnTrigger;
    public UnityEvent<GameObject> OnTriggerWithGameobject;
    public string targetTag;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == targetTag) 
        {
            OnTrigger?.Invoke();
            OnTriggerWithGameobject?.Invoke(col.gameObject);
        }

    }
}
