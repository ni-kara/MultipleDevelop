using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    void Update()
    {
        if (!GameManager.instance.IsGameEnded())
            gameObject.transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PoolManager.instance.GetEnemyPool().ReturnObject(gameObject);

        if (collision.tag.Equals("Player"))
            HealthBarManager.instance.TakeDamage();       
        
        if (!collision.tag.Equals("Player"))
            EnemyManager.instance.KillEnemy();        

    }
}

