using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    public GameObject[] life;
    public ScriptableInteger lifeScriptable;
    void Start()
    {

    }

    void Update()
    {
        for (int i = 0; i < life.Length; i++)
        {
            if (i < lifeScriptable.value)
            {
                life[i].SetActive(true);
            }
            else
            {
                life[i].SetActive(false);
            }
        }
    }
}
