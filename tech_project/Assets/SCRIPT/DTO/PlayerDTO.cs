using UnityEngine;

namespace DTO.PlayerDTO
{
    public class PlayerDTO : MonoBehaviour
    {
        private static PlayerDTO instance;
        private float maxHp; // 최대 HP
        private float currentHp;// 현재 HP
        private float maxStamina;
        private float hunger;
        private float currentStamina;
        private bool isPlayerRun = false;//달리기
        private int tiredFlag;//피곤함
        private int killCount;
        private bool death = false;

        private int mobCount;   // 엔딩을 위한 몹 카운트
        private int middleCount; // 엔딩을 위한 중간 몹 카운트
        private int bossCount;  // 엔딩을 위한 보스 카운트


        public static PlayerDTO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<PlayerDTO>();
                }
                return instance;
            }
        }
        void Start()
        {
            maxHp = 100;
            currentHp = 100;
            maxStamina = 100;
            currentStamina = 100;
            hunger = currentStamina;

            mobCount = 0;
            middleCount = 0;
            bossCount = 0;
        }
        public float getMaxHp()
        {
            return this.maxHp;
        }

        public void setMaxHp(float maxHp)
        {
            this.maxHp = maxHp;
        }

        public float getCurrentHp()
        {
            return this.currentHp;
        }

        public void setCurrentHp(int currentHp)
        {
            this.currentHp = currentHp;
        }

        public float getMaxStamina()
        {
            return this.maxStamina;
        }

        public void setMaxStamina(float maxStamina)
        {
            this.maxStamina = maxStamina;
        }

        public float getCurrentStamina()
        {
            return this.currentStamina;
        }

        public void setCurrentStamina(float currentStamina)
        {
            this.currentStamina = currentStamina;
        }
        public float getHunger()
        {
            return this.hunger;
        }

        public void setHunger(float hunger)
        {
            this.hunger = hunger;
        }

        public bool isIsPlayerRun()
        {
            return this.isPlayerRun;
        }

        public void setIsPlayerRun(bool isPlayerRun)
        {
            this.isPlayerRun = isPlayerRun;
        }
        public int getTiredFlag()
        {
            return this.tiredFlag;
        }

        public void setTiredFlag(int tiredFlag)
        {
            this.tiredFlag = tiredFlag;
        }
        public bool isDeath()
        {
            return this.death;
        }

        public void setDeath(bool death)
        {
            this.death = death;
        }
        public int getKillCount()
        {
            return this.killCount;
        }

        public void setKillCount(int killCount)
        {
            this.killCount = killCount;
        }

        public int getMobCount()
        {
            return this.mobCount;
        }

        public void setMobCount(int mobCount)
        {
            this.mobCount = mobCount;
        }

        public int getBossCount()
        {
            return this.bossCount;
        }

        public void setBossCount(int bossCount)
        {
            this.bossCount = bossCount;
        }

        public int getMiddleCount()
        {
            return this.middleCount;
        }

        public void setMiddleCount(int middleCount)
        {
            this.middleCount = middleCount;
        }
    }
    
}
