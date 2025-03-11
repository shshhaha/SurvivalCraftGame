using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionVFPool : MonoBehaviour
{
    public static BulletCollisionVFPool sharedInstance;
    public GameObject vfxPrefab;
    public int poolSize = 5;
    private Queue<GameObject> vfxPool;

    void Awake()
    {
        sharedInstance = this;
        vfxPool = new Queue<GameObject>(poolSize);

        for (int i = 0; i < poolSize; i++)
        {
            GameObject vfx = Instantiate(vfxPrefab);
            vfx.SetActive(false);
            vfxPool.Enqueue(vfx);
        }
    }

    public GameObject GetVFX(Vector3 position)
    {
        GameObject vfx;
        if (vfxPool.Count > 0)
        {
            vfx = vfxPool.Dequeue();
        }
        else
        {
            vfx = Instantiate(vfxPrefab);
            vfxPool.Enqueue(vfx);
        }

        vfx.transform.position = position;
        vfx.SetActive(true);
        ParticleSystem ps = vfx.GetComponent<ParticleSystem>();
        ps.Stop();
        ps.Clear();
        ps.Play();

        StartCoroutine(ReturnVFXAfterSeconds(vfx, 1));

        return vfx;
    }
    public void ReturnVFX(GameObject vfx)
    {
        vfx.SetActive(false);
        vfxPool.Enqueue(vfx);
    }

    IEnumerator ReturnVFXAfterSeconds(GameObject vfx, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ReturnVFX(vfx);
    }
}