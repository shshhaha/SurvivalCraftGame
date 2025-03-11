using UnityEngine;
using DTO.PlayerDTO ;


namespace UseItem
{
public class SodaCan : MonoBehaviour
{
    private PlayerDTO pdto; // VO 접근
        public static SodaCan instance;
        //private int mushRoomHP = 10; // 체력 회복량 (임시)    
        private int SodaCanST = 7; // 스태미나 회복량 (임시)

        void Start()
        {
            pdto = PlayerDTO.Instance;
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject); // 중복된 인스턴스 삭제
            }
        }

        // Mushroom 클래스 인스턴스
        public static SodaCan Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<SodaCan>();
                }
                return instance;
            }
        }

        // MushroomLogic null 체크 및 플레이어 stat 조정
        public void SodaCanLogic()
        {
            if (pdto == null)
            {
                pdto = GameObject.FindObjectOfType<PlayerDTO>();
            }
            if (pdto != null)
            {
                int newStamina = (int)pdto.getHunger() + SodaCanST;
                if (newStamina > 100) {
                    newStamina = 100;
                }
                pdto.setHunger(newStamina);
            }
            else
            {
                Debug.LogError("PlayerDTO가 초기화되지 않음.");
            }
        }
}
}