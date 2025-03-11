using System.Collections;
using UnityEngine;

public class RocketLogic : MonoBehaviour
{
    public static RocketLogic rocketLogic;
    public GameObject vfxPrefab;

    void Awake()
    {
        rocketLogic = this;
    }

    public void RocketMethod(Vector3 position)
    {
        GameObject vfx = Instantiate(vfxPrefab, position, Quaternion.identity);
        StartCoroutine(DestroyAfterSeconds(vfx, 3));
    }

    IEnumerator DestroyAfterSeconds(GameObject obj, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(obj);
    }
}