using DTO.WeaponDTO.GunDTO;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AutometicAiming : MonoBehaviour
{
    /* private float forceRotate;
    private float rotationY;
    private float angleInRadians; */

    private float rotationSpeed = 10f;
    private GunDTO gunDTO;
    private float fixRotation = 0f;


    public void AutoAim(Vector3 direction, GameObject player){

        Collider[] hitColliders = Physics.OverlapSphere(player.transform.position, 15);
        float closestDistance = float.MaxValue;
        Collider closestMonster = null;

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.CompareTag("Monster"))
            {
                float distanceToMonster = Vector3.Distance(player.transform.position, hitColliders[i].transform.position);
                if (distanceToMonster < closestDistance)
                {
                    closestDistance = distanceToMonster;
                    closestMonster = hitColliders[i];
                }
            }
        }

        if (closestMonster != null)
        {
            Vector3 directionToMonster = closestMonster.transform.position - player.transform.position;
            gunDTO = GunDTO.Instance;

            /* if(gunDTO.getWeaponType() == "pistol"){ fixRotation = 0; }
            else { fixRotation = 0;} */
        
            Quaternion toRotation = Quaternion.LookRotation(directionToMonster);
            toRotation *= Quaternion.Euler(0, gunDTO.getFixRotation() + fixRotation, 0);
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        /* if (closestMonster != null)// 자동조준 V2
        {
            Vector3 directionToMonster = closestMonster.transform.position - player.transform.position;
            RaycastHit hit;
            Physics.Raycast(player.transform.position, directionToMonster, out hit);
            
            bool hasBuildingTag = false;
            Transform parent = hit.transform;

            while (parent != null)
            {
                if (parent.tag == "Building" || parent.tag == "장애물")
                {
                    hasBuildingTag = true;
                    break;
                }
                parent = parent.parent;
            }

            if (!hasBuildingTag)
            {
                gunDTO = GunDTO.Instance;
                Quaternion toRotation = Quaternion.LookRotation(directionToMonster);
                toRotation *= Quaternion.Euler(0, 10, 0); // Add 20 degrees to the y-axis
                player.transform.rotation = Quaternion.Lerp(player.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        } */
    }
}
