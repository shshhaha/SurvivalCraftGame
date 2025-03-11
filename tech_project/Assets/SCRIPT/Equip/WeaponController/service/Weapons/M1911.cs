using sound.gunFireSound;
namespace weapon
{
    public class M1911 : Gun
    {
        public static M1911 instance = null;

        public M1911()
        {
            weaponType = "pistol";
            weaponId = "M1911";
            weaponRPM = 180;
            maxAmmo = 7;
            damage = 9f;
            reloadTime = 0.8f;
            dispersion = 0f;
            bulletSpeed = 76f;
            creaticalRNG = 5f;
            damageRange = 10;
        }

        public static M1911 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new M1911();
                }
                return instance;
            }
        }
    }
    
}

