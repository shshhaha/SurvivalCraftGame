using UnityEngine;

namespace DTO.ItemDTO
{
    public class ItemDTO : MonoBehaviour
    {
        private static ItemDTO instance;

        private float recoveryHP; // 회복량
        private float recoveryStamina; // 스태미나 회복량
        private float recoveryHunger; // 허기 회복량
        private float Cooldown; // 쿨타임

        public static ItemDTO Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = GameObject.FindObjectOfType<ItemDTO>();
                    }
                    return instance;
                }
            }

        public float getRecoveryHP()
        {
            return this.recoveryHP;
        }
        public void setRecoveryHP(float recoveryHP)
        {
            this.recoveryHP = recoveryHP;
        }

        public float getRecoveryStamina()
        {
            return this.recoveryStamina;
        }
        public void setRecoveryStamina(float recoveryStamina)
        {
            this.recoveryStamina = recoveryStamina;
        }

        public float getRecoveryHunger()
        {
            return this.recoveryHunger;
        }

        public void setRecoveryHunger(float recoveryHunger)
        {
            this.recoveryHunger = recoveryHunger;
        }

        public float getCooldown()
        {
            return this.Cooldown;
        }
        public void setCooldown(float Cooldown)
        {
            this.Cooldown = Cooldown;
        }
    }
}