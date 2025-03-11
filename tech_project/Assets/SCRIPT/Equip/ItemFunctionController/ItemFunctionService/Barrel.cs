using DTO.PlayerDTO;
using UnityEngine;


namespace UseItem
{
public class Barrel : MonoBehaviour
{
    private PlayerDTO pdto; // VO 접근
        public static Barrel instance;
   
        private int BarrelST = 7; // 스태미나 회복량 (임시)

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

        public static Barrel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<Barrel>();
                }
                return instance;
            }
        }


        public void BarrelLogic()
        {
            if (pdto == null)
            {
                pdto = GameObject.FindObjectOfType<PlayerDTO>();
            }
            if (pdto != null)
            {
                int newStamina = (int)pdto.getHunger() + BarrelST;
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
