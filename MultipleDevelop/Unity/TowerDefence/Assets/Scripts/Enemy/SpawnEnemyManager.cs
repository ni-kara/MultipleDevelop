using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{
    private const float spawnEnemyTime = 1.5f;

    private Coroutine coroutine;
    enum DirectionType { Left, Right, Up, Down }

    void Start()=>    
      coroutine= StartCoroutine(SpawnEnemy());

    public IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnEnemyTime);

            if (GameManager.instance.IsGameEnded())
                StopCoroutine(coroutine);

            var enemy = PoolManager.instance.GetEnemyPool().GetObject();
            enemy.transform.position = GetSpawnPosition();
        }
    }

    // Left  (-10, 5 .. -5)
    // Right (10, 5 .. -5)
    // Up    (10 .. -10, 6)
    // Down  (10 .. -10,-6)
    private Vector2 GetSpawnPosition()
    {
        Vector2 position = Vector2.zero;
        var rndValueType = (DirectionType)Random.Range(0, 4);
        switch (rndValueType)
        {
            case DirectionType.Left:
                position.x = -10;
                position.y = Random.Range(-5f, 5f);
                break;
            case DirectionType.Right:
                position.x = 10;
                position.y = Random.Range(-5f, 5f);
                break;
            case DirectionType.Up:
                position.x = Random.Range(-10f, 10f);
                position.y = 6;
                break;
            case DirectionType.Down:
                position.x = Random.Range(-10f, 10f);
                position.y = -6;
                break;
        }
        return position;
    }
}
