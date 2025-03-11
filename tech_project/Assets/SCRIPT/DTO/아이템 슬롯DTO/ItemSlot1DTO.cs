using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DTO.ItemSlotDTO
{
    public class ItemSlot1DTO : MonoBehaviour
    {
        private static ItemSlot1DTO instance;

        //변수 영역---------
        private string ItemSlot1_Id = "000000";//임시
        //------------------

        public static ItemSlot1DTO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<ItemSlot1DTO>();
                }
                return instance;
            }
        }

        public string getItemSlot1_Id()
        {
            return this.ItemSlot1_Id;
        }
        public void setItemSlot1_Id(string ItemSlot1_Id)
        {
            this.ItemSlot1_Id = ItemSlot1_Id;
        }

    }
}

