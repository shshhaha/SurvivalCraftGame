/* using DamageNumbersPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDamageNumber : MonoBehaviour
{
    public static CreateDamageNumber createDamageNumber;
    public DamageNumber dn;

    void Awake()
    {
        createDamageNumber = this;
    }

    public void CreateDamage(Vector3 collisionPoint, int damage)
    {
        dn.Spawn(collisionPoint, damage);
    }
}
 */