using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate;
    private float timer = 0;
    public PoolObjectType type;
    public List<float> fireRateModifiers;
    void Start()
    {
        timer = fireRate;
    }

    void Update()
    {

        timer = timer - Time.deltaTime > 0 ? timer - Time.deltaTime : 0f;
    }

    public void shoot()
    {
        //ini berfungsi mengatur fire rate, kala, jadi kalau sdh 0, br bs tembak 
        if (timer == 0f)
        {
            ObjectPool.GetInstance().requestObject(type).activate(transform.position, transform.rotation);

            timer = fireRate / getFireRateModifier();
        }
    }

    private float getFireRateModifier()
    {
        // Inisialisasi variabel untuk menyimpan hasil perhitungan modifier.
        // Pada awalnya, variabel tersebut diisi dengan nilai 1.
        float mod = 1;

        // Looping setiap elemen dalam array yang berisi beberapa angka-angka 'modifier'
        foreach (float f in fireRateModifiers)
        {
            // Tambahkan nilai dari variabel sementara 'f' ke dalam 'mod'.
            mod += f;
        }

        // Kembalikan nilai dari variabel 'mod' sebagai output dari fungsi ini.
        return mod;
    }


    internal void addFireRateModifier(float modifier)
    {
        fireRateModifiers.Add(modifier);
    }


    internal void clearModifier()
    {
        fireRateModifiers.Clear();
    }

    internal void removeFireRateModifier(float modifier)
    {
        fireRateModifiers.Remove(modifier);
    }

}
