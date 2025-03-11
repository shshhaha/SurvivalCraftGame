using DamageNumbersPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool sharedInstance;
    public GameObject bulletPrefab;
    public int poolSize = 5;
    private Queue<GameObject> bulletPool;

    void Awake()
    {
        sharedInstance = this;
        bulletPool = new Queue<GameObject>(poolSize);

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet(float range)
    {
        GameObject bullet;
        if (bulletPool.Count > 0)
        {
            bullet = bulletPool.Dequeue();
        }
        else
        {
            bullet = Instantiate(bulletPrefab);
            bullet.AddComponent<BulletCollision>();
            
            bulletPool.Enqueue(bullet);
        }

        bullet.SetActive(true);
        StartCoroutine(ReturnBulletAfterSeconds(bullet, range));
        return bullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }

    IEnumerator ReturnBulletAfterSeconds(GameObject bullet, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (bullet.activeInHierarchy)
        {
            ReturnBullet(bullet);
        }
    }
}