public class RPG7 : Gun
{
    public static RPG7 instance = null;

    public RPG7()
    {
        weaponType = "rocketLauncher";
        weaponId = "RPG7";
        weaponRPM = 60f;
        maxAmmo = 1;
        damage = 300;
        reloadTime = 5.2f;
        dispersion = 0f;
        bulletSpeed = 50f;
        creaticalRNG = 30f;
        damageRange = 20f;
    }

    public static RPG7 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new RPG7();
            }
            return instance;
        }
    }
}
