using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Input Handler", menuName = "Create Input Handler")]
public class InputHandler : ScriptableObject, Player.IGameplayActions
{
    private Player input;

    //11b. Menggunakan Unity Action untuk menghubungkan ke Player Controller 
    public UnityAction<Vector2> OnSetDirectionAction; //ini menyimpan class

    public UnityAction OnPauseAction;
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OnPauseAction?.Invoke();
        }
    }

    //3a. Membuat function OnEnable, untuk assign CustomInput ke input
    private void OnEnable()
    {
        //3b. Untuk assign CustomInput ke input
        if (input == null)
        {
            input = new Player();
        }

        //5. Segala macam action akan di handle di class ini (this)
        input.Gameplay.SetCallbacks(this);

        //6. Gameplay itu Action Maps tadi 
        input.Gameplay.Enable();
    }

    //7.Ketika aplikasi sdg disable, maka disable jg input yang diterima
    private void OnDisable()
    {
        input.Gameplay.Disable();
    }

    public void OnSetDirection(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();

        // 9. Debug.Log untuk lihat tombol dipencet
        //terima value vector 2 dari Set Direction + mendapatkan phase dari tombol
        // phase ditombol : ketikan baruditekan (started), ditekan (performed), diangkat(canceled)
       //Debug.Log(" Set Direction " + context.ReadValue<Vector2>() + context.phase);

        //10. Kita akan pakai pas tombol saat Performed atau Canceled (note : kalau Canceled gak dippakai akan jalan terus)
        if (context.phase == InputActionPhase.Performed || context.phase == InputActionPhase.Canceled)
        {
            //11c.Semua function yg ada di OnSetDirectionAction akan diinvoke / dipanggiil
            // dapat menambahkan tanda setelah OnSetDirectionAction? untuk cek dulu, jadi kalo kosong tidak di invoke

            //12. menambahkan context.ReadValue<Vector2>() di parameter  OnSetDirectionAction?.Invoke();
            //12b. menambahkan <Vector2>  menjadi public UnityAction<Vector2> public UnityAction<Vector2> OnSetDirectionActio
            OnSetDirectionAction?.Invoke(context.ReadValue<Vector2>());

        }
    }
}
