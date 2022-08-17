using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Pooling : IPool
{
    [SerializeField] private GameObject prefab;

    private Queue<GameObject> poolObj;

    public void GenerateObject()
    {
        var obj = GameObject.Instantiate(prefab);
        obj.SetActive(false);
        poolObj.Enqueue(obj);
    }

    public GameObject GetObject()
    {
        if (poolObj.Count <= 0)
            GenerateObject();
        var bulletObj = poolObj.Dequeue();
        bulletObj.SetActive(true);

        return bulletObj;
    }

    public void InitPool(int amountToPool)
    {
        poolObj = new Queue<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GenerateObject();
        }
    }

    public void ReturnObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
        poolObj.Enqueue(gameObject);
    }
}