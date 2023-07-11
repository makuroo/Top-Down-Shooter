using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; //untuk menggunakan ToList

public class FireRateModifier : MonoBehaviour
{
    public float modifier = 0.2f;

    public List<Weapon> weapons;

    //code tersebut berfungsi untuk mengambil senjata dari objek-objek anak dan menyimpannya dalam sebuah daftar. Dalam hal ini, senjata haruslah diatur menggunakan komponen "MyWeapon". Semua senjata akan didapatkan dari komponen "MyWeapon" dan kemudian disimpan dalam list.

    //Fungsi ToList() digunakan untuk mengubah array dari objek MyWeapon menjadi list, sehingga kita dapat menggunakan berbagai method yang disediakan oleh List pada objek tersebut. Karena GetComponentsInChildren() menghasilkan array daripada list,
    private void Awake()
    {
        weapons = GetComponentsInChildren<Weapon>().ToList<Weapon>();
    }

    void Start()
    {
        foreach (Weapon w in weapons)
        {
            w.addFireRateModifier(modifier);
        }
    }

    //berfungsi untuk menghapus modifier fire rate pada senjata.
    private void OnDestroy()
    {
        foreach (Weapon w in weapons)
        {
            w.removeFireRateModifier(modifier);
        }
    }

    //Kode ini menambahkan komponen bernama MyFireRateModifier ke game object yang diinput dan kemudian memeriksa senjata pada WeaponSetController.
    public void addComponentToObject(GameObject go)
    {
        go.AddComponent<FireRateModifier>();
        go.GetComponent<WeaponSetController>().weaponUpgradeCheck();
    }
}
