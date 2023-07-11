using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class PlayerController : MonoBehaviour
{
    //Assign script MyInputHandle.cs agar bisa berkomunikasi
    public InputHandler myInputHandler;

    private Moveable moveable;
    private Animator anim;
    void Awake()
    {
        moveable = GetComponent<Moveable>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        anim.SetFloat("direction", moveable.getXDirection());
    }

    private void OnSetDirect(Vector2 direction)
    {
        moveable.setDirection(direction);
    }

    private void OnEnable()
    {
        //+= subscribe funtion OnSetDirect ke Unity Action, jadi dia kepanggil
        myInputHandler.OnSetDirectionAction += OnSetDirect;
    }

    private void OnDisable()
    {
        //-= subscribe funtion OnSetDirect ke Unity Action, jadi dia ga kepanggil
        myInputHandler.OnSetDirectionAction -= OnSetDirect;
    }

}
