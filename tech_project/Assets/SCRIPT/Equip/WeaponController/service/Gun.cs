using sound.gunFireSound;
using System.Collections;
using UnityEngine;
using DTO.WeaponDTO.GunDTO;
using weapon;
using DTO.BuffDTO;

public class Gun : MonoBehaviour
{

    [SerializeField]
    protected GameObject[] weapon;//무기 오브젝트

    [SerializeField]
    protected GameObject shellOutlet;

    [SerializeField]
    protected Transform weaponFirePos;//무기 발사지점

    [SerializeField]
    protected Transform[] weaponFlashPos;//무기 소염구 위치

    [SerializeField]
    protected GameObject myVFX;//발사 이펙트

    [SerializeField]
    protected GameObject bullet;//발사체

    [SerializeField]
    protected GameObject bullet_rpg;//rpg-7 발사체

    [SerializeField]
    protected GameObject missile_rpg;//rpg-7 기본으로 보이는 미사일



    [SerializeField]
    protected GameObject flashLight;//총기 소염

    protected ShellPool shellPool;
    protected GunDTO gunDTO;
    protected BuffDTO buffDTO;
    

    protected Gun currentWeapon;

    protected bool wait = false;//연사 판단 트리거
    protected bool isReload = false;//재장전 판단 트리거
    protected bool atk_btn_down = false;//버튼 활성 판단 트리거

    private float fixRotation = 4f;

    protected string weaponType;
    protected string weaponId;
    protected float weaponRPM;
    protected int ammo;
    protected int maxAmmo;
    public float damage;
    protected float reloadTime;
    protected float dispersion;//무기 분산
    protected float bulletSpeed;
    protected float weaponDurability;
    protected float creaticalRNG;//치명타 확률
    protected float damageRange;//데미지 범위+- 퍼센트
    private float fireFixRotation = 0f;

    //무기 작동 함수
    protected void fireWeapon()
    {
        if (wait == false && atk_btn_down == true && gunDTO.getAmmo() > 0 && isReload == false)
        {
            UserDataController.atkExp += 1;

            wait = true;
            weaponFirePos.localRotation = Quaternion.identity;
            weaponFirePos.Rotate(0, -(gunDTO.getFixRotation() + fireFixRotation) + Random.Range(-gunDTO.getWeaponDispersion(), gunDTO.getWeaponDispersion()), 0);//무기 분산
            bulletLogic();
            shellLogic();
            gunDTO.setAmmo(gunDTO.getAmmo() - 1); // 탄약 수 감소
            gunDTO.setCurrentDamage(weaponRandomDamage(gunDTO.getDamage(), gunDTO.getDamageRange(), gunDTO.getCreaticalRNG()));
            StartCoroutine(FlashOnOff());
            StartCoroutine(AttackCooldownCoroutine());
        }
        else if (gunDTO.getAmmo() <= 0)
        {
            atk_btn_down = false;
        }
    }

    IEnumerator FlashOnOff()
    {
        flashLight.SetActive(true);
        yield return new WaitForSeconds(0.025f);
        flashLight.SetActive(false);
    }
    private IEnumerator AttackCooldownCoroutine() //연사속도 코루틴
    {
        Debug.Log("연사속도 코루틴 실행");
        yield return new WaitForSeconds(gunDTO.getWeaponRPM());
        wait = false;
    }

    //무기 스왑 함수(테스트용)
    protected void swapWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("M1911 전환키 눌림");
            weaponId = "M1911";
            equipWeapon("M1911");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("AK12 전환키 눌림");
            weaponId = "AK12";
            equipWeapon("AK12");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("M249 전환키 눌림");
            weaponId = "M249";
            equipWeapon("M249");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("Uzi 전환키 눌림");
            weaponId = "Uzi";
            equipWeapon("Uzi");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("M4 전환키 눌림");
            weaponId = "M4";
            equipWeapon("M4");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Debug.Log("DoubleBarrelShoutGun 전환키 눌림");
            weaponId = "DoubleBarrelShoutGun";
            equipWeapon("DoubleBarrelShoutGun");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Debug.Log("BennelliM4_Shotgun 전환키 눌림");
            weaponId = "BennelliM4_Shotgun";
            equipWeapon("BennelliM4_Shotgun");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Debug.Log("RPG7 전환키 눌림");
            weaponId = "RPG7";
            equipWeapon("RPG7");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    //무기 발사 사운드 함수
    protected void weaponSFX(){
        switch (weaponId)
        {
            case "M1911":
            _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.M4);
                break;
            case "AK12":
                _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.AK12);
                break;
            case "M249":
                _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.MachineGun);
                break;
            case "Uzi":
                _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.Uzi);//사운드 임시로 넣어둠
                break;
            case "M4":
                _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.M4);//사운드 임시로 넣어둠
                break;
            case "DoubleBarrelShoutGun":
                _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.ShotGunFire);
                break;
            case "BennelliM4_Shotgun":
                _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.ShotGunFire);
                break;
            case "RPG7":
                _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.RPG);
                break;
            
            default:
                Debug.Log("무기를 장착해주세요.");
                break;
        }
    }

    //무기 재장전 사운드 함수(시작)
    protected void weaponReloadSFXstart(){
        switch (weaponId)
        {
            /* case "M1911":
                _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.M4);
                break;
            case "AK12":
                _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.AK12);
                break;
            case "M249":
                _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.MachineGun);
                break;
            case "Uzi":
                _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.Uzi);//사운드 임시로 넣어둠
                break;
            case "M4":
                _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.M4);
                break; */
            case "DoubleBarrelShoutGun":
                _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.ShotGunReloadDoubleStart);
                break;
            case "BennelliM4_Shotgun":
                _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.ShotGunReloadM4);
                break;
            case "RPG7":
                _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.RpgReload);
                break;
            
            default:
                Debug.Log("무기를 장착해주세요.");
                break;
        }
    }

    //무기 재장전 사운드 함수 (완료시)
    protected void weaponReloadSFXend(){
        switch (weaponId)
        {
            /* case "M1911":
                _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.M4);
                break;
            case "AK12":
                _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.AK12);
                break;
            case "M249":
                _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.MachineGun);
                break;
            case "Uzi":
                _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.Uzi);//사운드 임시로 넣어둠
                break;
            case "M4":
                _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.M4);
                break;
            case "BennelliM4_Shotgun":
                _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.ShotGunReloadM4);
                break; */
            case "DoubleBarrelShoutGun":
                _GunFireSound.instance.PlayGunSFX(_GunFireSound.GunSfx.ShotGunReloadDoubleEnd);
                break;
            
            default:
                Debug.Log("end 사운드 지정 안됨");
                break;
        }
    }

    //무기 장착 함수
    public void equipWeapon(string weaponId)//만약 무기를 장착하려면 이 함수를 호출 하여 무기 아이디를 넣어주고 실행하면 무기가 교체됨
    {
        switch (weaponId)
        {
            case "M1911":
                weaponId = "M1911";
                gunDTO.setFixRotation(4f);//무기의 바라보는 방향 조정(애니메이션과 레이저의 방향을 맞추기 위해 필요)
                currentWeapon = M1911.Instance;
                SetWeaponProperties(currentWeapon);
                fireFixRotation = 1f;
                Debug.Log("M1911 장착");
                break;
            case "AK12":
                weaponId = "AK12";
                gunDTO.setFixRotation(10f);
                currentWeapon = AK12.Instance;
                SetWeaponProperties(currentWeapon);
                fireFixRotation = 0f;
                Debug.Log("AK12 장착");
                break;
            case "M249":
                weaponId = "M249";
                gunDTO.setFixRotation(10f);
                currentWeapon = M249.Instance;
                SetWeaponProperties(currentWeapon);
                fireFixRotation = 0f;
                Debug.Log("M249 장착");
                break;
            case "Uzi":
                weaponId = "Uzi";
                gunDTO.setFixRotation(4f);
                currentWeapon = Uzi.Instance;
                SetWeaponProperties(currentWeapon);
                fireFixRotation = 1f;
                Debug.Log("Uzi 장착");
                break;
            case "M4":
                weaponId = "M4";
                gunDTO.setFixRotation(10f);
                currentWeapon = M4.Instance;
                SetWeaponProperties(currentWeapon);
                fireFixRotation = 0f;
                Debug.Log("M4 장착");
                break; 
            case "DoubleBarrelShoutGun":
                weaponId = "DoubleBarrelShoutGun";
                gunDTO.setFixRotation(10f);
                currentWeapon = DoubleBarrelShoutGun.Instance;
                SetWeaponProperties(currentWeapon);
                fireFixRotation = 0f;
                Debug.Log("DoubleBarrelShoutGun 장착");
                break;
            case "BennelliM4_Shotgun":
                weaponId = "BennelliM4_Shotgun";
                gunDTO.setFixRotation(10f);
                currentWeapon = BennelliM4_Shotgun.Instance;
                SetWeaponProperties(currentWeapon);
                fireFixRotation = 0f;
                Debug.Log("BennelliM4_Shotgun 장착");
                break;
            case "RPG7":
                weaponId = "RPG7";
                gunDTO.setFixRotation(10f);
                currentWeapon = RPG7.Instance;
                SetWeaponProperties(currentWeapon);
                fireFixRotation = 0f;
                Debug.Log("RPG7 장착");
                break;


            default:
                Debug.Log("무기를 장착해주세요.");
                break;
        }
        gunDTO.setWeaponId(weaponId);
    }

    private IEnumerator ReloadCoroutineReload()
    {
        yield return new WaitForSeconds(gunDTO.getReloadTime());
        if(gunDTO.getWeaponId() == "BennelliM4_Shotgun"){
            gunDTO.setAmmo(gunDTO.getAmmo() + 1);
            isReload = false;
            weaponReloadSFXend();
            Debug.Log("재장전 완료");
        }
        else{
            gunDTO.setAmmo(gunDTO.getMaxAmmo());
            isReload = false;
            weaponReloadSFXend();
            Debug.Log("재장전 완료");
            
            if(gunDTO.getWeaponType() == "rocketLauncher")  // RPG-7 재장전시 미사일 보이게 하기
            {
                missile_rpg.SetActive(true);
            }
        }
        
    }
    //무기 속성 주입 함수
    protected void SetWeaponProperties(Gun weapon)
    {
        buffDTO = BuffDTO.Instance;
        gunDTO = GunDTO.Instance;

        /* weaponType = weapon.weaponType;
        weaponId = weapon.weaponId;
        weaponRPM = 1 / ((weapon.weaponRPM + buffDTO.getWeaponRPM()) / 60);
        maxAmmo = weapon.maxAmmo + buffDTO.getMaxAmmo();
        ammo = 0;
        bulletSpeed = weapon.bulletSpeed;
        damageRange = weapon.damageRange;
        damage = weapon.damage + buffDTO.getDamage();
        reloadTime = weapon.reloadTime + buffDTO.getReloadTime();
        dispersion = weapon.dispersion + buffDTO.getWeaponDispersion();
        creaticalRNG = weapon.creaticalRNG + buffDTO.getCreaticalRNG();
        range = weapon.range; */

        weaponType = weapon.weaponType;
        weaponId = weapon.weaponId;
        bulletSpeed = weapon.bulletSpeed;
        damageRange = weapon.damageRange;
        ammo = 0;
        

        weaponRPM = 1 / ((weapon.weaponRPM + buffDTO.getWeaponRPM()) / 60);
        reloadTime = weapon.reloadTime * (1 - UserDataController.reloadSpeed/100);
        damage = weapon.damage * (1 + UserDataController.atk/100);
        maxAmmo = weapon.maxAmmo;
        creaticalRNG = weapon.creaticalRNG * (1 + UserDataController.criticalRNG/100);
        dispersion = weapon.dispersion;

        updateWeaponDTO();
        invisibleWeapon();
    }

    //무기 재장전 함수
    public void Reload()
    {
        if(isReload == false)
        {
            if(gunDTO.getAmmo() == 0){UserDataController.reloadSpeedExp += 5;}
            if (gunDTO.getAmmo() < gunDTO.getMaxAmmo())
            {
            isReload = true;
            Debug.Log("재장전 시작");
            weaponReloadSFXstart();
            StartCoroutine(ReloadCoroutineReload());
            }
            Debug.Log("재장전 버튼 눌림");
        }
        else
        {
            //Debug.Log("재장전 중....");
        }
        
    }

    //무기 비활성화 함수
    protected void invisibleWeapon()
    {
        for (int i = 0; i < weapon.Length; i++)
        {
            weapon[i].SetActive(false);
            if(weapon[i].name == weaponId)
            {
                weapon[i].SetActive(true);
            }
        }
    }
    
    //총알 함수
    protected void bulletLogic(){
        //샷건일경우
        if(gunDTO.getWeaponType() == "shotgun"){
            for (int i = 0; i <= 8; i++)
            {
                GameObject instantBullet = BulletPool.sharedInstance.GetBullet(1f);
                instantBullet.transform.position = weaponFirePos.position;
                instantBullet.transform.rotation = weaponFirePos.rotation;
                Rigidbody bulletRigid = instantBullet.GetComponent<Rigidbody>();
                bulletRigid.velocity = weaponFirePos.forward * bulletSpeed;
            }
            weaponSFX();
        }
        else if(gunDTO.getWeaponType() == "rocketLauncher"){
            GameObject bulletInstance = Instantiate(bullet_rpg, weaponFirePos.position, weaponFirePos.rotation);
            bulletInstance.transform.rotation = Quaternion.Euler(weaponFirePos.rotation.eulerAngles.x, weaponFirePos.rotation.eulerAngles.y + 180, weaponFirePos.rotation.eulerAngles.z);
            Rigidbody bulletRigidRPG = bulletInstance.GetComponent<Rigidbody>();
            bulletRigidRPG.velocity = weaponFirePos.forward * bulletSpeed;
            missile_rpg.SetActive(false);
            Destroy(bulletInstance, 3f);
            weaponSFX();
        }
        else{
            GameObject instantBullet = BulletPool.sharedInstance.GetBullet(1f);
            instantBullet.transform.position = weaponFirePos.position;
            instantBullet.transform.rotation = weaponFirePos.rotation;
            Rigidbody bulletRigid = instantBullet.GetComponent<Rigidbody>();
            bulletRigid.velocity = weaponFirePos.forward * bulletSpeed;
            weaponSFX();
        }
    }

    // 탄피 함수
    protected void shellLogic()
    {
        // ShellPool에서 탄피 가져오기
        GameObject shell = ShellPool.sharedInstance.GetShell();

        // 탄피의 위치와 방향 설정
        shell.transform.position = shellOutlet.transform.position; // shellOutlet의 위치로 설정

        Rigidbody shellRigidbody = shell.GetComponent<Rigidbody>();
        if (shellRigidbody != null)
        {
            shellRigidbody.velocity = (shellOutlet.transform.right + shellOutlet.transform.up) * Random.Range(3.5f, 5.5f);
            shellRigidbody.angularVelocity = Random.insideUnitSphere * 5f;
        }
    }

    //랜덤 데미지 함수 및 치명타 계산
    protected float weaponRandomDamage(float damage, float damageRange, float creaticalRNG)
    {
        float randomDamage = Random.Range(damage * (1 - damageRange / 100f), damage * (1 + damageRange / 100f));
        gunDTO.setNowCritical(false);
        if (Random.Range(0, 100) < creaticalRNG)
        {
            UserDataController.criticalRNGExp += 3;
            UserDataController.criticalDamageExp += 3;
            
            randomDamage *= 3 * (1 + UserDataController.criticalDamage/100);
            gunDTO.setNowCritical(true);
        }

        return randomDamage;
    }

    //

    //DTO 업데이트 함수
    public void updateWeaponDTO()
    {
        gunDTO.setWeaponType(weaponType);
        gunDTO.setWeaponId(weaponId);
        gunDTO.setWeaponRPM(weaponRPM);
        gunDTO.setMaxAmmo(maxAmmo);
        gunDTO.setDamage(damage);
        gunDTO.setReloadTime(reloadTime);
        gunDTO.setWeaponDispersion(dispersion);
        gunDTO.setCreaticalRNG(creaticalRNG);
        gunDTO.setAmmo(ammo);
        gunDTO.setDamageRange(damageRange);
    }
}