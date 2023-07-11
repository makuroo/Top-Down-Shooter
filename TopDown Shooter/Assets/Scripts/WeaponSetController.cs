using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ditambahkan ke player
public class WeaponSetController : MonoBehaviour
{
    public GameObject[] weaponSet;

    void Start()
    {
        deactivateAllWeapons();
        activateWeaponSet(0);

        weaponUpgradeCheck();
    }

    //mematkan semua gameobject Weapon Set
    private void deactivateAllWeapons()
    {
        foreach (GameObject go in weaponSet)
        {
            go.SetActive(false);
        }
    }

    //untuk menyalakan Weapon Set
    public void activateWeaponSet(int upgradeLevel)
    {
        for (int i = 0; i < weaponSet.Length; i++)
        {
            if (i == upgradeLevel)
            {
                weaponSet[i].SetActive(true);
            }
            else
            {
                weaponSet[i].SetActive(false);
            }
        }
    }

    // Ini adalah fungsi untuk mengecek upgrade senjata
    public void weaponUpgradeCheck()
    {
        // Mengambil semua komponen WeaponUpgrade yang berada pada objek ini dan menghitung jumlahnya, kemudian dimasukkan ke dalam variabel upgradeLevel bertipe integer
        int upgradeLevel = GetComponents<WeaponUpgrade>().Length;
        //Debug.Log("upgradeLevel" + upgradeLevel);
        // Melakukan pengecekan apakah nilai upgradeLevel lebih besar atau sama dengan panjang array weaponSet, jika ya maka nilai upgradeLevel akan dikurangi satu agar tidak melebihi indeks pada array weaponSet
        if (upgradeLevel >= weaponSet.Length)
        {
            upgradeLevel = weaponSet.Length - 1;
        }
        // Memanggil fungsi activateWeaponSet() dan memasukkan parameter upgradeLevel untuk mengaktifkan set senjata sesuai level upgradenya
        activateWeaponSet(upgradeLevel);

        // Memanggil fungsi fireRateUpdate() untuk mengupdate fire rate pada senjata
        fireRateUpdate();
    }

    // Ini adalah fungsi untuk mengupdate fire rate dari senjata-senjata yang dimiliki oleh game object ini
    private void fireRateUpdate()
    {
        // Mengambil semua komponen MyWeapon yang ada pada objek dan anak-anaknya, lalu menjalankan loop untuk setiap senjata tersebut
        foreach (Weapon w in GetComponentsInChildren<Weapon>())
        {
            // Membersihkan semua modifier pada senjata saat ini
            w.clearModifier();

            // Mengambil semua komponen FireRateModifier pada objek dan menjalankan loop untuk setiap komponen tersebut
            foreach (FireRateModifier f in GetComponents<FireRateModifier>())
            {
                // Menambahkan modifier kecepatan tembak dari komponen FireRateModifier ke senjata saat ini
                w.addFireRateModifier(f.modifier);
            }
        }
    }


}
