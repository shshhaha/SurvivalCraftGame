using UnityEngine;
using sound.gunFireSound;
using weapon;

namespace weapon
{
    public class AK12 : Gun
    {
        public static AK12 instance = null;

        public AK12()
        {
            weaponType = "rifle";
            weaponId = "AK12";
            weaponRPM = 450f;
            maxAmmo = 30;
            damage = 40f;
            reloadTime = 2.3f;
            dispersion = 1.6f;
            bulletSpeed = 150f;
            creaticalRNG = 15f;
            damageRange = 20f;
        }

        public static AK12 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AK12();
                }
                return instance;
            }
        }
    }

}