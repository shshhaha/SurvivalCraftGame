using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleBullet : MonoBehaviour
{
    //투사체 오브젝트
    private GameObject projectile;
    //비활성화 오브젝트
    private Queue<GameObject> projectileQueue = new Queue<GameObject>();
    //활성화 오브젝트
    private Queue<GameObject> onFieldprojectileQueue = new Queue<GameObject>();

    /// <summary>
    /// 오브젝트 풀링 시스템 생성 (오브젝트 생성 시 반드시 호출)
    /// </summary>
    /// <param name="projectileObject">투사체 오브젝트</param>
    /// <param name="size">큐 사이즈</param>
    public void MakeProjectileSystem(GameObject projectileObject, int size)
    {
        projectile = projectileObject;  //투사체 오브젝트 설정
        if (projectile != null)
        {
            for (int i = 0; i < size; i++)   //설정된 크기만큼 투사체를 큐에 삽입
            {
                GameObject newProjectile = Instantiate(projectile);
                newProjectile.SetActive(false);
                projectileQueue.Enqueue(newProjectile);
            }
        }
    }

    /// <summary>
    /// 투사체 발사. return값은 반드시 null 예외처리 필요
    /// </summary>
    /// <param name="firePos">발사 위치</param>
    /// <param name="fireAngle">발사 각도</param>
    /// <param name="speed">투사체 속도</param>
    /// <param name="range">투사체 사거리</param>
    /// <param name="size">투사체 크기</param>
    /// <param name="rotation">투사체 rotation값</param>
    /// <returns>발사한 투사체 오브젝트</returns>
    public GameObject ProjectileFiring(Vector3 firePos, Vector3 fireAngle, float speed, float range, Vector3 size, Quaternion rotation)
    {
        //거리로 projectile 회수 시간 설정
        float projectileReturnTime;
        if (range <= 0f || speed <= 0f)
        {
            Debug.Log("Range or Speed is zero");
            return null;
        }
        else
        {
            projectileReturnTime = range / speed;
        }
        GameObject makedProjectile = GetProjectileFromQueue();        //projectile의 Queue에서 가져옴
        makedProjectile.transform.position = firePos;                 //projectile의 발사될 위치 설정
        makedProjectile.transform.rotation = rotation;                //projectile의 rotation값 설정
        makedProjectile.transform.transform.localScale = size;        //projectile의 크기 설정
        Rigidbody2D rb = makedProjectile.GetComponent<Rigidbody2D>(); //리지드바디
        if (rb == null)
        {
            Debug.LogError("projectile's Rigidbody2D is null");
            return null;
        }
        rb.velocity = fireAngle * speed;                                                           //발사 속도 및 각도 설정

        StartCoroutine(ReturnProjectileToQueueCoroutine(makedProjectile, projectileReturnTime));   //지정된 시간 후 풀링하여 큐에 삽입

        return makedProjectile;                                                                    //투사체 오브젝트의 추가적 수정은 return값 이용
    }

    /// <summary>
    /// 특정 위치로 투사체 발사.
    /// </summary>
    /// <param name="firePos"></param>
    /// <param name="targetPos"></param>
    /// <param name="speed"></param>
    /// <param name="range"></param>
    /// <param name="size"></param>
    /// <param name="rotation"></param>
    /// <returns></returns>
    public GameObject ProjectileFiringForLocation(Vector3 firePos, Vector3 targetPos, float speed, float range, Vector3 size, Quaternion rotation)
    {
        Vector3 direction = targetPos - firePos;
        direction.z = 0;
        Vector3 fireAngle = direction.normalized;

        return ProjectileFiring(firePos, fireAngle, speed, range, size, rotation);
    }

    /// <summary>
    /// 총알 전체 Destroy
    /// </summary>
    public void DestroyAllProjectiles()
    {
        foreach (GameObject projectile in projectileQueue)
        {
            Destroy(projectile);
        }
        foreach (GameObject projectile in onFieldprojectileQueue)
        {
            Destroy(projectile);
        }
        projectileQueue.Clear();
        onFieldprojectileQueue.Clear();
    }

    /*--------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

    //파괴 시 전체 총알 삭제
    private void OnDisable()
    {
        DestroyAllProjectiles();
    }

    /// <summary>
    /// projectileQueue에서 발사체 가져오기
    /// </summary>
    /// <returns></returns>
    private GameObject GetProjectileFromQueue()
    {
        if (projectileQueue.Count > 0)  //큐에 사용 가능한 여분 투사체가 남아있다면
        {
            GameObject projectile = projectileQueue.Dequeue();   //Dequeue 후 사용
            if (projectile == null)
            {
                DestroyAllProjectiles();     //씬 변경 등을 이유로 null을 반환하면 큐 초기화
                return Instantiate(this.projectile);
            }
            projectile.SetActive(true);
            return projectile;
        }
        else  //만약 큐에 여분 투사체가 없다면
        {
            return Instantiate(projectile);   //새로 생성
        }
    }

    /// <summary>
    /// 발사한 발사체를 pool하여 큐에 Enqueue
    /// </summary>
    /// <param name="projectile"></param>
    /// <param name="delay"></param>
    /// <returns></returns>
    private IEnumerator ReturnProjectileToQueueCoroutine(GameObject projectile, float delay)
    {
        onFieldprojectileQueue.Enqueue(projectile);
        yield return new WaitForSeconds(delay);
        GameObject returnProjectile = onFieldprojectileQueue.Dequeue();
        if (returnProjectile == null)
        {
            yield break;
        }
        returnProjectile.SetActive(false);
        projectileQueue.Enqueue(returnProjectile);
    }

//------------------------------------------------------------------------------------------

    // 총알속도가 프레임단위 속도보다 빠를 경우 그 사이에 있는 오브젝트가 무시될 수 있음
    // 그때 사이에 있는 오브젝트를 놓치지 않기 위해 사용
    // private IEnumerator RayCastPerFrame()
    // {
    //     yield return new WaitForEndOfFrame();
    //     while (true)
    //     {
    //         frontPos = transform.position;
    //         yield return new WaitForEndOfFrame();
    //         rearPos = transform.position;

    //         RaycastHit2D[] hits = Physics2D.LinecastAll(frontPos, rearPos, attackableLayer);
    //         GameObject closestObject = null;
    //         float closestDistance = float.MaxValue;
    //         foreach (RaycastHit2D hit in hits)
    //         {
    //             if (hit.collider != null)
    //             {
    //                 float distance = Vector2.Distance(frontPos, hit.point);
    //                 if (distance < closestDistance)
    //                 {
    //                     closestDistance = distance;
    //                     closestObject = hit.collider.gameObject;
    //                 }
    //             }
    //         }
    //         if (closestObject != null)
    //         {
    //             TriggingBullet(closestObject);
    //             gameObject.SetActive(false);
    //         }
    //     }
    //}


}
