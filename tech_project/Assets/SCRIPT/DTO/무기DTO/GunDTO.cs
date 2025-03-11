using UnityEngine;

namespace DTO.WeaponDTO.GunDTO

{
    public class GunDTO : MonoBehaviour
    {
        private static GunDTO instance;

        private string weaponType;
        public string weaponId;
        private float weaponRPM;// 무기 연사속도
        private float reloadTime;
        private float damage;// 데미지
        private float currentDamage;//계산식이 적용된 실제 데미지
        private bool nowCritical;//현재 치명타 여부
        private int ammo;//현재 총알 수
        private int maxAmmo;//최대 총알 수
        private float creaticalRNG;//치명타 확률
        private float weaponDispersion;//무기 분산
        private float damageRange;//데미지 범위+- 퍼센트
        private float bulletSpeed;

        private float fixRotation;

        


        public static GunDTO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<GunDTO>();
                }
                return instance;
            }
        }

        public string getWeaponType()
        {
            return this.weaponType;
        }
        public void setWeaponType(string weaponType)
        {
            this.weaponType = weaponType;
        }

        public string getWeaponId()
        {
            return this.weaponId;
        }
        public void setWeaponId(string weaponId)
        {
            this.weaponId = weaponId;
        }

        public float getWeaponRPM()
        {
            return this.weaponRPM;
        }
        public void setWeaponRPM(float weaponRPM)
        {
            this.weaponRPM = weaponRPM;
        }
        
        public float getDamage()
        {
            return this.damage;
        }

        public void setDamage(float damage)
        {
            this.damage = damage;
        }

        public int getAmmo()
        {
            return this.ammo;
        }

        public void setAmmo(int ammo)
        {
            this.ammo = ammo;
        }

        public int getMaxAmmo()
        {
            return this.maxAmmo;
        }

        public void setMaxAmmo(int maxAmmo)
        {
            this.maxAmmo = maxAmmo;
        }

        public float getCurrentDamage()
        {
            return this.currentDamage;
        }

        public void setCurrentDamage(float currentDamage)
        {
            this.currentDamage = currentDamage;
        }
        public bool isNowCritical()
        {
            return this.nowCritical;
        }

        public void setNowCritical(bool nowCritical)
        {
            this.nowCritical = nowCritical;
        }

        public float getCreaticalRNG()
        {
            return this.creaticalRNG;
        }

        public void setCreaticalRNG(float creaticalRNG)
        {
            this.creaticalRNG = creaticalRNG;
        }
                public float getReloadTime()
        {
            return this.reloadTime;
        }

        public void setReloadTime(float reloadTime)
        {
            this.reloadTime = reloadTime;
        }
        
        public float getWeaponDispersion()
        {
            return this.weaponDispersion;
        }

        public void setWeaponDispersion(float weaponDispersion)
        {
            this.weaponDispersion = weaponDispersion;
        }

        public float getDamageRange()
        {
            return this.damageRange;
        }

        public void setDamageRange(float damageRange)
        {
            this.damageRange = damageRange;
        }

        public float getBulletSpeed()
        {
            return this.bulletSpeed;
        }

        public void setBulletSpeed(float bulletSpeed)
        {
            this.bulletSpeed = bulletSpeed;
        }

        public float getFixRotation()
        {
            return this.fixRotation;
        }

        public void setFixRotation(float fixRotation)
        {
            this.fixRotation = fixRotation;
        }


    }

}

