using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//berguna untuk kedap kedip alpha dan mematikan collider sementara
public class InvincibleFrame : MonoBehaviour
{
    public float duration;

    private float timer;

    void Update()
    {
        timer = timer - Time.deltaTime < 0 ? 0 : timer - Time.deltaTime;
    }

    //panggil function ini
    public void activate()
    {
        timer = duration;
        StartCoroutine(blinking());
        deactivateCollider();
    }

    private void deactivateCollider()
    {
        GetComponent<Collider2D>().enabled = false;
    }

    private void activateCollider()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    //script memainkan alpha untuk kedap kedip
    private IEnumerator blinking()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        Color defaultColor = sr.color;
        Color hitColor = defaultColor;
        hitColor.a = 0.5f;

        while (timer > 0)
        {
            sr.color = hitColor;
            yield return new WaitForSeconds(0.1f);
            sr.color = defaultColor;
            yield return new WaitForSeconds(0.1f);
        }
        sr.color = defaultColor;
        activateCollider();
    }
}
