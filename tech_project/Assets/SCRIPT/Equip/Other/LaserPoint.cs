using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPoint : MonoBehaviour
{
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        Material material = new Material(Shader.Find("Standard"));
        material.color = new Color(255, 0, 0, 255);
        material.EnableKeyword("_EMISSION"); // Emission을 활성화
        material.SetColor("_EmissionColor", new Color(255, 0, 0, 255)); // Emission 색상을 설정
        lineRenderer.material = material; // 라인 렌더러에 머테리얼을 설정
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.02f;
        lineRenderer.positionCount = 2;
        lineRenderer.receiveShadows = false;
        lineRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        lineRenderer.numCornerVertices = 10;
        lineRenderer.numCapVertices = 10;
        lineRenderer.enabled = false;
    }

    void FixedUpdate()
    {
        lineRenderer.SetPosition(0, transform.position);
        CheckForMonsters();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag != "Bullet") // "Bullet" 태그를 가진 오브젝트와의 충돌을 무시
            {
                lineRenderer.SetPosition(1, hit.point);
            }
            else
            {
                Vector3 endPosition = transform.position + transform.forward * 25;
                lineRenderer.SetPosition(1, endPosition);
            }
        }
        else
        {
            Vector3 endPosition = transform.position + transform.forward * 25;
            lineRenderer.SetPosition(1, endPosition);
        }
        
    }

    private void CheckForMonsters()
    {
        float distance = 18f;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, distance);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Monster"))
            {
                lineRenderer.enabled = true;
                return;
            }
        }
        lineRenderer.enabled = false;
    }
}