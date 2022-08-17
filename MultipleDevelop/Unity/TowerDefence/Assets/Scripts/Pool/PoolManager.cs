using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance; 
    [SerializeField] private Pooling bulletPool;
    [SerializeField] private Pooling enemyPool;

    private void Awake() =>
        instance = this;

    private void Start()
    {
        bulletPool.InitPool(20);
        enemyPool.InitPool(30);
    }

    public Pooling GetBulletPool() =>
        bulletPool;

    public Pooling GetEnemyPool() =>
      enemyPool;
}

