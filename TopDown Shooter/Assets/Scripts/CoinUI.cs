using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    public GameObject text;
    public ScriptableInteger coinScriptable;

    void Start()
    {

    }

    void Update()
    {
        text.GetComponent<Text>().text = coinScriptable.value.ToString();
    }
}
