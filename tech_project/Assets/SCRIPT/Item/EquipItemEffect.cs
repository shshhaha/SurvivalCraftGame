
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection; // MethodInfo

public class EquipItemEffect : MonoBehaviour
{
    public static EquipItemEffect instance;
    void Start()
    {
        instance = this;
    }

    public void EquipItemEffectLogic(string _itemID)
    {
        string itemID = _itemID;
        if (itemID.Contains("Hat"))
        {
            Hat.instance.HatLogic(); 
        }
        else if (itemID.Contains("Shirt"))
        {
            Shirt.instance.ShirtLogic(); 
        }
        else if (itemID.Contains("Pants"))
        {
            Pants.instance.PantsLogic(); 
        }
        else //gun 일 경우밖에 없음
        {
            switch (itemID)
            {
                case "Pistol(Clone)":
                    WaponController.instance.equipWeapon("M1911");
                    break;
                case "Uzi(Clone)":
                    WaponController.instance.equipWeapon("Uzi");
                    break;
                case "AK(Clone)":
                    WaponController.instance.equipWeapon("AK12");
                    break;
                case "M4(Clone)":
                    WaponController.instance.equipWeapon("M4");
                    break;
                case "M249(Clone)":
                    WaponController.instance.equipWeapon("M249");
                    break;
                case "Double(Clone)":
                    WaponController.instance.equipWeapon("DoubleBarrelShoutGun");
                    break;
                case "Pump(Clone)":
                    WaponController.instance.equipWeapon("BennelliM4_Shotgun");
                    break;
                case "RPG(Clone)":
                    WaponController.instance.equipWeapon("RPG7");
                    break;
                default:
                    Debug.Log("EquipItemEffectLogic: No such itemID");
                    break;
            }
        }



    }


}
