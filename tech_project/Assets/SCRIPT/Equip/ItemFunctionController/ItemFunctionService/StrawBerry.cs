using DTO.PlayerDTO;
using UnityEngine;


namespace UseItem
{
public class StrawBerry : MonoBehaviour
{
    private PlayerDTO pdto; // VO 접근
        public static StrawBerry instance;
        private int StrawBerryHP = 10; // 체력 회복량 (임시)    
        //private int pearST = 10; // 스태미나 회복량 (임시)

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

        // Pear 클래스 인스턴스
        public static StrawBerry Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<StrawBerry>();
                }
                return instance;
            }
        }

        // PearLogic null 체크 및 플레이어 stat 조정
        public void StrawBerryLogic()
        {
            if (pdto == null)
            {
                pdto = GameObject.FindObjectOfType<PlayerDTO>();
            }
            if (pdto != null)
            {
                pdto.setCurrentHp((int)pdto.getCurrentHp() + StrawBerryHP);
            }
            else
            {
                Debug.LogError("PlayerDTO가 초기화되지 않음.");
            }
        }
}
}
