using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//diletakkan pada gameobject Weapon
public class LookAtPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lookAt();
    }

    void lookAt()
    {
        //jika activePlayer tidak kosong / player ada
        if (MyCode.GameManager.GetInstance().activePlayer != null)
        {
            // pastikan Gameobject activePlayer sudah dipublic agar bisa diakses
            transform.up = MyCode.GameManager.GetInstance().activePlayer.transform.position - transform.position;
        }

    }
}