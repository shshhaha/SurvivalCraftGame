using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DTO.WeaponDTO.GrenadeDTO
{
    public class GrenadeDTO : MonoBehaviour
    {
        private static GrenadeDTO instance;

        //변수 영역---------
        private string weaponId = "000000";// 무기 아이디 for datatable
        private int ammo;
        private float G_damage = 100f; // 수류탄 데미지
        private float grenadeRPM = 3f; // 수류탄 재사용 속도
        private float throwPower = 30f; // 수류탄 사거리

        //------------------

        public static GrenadeDTO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<GrenadeDTO>();
                }
                return instance;
            }
        }
        //get set 영역---------
        public string getWeaponId()
        {
            return this.weaponId;
        }
        public void setWeaponId(string weaponId)
        {
            this.weaponId = weaponId;
        }

        public float getgrenadeRPM()
        {
            return this.grenadeRPM;
        }
        public void setgrenadeRPM(float grenadeRPM)
        {
            this.grenadeRPM = grenadeRPM;
        }

        public float getthrowPower()
        {
            return this.throwPower;
        }
        public void setthrowPower(float throwPower)
        {
            this.throwPower = throwPower;
        }
        
        public float getG_damage()
        {
            return this.G_damage;
        }
        public void setG_damage(float G_damage)
        {
            this.G_damage = G_damage;
        }
        //---------------------
    }
}