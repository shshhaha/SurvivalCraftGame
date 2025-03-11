using weapon;
using sound.gunFireSound;
namespace weapon
{
    public class M249 : Gun
    {
        public static M249 instance = null;

        public M249()
        {
            weaponType = "rifle";
            weaponId = "M249";
            weaponRPM = 600f;
            maxAmmo = 100;
            damage = 32f;
            reloadTime = 4.5f;
            dispersion = 3f;
            bulletSpeed = 168f;
            creaticalRNG = 8f;
            damageRange = 15f;
        }

        public static M249 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new M249();
                }
                return instance;
            }
        }
    }
    
}