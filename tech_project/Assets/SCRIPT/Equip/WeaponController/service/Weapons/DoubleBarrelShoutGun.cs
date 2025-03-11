public class DoubleBarrelShoutGun : Gun
{
    public static DoubleBarrelShoutGun instance = null;

    public DoubleBarrelShoutGun()
    {
        weaponType = "shotgun";
        weaponId = "DoubleBarrelShoutGun";
        weaponRPM = 200f;
        maxAmmo = 2;
        damage = 60;
        reloadTime = 1.5f;
        dispersion = 0f;
        bulletSpeed = 140f;
        creaticalRNG = 20f;
        damageRange = 20f;
    }

    public static DoubleBarrelShoutGun Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DoubleBarrelShoutGun();
            }
            return instance;
        }
    }
}
