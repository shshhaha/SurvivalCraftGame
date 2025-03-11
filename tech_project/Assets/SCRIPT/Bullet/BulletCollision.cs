using DamageNumbersPro;
using DTO.WeaponDTO.GunDTO;
using System.Collections;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private float lastCollisionTime;
    private GunDTO gunDTO;
    private float damage;
    private DamageNumber damagePopup;
    private DamageNumber damagePopupCritical;
    
    [SerializeField]
    protected GameObject VFX_RPG;//RPG 폭발 이펙트


    void Awake()
    {
        gunDTO = GunDTO.Instance;

        GameObject damageNumber = Resources.Load("Prefabs/DamagePopup") as GameObject;
        if (damageNumber != null)
        {
            damagePopup = damageNumber.GetComponent<DamageNumber>();
        }

        GameObject damageNumberCritical = Resources.Load("Prefabs/DamagePopupCritical") as GameObject;
        if (damageNumberCritical != null)
        {
            damagePopupCritical = damageNumberCritical.GetComponent<DamageNumber>();
        }
    }

    void FixedUpdate()
    {
        if (gunDTO.getWeaponType() != "rocketLauncher" && Time.time - lastCollisionTime >= 1.5f && gameObject.activeInHierarchy)
        {
            BulletPool.sharedInstance.ReturnBullet(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        lastCollisionTime = Time.time;

        Vector3 collisionPoint = collision.contacts[0].point;

        switch (collision.gameObject.tag)
        {
            case "Monster":
                //S_SoundManager.instance.PlaySFX(S_SoundManager.Sfx.BulletHitMonster);
                damage = gunDTO.getCurrentDamage();
                if(gunDTO.isNowCritical() == false){damagePopup.Spawn(transform.position, damage);}
                else{damagePopupCritical.Spawn(transform.position, damage);}
                if(gunDTO.getWeaponType() == "rocketLauncher")
                {
                    Instantiate(VFX_RPG, collisionPoint, Quaternion.identity);
                }
                else
                {
                    BulletPool.sharedInstance.ReturnBullet(gameObject); // 총알 반환
                    BulletCollisionVFPool.sharedInstance.GetVFX(collisionPoint);
                }
                break;
            case "Metal":
                //S_SoundManager.instance.PlaySFX(S_SoundManager.Sfx.BulletHitMetal);
                
                if(gunDTO.getWeaponType() == "rocketLauncher")
                {
                    Instantiate(VFX_RPG, collisionPoint, Quaternion.identity);
                }
                else
                {
                    BulletPool.sharedInstance.ReturnBullet(gameObject); // 총알 반환
                    BulletCollisionVFPool.sharedInstance.GetVFX(collisionPoint);
                }
                break;
            case "Building":
                //S_SoundManager.instance.PlaySFX(S_SoundManager.Sfx.BulletHitConcrete);
                if(gunDTO.getWeaponType() == "rocketLauncher")
                {
                    Instantiate(VFX_RPG, collisionPoint, Quaternion.identity);
                }
                else
                {
                    BulletPool.sharedInstance.ReturnBullet(gameObject); // 총알 반환
                    BulletCollisionVFPool.sharedInstance.GetVFX(collisionPoint);
                }
                break;
            case "Wood":
                //S_SoundManager.instance.PlaySFX(S_SoundManager.Sfx.BulletHitWood);
                if(gunDTO.getWeaponType() == "rocketLauncher")
                {
                    Instantiate(VFX_RPG, collisionPoint, Quaternion.identity);
                }
                else
                {
                    BulletPool.sharedInstance.ReturnBullet(gameObject); // 총알 반환
                    BulletCollisionVFPool.sharedInstance.GetVFX(collisionPoint);
                }
                break;
            case "장애물":
                //S_SoundManager.instance.PlaySFX(S_SoundManager.Sfx.BulletHitWood);
                if(gunDTO.getWeaponType() == "rocketLauncher")
                {
                    Instantiate(VFX_RPG, collisionPoint, Quaternion.identity);
                }
                else
                {
                    BulletPool.sharedInstance.ReturnBullet(gameObject); // 총알 반환
                    BulletCollisionVFPool.sharedInstance.GetVFX(collisionPoint);
                }
                break;
        }
    }
}