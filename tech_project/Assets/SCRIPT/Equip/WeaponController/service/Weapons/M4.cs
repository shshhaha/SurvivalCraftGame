using UnityEngine;
using sound.gunFireSound;
using weapon;

namespace weapon
{
    public class M4 : Gun
    {
        public static M4 instance = null;

        public M4()
        {
            weaponType = "rifle";
            weaponId = "M4";
            weaponRPM = 750f;
            maxAmmo = 30;
            damage = 28f;
            reloadTime = 1.7f;
            dispersion = 1.25f;
            bulletSpeed = 180f;
            creaticalRNG = 15f;
            damageRange = 20f;
        }

        public static M4 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new M4();
                }
                return instance;
            }
        }
    }

}