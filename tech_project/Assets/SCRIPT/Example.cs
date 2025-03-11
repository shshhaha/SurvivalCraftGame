using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    public Button AK;
    public Button M1911;
    public Button M4;
    void Start()
    {
        AK.onClick.AddListener(() => { WaponController.instance.equipWeapon("AK12"); });
        M1911.onClick.AddListener(() => { WaponController.instance.equipWeapon("M1911");});
        M4.onClick.AddListener(() => { WaponController.instance.equipWeapon("M4"); });
    }
}
