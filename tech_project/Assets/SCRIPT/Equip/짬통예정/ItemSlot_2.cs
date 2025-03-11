using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DTO.ItemSlotDTO;
using DTO.WeaponDTO.GrenadeDTO;
using sound.gunFireSound;

public class ItemSlot_2 : MonoBehaviour
{
    private string Id;
    private ItemSlot2DTO itemSlot2DTO; 
    public Button Item2_btn_UI;
    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public GameObject SmokeGrenadeObject;
    public GameObject GrenadeObject;
    private GrenadeDTO grnadeDTO;
    private bool wait = false;
    private bool atk_btn_down = false;
    private float grenadeRPM;
    private float throwPower;
    private int ammo =5;
    public Transform Grenadepos;
    // Start is called before the first frame update
    void Start()
    {
        itemSlot2DTO = ItemSlot2DTO.Instance;
        Item2_btn_UI.onClick.AddListener(ItemSlot2);
    }
    void FixedUpdate(){
        Id = itemSlot2DTO.getItemSlot2_Id();
    }

    void ItemSlot2()
    {
        switch (Id)
        {
            case "000000":
                GrenadeLogic();
                break;
            case "000001":
                SmokeGrenadeLogic();
                break;
            default:
                Debug.Log("존재하지 않는 아이템입니다.");
                break;
        }
    }

    //투척 아이템 구현부
    private void GrenadeLogic(){
        grnadeDTO = GrenadeDTO.Instance;
        grenadeRPM = grnadeDTO.getgrenadeRPM();
        throwPower = grnadeDTO.getthrowPower();

        if (wait == false && atk_btn_down == false && ammo > 0)
        {
            wait = true;
            _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.GrenadeTR);
            StartCoroutine(PlaySoundAfterDelay());
            GameObject intantGrenade = Instantiate(GrenadeObject, Grenadepos.position, Grenadepos.rotation);
            Rigidbody GrenadeRigid = intantGrenade.GetComponent<Rigidbody>();
            GrenadeRigid.AddRelativeForce(transform.forward * throwPower, ForceMode.Impulse);
            Destroy(intantGrenade, 15);
            Debug.Log(throwPower + "파워 수류탄 확인");
            StartCoroutine(G_AttackCooldownCoroutine());
        }
        //사운드 재생 딜레이
        IEnumerator PlaySoundAfterDelay(){
            yield return new WaitForSeconds(3);
            _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.GrenadeEx);
        }
        //쿨타임
        IEnumerator G_AttackCooldownCoroutine(){
            yield return new WaitForSeconds(grenadeRPM);
            wait = false;
        }
    }

    public void SmokeGrenadeLogic(){
        grnadeDTO = GrenadeDTO.Instance;
        grenadeRPM = grnadeDTO.getgrenadeRPM();
        throwPower = grnadeDTO.getthrowPower();
        
        if (wait == false && atk_btn_down == false && ammo > 0)
        {
            wait = true;
            GameObject intantSmokeGrenade = Instantiate(SmokeGrenadeObject, Grenadepos.position, Grenadepos.rotation); // 인스턴트 연막 생성
            Rigidbody SmokeGrenadeRigid = intantSmokeGrenade.GetComponent<Rigidbody>();
            SmokeGrenadeRigid.AddRelativeForce(transform.forward * throwPower, ForceMode.Impulse);
            Destroy(intantSmokeGrenade, 15);                                                                // 시간 초 뒤 오브젝트 삭제
            Debug.Log(throwPower + "연막 수류탄 확인");
            StartCoroutine(G_AttackCooldownCoroutine());                                                    // 연막탄 쿨타임 ON
        }

        //쿨타임
        IEnumerator G_AttackCooldownCoroutine(){
            yield return new WaitForSeconds(grenadeRPM);
            wait = false;
        }
    }
}
