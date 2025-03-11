using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BennelliM4_Shotgun : Gun
{
    public static BennelliM4_Shotgun instance = null;

    public BennelliM4_Shotgun()
    {
        weaponType = "shotgun";
        weaponId = "BennelliM4_Shotgun";
        weaponRPM = 150f;
        maxAmmo = 7;
        damage = 31f;
        reloadTime = 0.3f;
        dispersion = 0f;
        bulletSpeed =140f;
        creaticalRNG = 10f;
        damageRange = 10f;
    }

    public static BennelliM4_Shotgun Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new BennelliM4_Shotgun();
            }
            return instance;
        }
    }
}
