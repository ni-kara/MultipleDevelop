using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private const float speedBullet = 5f;

    private Coroutine coroutine;

    void Update()
    {
        float distanceBulletToBase = Vector2.Distance(gameObject.transform.position, GameManager.instance.GetBasePosition());
        if (distanceBulletToBase > 10)
            DestroyBullet();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
            DestroyBullet();        
    }

    private void DestroyBullet()
    {
        StopCoroutine(coroutine);
        gameObject.transform.position = GameManager.instance.GetBasePosition();
        PoolManager.instance.GetBulletPool().ReturnObject(gameObject);
    }

    public void Fire() =>
        coroutine = StartCoroutine(FireMechanism());

    private IEnumerator FireMechanism()
    {
        while (true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speedBullet);
            yield return new WaitForEndOfFrame();
            if (GameManager.instance.IsGameEnded())
                StopCoroutine(coroutine);
        }
    }

        
}
