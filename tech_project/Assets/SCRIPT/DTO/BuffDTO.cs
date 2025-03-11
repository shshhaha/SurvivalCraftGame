namespace DTO.BuffDTO{
    public class BuffDTO
    {
        private static BuffDTO instance;

        public static BuffDTO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BuffDTO();
                }
                return instance;
            }
        }

        //플레이어
        private int maxHpBoost;
        private float maxStaminaBoost;
        private float hungerDecSpeedBoost;
        private float playerSpeedBoost;

        public float getMaxHpBoost()
        {
            return this.maxHpBoost;
        }

        public void setMaxHpBoost(int maxHpBoost)
        {
            this.maxHpBoost = maxHpBoost;
        }

        public float getMaxStaminaBoost()
        {
            return this.maxStaminaBoost;
        }

        public void setMaxStaminaBoost(float maxStaminaBoost)
        {
            this.maxStaminaBoost = maxStaminaBoost;
        }

        public float getHungerDecSpeedBoost()
        {
            return this.hungerDecSpeedBoost;
        }

        public void setHungerDecSpeedBoost(float hungerDecSpeedBoost)
        {
            this.hungerDecSpeedBoost = hungerDecSpeedBoost;
        }

        public float getPlayerSpeedBoost()
        {
            return this.playerSpeedBoost;
        }

        public void setPlayerSpeedBoost(float playerSpeedBoost)
        {
            this.playerSpeedBoost = playerSpeedBoost;
        }


        //무기
        private float weaponRPM = 0;
        private float reloadTime = 0;
        private float damage = 0;
        private int maxAmmo = 0;
        private float creaticalRNG = 0;
        private float weaponDispersion = 0;

        public float getWeaponRPM()
        {
            return this.weaponRPM;
        }

        public void setWeaponRPM(float weaponRPM)
        {
            this.weaponRPM = weaponRPM;
        }

        public float getReloadTime()
        {
            return this.reloadTime;
        }

        public void setReloadTime(float reloadTime)
        {
            this.reloadTime = reloadTime;
        }

        public float getDamage()
        {
            return this.damage;
        }

        public void setDamage(float damage)
        {
            this.damage = damage;
        }

        public int getMaxAmmo()
        {
            return this.maxAmmo;
        }

        public void setMaxAmmo(int maxAmmo)
        {
            this.maxAmmo = maxAmmo;
        }

        public float getCreaticalRNG()
        {
            return this.creaticalRNG;
        }

        public void setCreaticalRNG(float creaticalRNG)
        {
            this.creaticalRNG = creaticalRNG;
        }

        public float getWeaponDispersion()
        {
            return this.weaponDispersion;
        }

        public void setWeaponDispersion(float weaponDispersion)
        {
            this.weaponDispersion = weaponDispersion;
        }
    }
}
