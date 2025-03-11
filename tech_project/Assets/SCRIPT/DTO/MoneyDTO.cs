using UnityEngine;
namespace DTO.MoneyDTO
{
    public class MoneyDTO : MonoBehaviour
    {
        private static MoneyDTO instance;
        private float money;
        private float point;
        public static MoneyDTO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<MoneyDTO>();
                }
                return instance;
            }
        }
        public float getMoney()
        {
            return this.money;
        }

        public void setMoney(float money)
        {
            this.money = money;
        }

        public float getPoint()
        {
            return this.point;
        }

        public void setPoint(float point)
        {
            this.point = point;
        }
    }
}
