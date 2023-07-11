using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Nilai X Kiri dan Kanan Spawner")]
    public float leftX;
    public float rightX;
    public ObjectSpawnRate[] enemies;
    [SerializeField] List<GameObject> enemyList;

    [Header("Delay Waktu Spawn")]
    public int delay;
    void Start()
    {
        enemyList = new List<GameObject>();
        StartCoroutine(spawner());
    }

    private IEnumerator spawner()
    {
        while (true)
        {
            if (MyCode.GameManager.GetInstance().isPlaying == true)
            {
                Spawn();
                yield return new WaitForSeconds(delay);
            }
            else
            {
                yield return new WaitForSeconds(delay);
            }
        }
    }

    public void Spawn()
    {
        //random range agar posisi spawn tidak disitu2 saja
        Vector3 newPosition = transform.position;
        newPosition.x = Random.Range(leftX, rightX);

        enemyList.Add(Instantiate(getEnemy(), newPosition, transform.rotation));
    }



    // Fungsi untuk mendapatkan objek musuh secara acak dari array enemy menggunakan rate spawn masing-masing musuh sebagai parameter
    private GameObject getEnemy()
    {
        // Inisiasi variabel limit dengan nilai 0
        int limit = 0;

        // Lakukan perulangan untuk setiap objek MyObjectSpawnRate pada array enemies
        foreach (ObjectSpawnRate osr in enemies)
        {
            // Tambahkan nilai rate dari objek tersebut ke variabel limit
            limit += osr.rate;
        }

        // Inisiasi variabel random dengan bilangan acak antara 0 sampai dengan limit
        int random = Random.Range(0, limit);

        // Lakukan perulangan lagi untuk setiap objek MyObjectSpawnRate pada array enemies
        foreach (ObjectSpawnRate osr in enemies)
        {

            // Cek apakah nilai random lebih kecil daripada rate dari objek saat ini
            if (random < osr.rate)
            {
                // Jika benar, return prefab dari objek ini
                return osr.prefab;

            }
            else
            {
                // Jika salah, kurangi nilai random dengan rate dari objek saat ini untuk memindahkan pengecekan ke objek berikutnya dalam array jika objek saat ini tidak terpilih
                random -= osr.rate;
            }
        }
        // Return null jika tidak ada objek yang dipilih
        return null;
    }

    //destroy semua enemy saat retry
    public void clearEnemies()
    {
        foreach (GameObject go in enemyList)
        {
            Destroy(go);
        }
        enemyList.Clear();
    }
}
