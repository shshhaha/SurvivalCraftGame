using System.Collections;
using UnityEngine;
using DTO.WeaponDTO.GrenadeDTO;

namespace Equip.Grenade
{
    public class SmokeGrenade : MonoBehaviour
    {
        public static SmokeGrenade instance;
        public GameObject SmokeGrenadeObject;
        private GrenadeDTO grenadeDTO;
        private bool wait = false;
        private bool atk_btn_down = false;
        private float grenadeRPM;
        private float throwPower;
        private int ammo =5;
        public Transform Grenadepos;

        public static SmokeGrenade Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<SmokeGrenade>();
                }
                return instance;
            }
        }

        public void SmokeGrenadeLogic(){
            grenadeDTO = GrenadeDTO.Instance;
            grenadeRPM = grenadeDTO.getgrenadeRPM();
            throwPower = grenadeDTO.getthrowPower();
            
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
}
