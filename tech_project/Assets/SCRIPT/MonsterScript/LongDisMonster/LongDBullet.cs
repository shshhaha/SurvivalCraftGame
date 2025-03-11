using DTO.PlayerDTO;
using sound.monsterSound;
using sound.playerSound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongDBullet : MonoBehaviour
{
    private PlayerDTO pdto; //VO 접근

    void Start()
    {
        pdto = PlayerDTO.Instance;//VO 접근
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player")
        {
            Debug.Log("Bullet collision");
            AtkToPlayer();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 4f);
        }
    }

    private void AtkToPlayer()
    {
        pdto.setCurrentHp((int)pdto.getCurrentHp() - 15);
        _PlayerSound.instance.PlayPlayerSFX(_PlayerSound.PlayerSfx.PlayerHit);
    }
}
