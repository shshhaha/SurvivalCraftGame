using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using sound.gunFireSound;

public class F_ThrowGrenade : MonoBehaviour
{
    public GameObject grenadePrefab; // �������� �Ҵ��� ����

    void Start()
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody>().isKinematic = false;
            Throw();
        }
    }

    public void Throw()
    {
        // �÷��̾��� ��ġ�� ȸ���� �����ɴϴ�.
        Vector3 playerPosition = transform.position;
        Quaternion playerRotation = transform.rotation;

        // �������� �����ϰ� �÷��̾��� ��ġ�� ȸ���� �����մϴ�.
        GameObject grenade = Instantiate(grenadePrefab, playerPosition, playerRotation);

        // ������ �����տ� ���� ���մϴ�.
        Vector3 speed = new Vector3(0, 200, 1800);
        grenade.GetComponent<Rigidbody>().AddForce(speed);
    }
}
