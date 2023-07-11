using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{
    // Ini adalah fungsi untuk menambahkan komponen MyWeaponUpgrade dan melakukan pengecekan pada upgrade senjata
    public void addComponentToObject(GameObject go)
    {
        // Menambahkan komponen MyWeaponUpgrade pada game object yang diberikan sebagai parameter
        go.AddComponent<WeaponUpgrade>();

        // Mengambil komponen MyWeaponSetController dari game object yang diberikan dan memanggil fungsi weaponUpgradeCheck() untuk melakukan pengecekan pada upgrade senjata
        go.GetComponent<WeaponSetController>().weaponUpgradeCheck();
    }
}
