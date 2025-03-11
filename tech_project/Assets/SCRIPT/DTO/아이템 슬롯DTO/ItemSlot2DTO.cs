using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DTO.ItemSlotDTO
{
    public class ItemSlot2DTO : MonoBehaviour
    {
        private static ItemSlot2DTO instance;

        //변수 영역---------
        private string ItemSlot2_Id="000001";//임시
        //------------------

        public static ItemSlot2DTO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<ItemSlot2DTO>();
                }
                return instance;
            }
        }

        public string getItemSlot2_Id()
        {
            return this.ItemSlot2_Id;
        }
        public void setItemSlot2_Id(string ItemSlot2_Id)
        {
            this.ItemSlot2_Id = ItemSlot2_Id;
        }

    }
}

