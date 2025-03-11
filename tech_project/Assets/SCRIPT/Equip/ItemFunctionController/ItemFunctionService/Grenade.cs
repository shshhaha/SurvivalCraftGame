using System.Collections;
using UnityEngine;
using sound.gunFireSound;
using DTO.WeaponDTO.GrenadeDTO;

namespace Equip.Grenade
{
    public class aGrenade : MonoBehaviour
    {
        public static aGrenade instance;
        public GameObject GrenadeObject;
        private GrenadeDTO grenadeDTO;
        private bool wait = false;
        private bool atk_btn_down = false;
        private float grenadeRPM;
        private float throwPower;
        private int ammo = 5; //수류탄 갯수(임시 : 인벤토리 구현 끝나면 인벤토리에서 개수 받아올 예정)
        public Transform Grenadepos;

        public static aGrenade Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<aGrenade>();
                }
                return instance;
            }
        }
        
        public void GrenadeLogic()
        {
            grenadeDTO = GrenadeDTO.Instance;

            grenadeRPM = grenadeDTO.getgrenadeRPM();
            throwPower = grenadeDTO.getthrowPower();

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
            IEnumerator PlaySoundAfterDelay()
            {
                yield return new WaitForSeconds(3);
                _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.GrenadeEx);
            }

            //쿨타임
            IEnumerator G_AttackCooldownCoroutine()
            {
                yield return new WaitForSeconds(grenadeRPM);
                wait = false;
            }
        }
    }
}
