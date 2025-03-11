using sound.gunFireSound;
namespace weapon
{
    public class Uzi : Gun
    {
        public static Uzi instance = null;

        public Uzi()
        {
            weaponType = "pistol";
            weaponId = "Uzi";
            weaponRPM = 950f;
            maxAmmo = 50;
            damage = 11f;
            reloadTime = 0.95f;
            dispersion = 0.88f;
            bulletSpeed = 162f;
            creaticalRNG = 5f;
            damageRange = 13;
        }

        public static Uzi Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Uzi();
                }
                return instance;
            }
        }
    }
    
}

