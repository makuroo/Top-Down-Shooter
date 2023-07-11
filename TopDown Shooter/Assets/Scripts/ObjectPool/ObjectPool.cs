using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script ini diletakkan pada gameobject kosong dgn nama Object Pooling
public class ObjectPool : MonoBehaviour
{
    private static ObjectPool instance;

    public int size; //seberapa banyak setiap gameobject
    public GameObject[] prefabs;

    public List<PoolObject> poolObjects;


    //0. membuat singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static ObjectPool GetInstance()
    {
        return instance;
    }

    //0 batas singleton

    void Start()
    {
        instantiateObjects();
    }


    //1. berguna untuk membuat beberapa object dalam sebuah pool
    private void instantiateObjects()
    {
        poolObjects = new List<PoolObject>();
        for (int i = 0; i < size; i++)
        {
            foreach (GameObject go in prefabs)
            {
                //nambahin object ke list, dan get scriptnya MyPoolObject 
                // parameter transform pada Instatiate adalah parent.
                //parent pada kasus ini adalah gameobject Object Pool
                poolObjects.Add(Instantiate(go, transform).GetComponent<PoolObject>());
            }
        }
    }

    //2. request setiap gameobject pada PoolObjects
    public PoolObject requestObject(PoolObjectType type)
    {
        foreach (PoolObject po in poolObjects)
        {
            if (po.type == type && !po.isActive())
            {
                return po;
            }
        }
        return null;
    }

    //deaktivasi semua pool object untuk retry
    public void deactivateAllObject()
    {
        foreach (PoolObject po in poolObjects)
        {
            po.deactivate();
        }
    }
}
