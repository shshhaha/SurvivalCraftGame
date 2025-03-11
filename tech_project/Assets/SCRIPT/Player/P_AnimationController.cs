using DTO.WeaponDTO.GunDTO;
using UnityEngine;


public class P_AnimationController : MonoBehaviour
{     
    private GunDTO gunDTO;
    private Animator animator;

    void Start()
    {
        gunDTO = GunDTO.Instance;
        animator = GameObject.Find("Player").GetComponent<Animator>();
    }

    void FixedUpdate() {

    }
    
    public void playerMoveForward(){
        if(gunDTO.getWeaponType() == "rifle" || gunDTO.getWeaponType() == "shotgun")
        {
            animator.SetBool("PlayerRifleIdle", false);
            animator.SetBool("PlayerRifleWalk", true);
            animator.SetBool("PlayerRifleRun", false);
        }
        else if(gunDTO.getWeaponType() == "pistol" || gunDTO.getWeaponType() == "rocketLauncher")
        {
            animator.SetBool("PlayerPistolIdle", false);
            animator.SetBool("PlayerPistolWalk", true);
            animator.SetBool("PlayerPistolRun", false);
        }

    }
    public void playerIdle(){
        if(gunDTO.getWeaponType() == "rifle" || gunDTO.getWeaponType() == "shotgun")
        {
            animator.SetBool("PlayerRifleIdle", true);
            animator.SetBool("PlayerRifleWalk", false);
            animator.SetBool("PlayerRifleRun", false);
            animator.SetBool("PlayerPistolIdle", false);
        }
        else if(gunDTO.getWeaponType() == "pistol" || gunDTO.getWeaponType() == "rocketLauncher")
        {
            animator.SetBool("PlayerPistolIdle", true);
            animator.SetBool("PlayerPistolWalk", false);
            animator.SetBool("PlayerPistolRun", false);
            animator.SetBool("PlayerRifleIdle", false);
        }

    }
    public void playerRun(){
        if(gunDTO.getWeaponType() == "rifle" || gunDTO.getWeaponType() == "shotgun")
        {
            animator.SetBool("PlayerRifleIdle", false);
            animator.SetBool("PlayerRifleWalk", false);
            animator.SetBool("PlayerRifleRun", true);
            
        }
        else if(gunDTO.getWeaponType() == "pistol" || gunDTO.getWeaponType() == "rocketLauncher")
        {
            animator.SetBool("PlayerPistolIdle", false);
            animator.SetBool("PlayerPistolWalk", false);
            animator.SetBool("PlayerPistolRun", true);
        }
    }

    public void playerDead()
    {
        animator.SetBool("PlayerDead", true);
        animator.SetBool("PlayerRifleIdle", false);
        animator.SetBool("PlayerRifleWalk", false);
        animator.SetBool("PlayerRifleRun", false);
        animator.SetBool("PlayerPistolIdle", false);
        animator.SetBool("PlayerRevive", false);
    }

    public void playerRevive()
    {
        animator.SetBool("PlayerDead", false);
        animator.SetBool("PlayerRifleIdle", false);
        animator.SetBool("PlayerRifleWalk", false);
        animator.SetBool("PlayerRifleRun", false);
        animator.SetBool("PlayerPistolIdle", false);
        animator.SetBool("PlayerRevive", true);
    }
}
