using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private GameObject currentBullet;

    private bool isRightArrowPressing;
    private bool isLeftArrowPressing;
    private bool isSpacePressing;
    private bool canShooting;
    private bool isGameEnded;

    private const int rotationSpeed = 200;
    // Start is called before the first frame update
    void Start()
    {
        currentBullet = PoolManager.instance.GetBulletPool().GetObject();
        canShooting = true;
    }

    // Update is called once per frame
    void Update()
    {
        isLeftArrowPressing = Input.GetKey(KeyCode.LeftArrow);
        isRightArrowPressing = Input.GetKey(KeyCode.RightArrow);
        isSpacePressing = Input.GetKeyDown(KeyCode.Space);
        isGameEnded = GameManager.instance.IsGameEnded();

        if (isLeftArrowPressing && !isGameEnded)        
            currentBullet.transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
        
        if (isRightArrowPressing && !isGameEnded)        
            currentBullet.transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed);

        if (isSpacePressing && canShooting && !isGameEnded)
            StartCoroutine(Shoot());
    }
    private IEnumerator Shoot() 
    {
        canShooting = false;
        currentBullet.GetComponent<BulletBehaviour>().Fire();
        
        var lastBulletRotation = currentBullet.transform.rotation;

        yield return new WaitForSeconds(0.2f);
        canShooting = true;
        currentBullet = PoolManager.instance.GetBulletPool().GetObject();
        currentBullet.transform.rotation = lastBulletRotation;
    }
}
