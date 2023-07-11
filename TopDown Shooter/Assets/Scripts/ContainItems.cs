using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//diletakkan pada enemy, berguna untuk menampung item yang akan keluar jika enemny mati, serta mengatur random item tersebut keluar atau tidak
public class ContainItems : MonoBehaviour
{
    public List<ObjectSpawnRate> objects;

    void Start() { }

    void Update() { }

    public void spawnItemOnDeath()
    {
        GameObject go = getItem();
        //Instantiate(go);
        if (go != null)
        {
            MyCode.GameManager.GetInstance().addItem(Instantiate(go, transform.position, Quaternion.identity));
        }
    }

    // Fungsi ini akan menghasilkan objek secara acak berdasarkan rate-nya
    private GameObject getItem()
    {

        // Inisialisasi variabel limit dengan nilai awal 0
        int limit = 0;

        // Looping pada setiap ObjectSpawnRate dalam array objects
        foreach (ObjectSpawnRate osr in objects)
        {
            limit += osr.rate;  // Menambahkan nilai rate pada variabel limit
        }

        // Menghasilkan bilangan acak antara 0 hingga limit
        int random = Random.Range(0, limit);

        // Looping kembali pada setiap ObjectSpawnRate dalam array objects
        foreach (ObjectSpawnRate osr in objects)
        {

            // Memeriksa apakah nilai random lebih kecil daripada nilai rate dari objek saat ini
            if (random < osr.rate)
            {

                return osr.prefab;  // Jika ya, mengembalikan prefab dari objek saat ini

            }
            else
            {

                random -= osr.rate;  // Jika tidak, mengurangi nilai random dengan nilai rate dari objek saat ini

            }
        }

        return null;  // Jika semua objek telah diperiksa dan tidak ada yang terpilih, maka fungsi akan mengembalikan null
    }


}
