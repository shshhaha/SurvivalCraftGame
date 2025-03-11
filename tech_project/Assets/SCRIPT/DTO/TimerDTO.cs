using UnityEngine;

namespace DTO.TimerDTO
{
    public class TimerDTO : MonoBehaviour
    {
        private static TimerDTO instance;

        private int minute;
        private int hour;
        private int date;

        public static TimerDTO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<TimerDTO>();
                }
                return instance;
            }
        }

        public int getMinute()
        {
            return this.minute;
        }

        public void setMinute(int minute)
        {
            this.minute = minute;
        }

        public int getHour()
        {
            return this.hour;
        }

        public void setHour(int hour)
        {
            this.hour = hour;
        }

        public int getDate()
        {
            return this.date;
        }

        public void setDate(int date)
        {
            this.date = date;
        }
    }
}