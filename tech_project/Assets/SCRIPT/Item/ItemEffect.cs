using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DTO.PlayerDTO;
using DTO.ItemDTO;

using Item_Tooltip;
using Equip.Grenade;

using UseItem;

namespace Function.ItemEffect
{
    public class ItemEffect : MonoBehaviour
    {  
        #region  //아이템기능 클래스 불러올때 선언-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // 아이템 추가할때 1번
        private aGrenade grenade;
        private SmokeGrenade smokeGrenade;
        private Pear pear;
        private Mushroom mushroom;
        private Barrel barrel;
        private SodaButtle sodaButtle;
        private SodaCan sodaCan;
        private WineRed wineRed;
        private Carrot carrot;

        private Honey honey;
        private StrawBerry strawBerry;
        private Steak steak;
        private CandyBar candyBar;
        private Choco choco;
        private Orange orange;

        #endregion -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private ItemTooltip tooltip;
        
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private string ItemBtnID; //아이템 아이디 저장 변수
        public static ItemEffect instance;

        public Image SlotBtnImage1;  // 스프라이트 이름 가져오는 용도
        public Image SlotBtnImage2;
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private Dictionary<string, Action> itemLogicDictionary = new Dictionary<string, Action>(); // 아이템 로직을 저장할 딕셔너리 (사용할 아이템 구분용도)

        private PlayerDTO pdto;  
        private ItemDTO itemDTO;


        void Start()
        {
            GetItemVo();
            InitializeItemLogic();
        }

        public static ItemEffect Instance {
            get {
                if (instance == null) {
                    instance = FindObjectOfType<ItemEffect>();
                }
                return instance;
            }
        }
    
        public void UseItemEffect(int SlotNum)
        {
            Image selectedImage = SlotNum == 1 ? SlotBtnImage1 : SlotBtnImage2;
            ItemBtnID = selectedImage.sprite.name;
            SearchItemID(SlotNum);
        }

        public void SearchItemID(int SlotNum)
        {
            //Debug.Log("클릭한 퀵 슬롯 아이디 : " + ItemBtnID);

            if (tooltip == null)
            {
                tooltip = ItemTooltip.instance;
            }

            // 딕셔너리에서 아이템을 찾는 부분
            if (itemLogicDictionary.TryGetValue(ItemBtnID, out Action itemLogic))
            {
                itemLogic();
                Debug.Log(ItemBtnID + " 아이템 사용");
            }
            tooltip.Type_if_use(ItemBtnID, SlotNum); // 아이템 사용시 개수 조절 및 업데이트 
        }


    
    //새로운 아이템 추가시 아이템 기능 클래스 불러올때 추가-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        void GetItemVo(){
            tooltip = ItemTooltip.instance;

            // 아이템 추가할때 2번
            grenade = aGrenade.Instance;//수류탄 인스턴스
            smokeGrenade = SmokeGrenade.Instance;//연막탄 인스턴스
            pear = Pear.Instance;   //배 인스턴스 
            mushroom = Mushroom.Instance; //버섯 인스턴스                                
            barrel = Barrel.Instance; //통 인스턴스
            sodaButtle = SodaButtle.Instance; //소다병 인스턴스
            sodaCan = SodaCan.Instance; //소다캔 인스턴스
            wineRed = WineRed.Instance; //와인 인스턴스
            carrot = Carrot.Instance; //당근 인스턴스

            honey = Honey.Instance; //꿀 인스턴스
            strawBerry = StrawBerry.Instance; //딸기 인스턴스
            steak = Steak.Instance; //스테이크 인스턴스
            candyBar = CandyBar.Instance; //사탕 인스턴스
            choco = Choco.Instance; //초코 인스턴스
            orange = Orange.Instance; //오렌지 인스턴스

        }

        public void InitializeItemLogic()   // 딕셔너리에 아이템 추가하는 부분
        {
            // 아이템 추가할때 3번
            itemLogicDictionary.Add("pear(Clone)", pear.PearLogic);
            itemLogicDictionary.Add("mushroom(Clone)", mushroom.MushroomLogic);
            itemLogicDictionary.Add("Grena(Clone)", grenade.GrenadeLogic);
            itemLogicDictionary.Add("Smoke(Clone)", smokeGrenade.SmokeGrenadeLogic);
            itemLogicDictionary.Add("barrel(Clone)", barrel.BarrelLogic);
            itemLogicDictionary.Add("sodaBottle(Clone)", sodaButtle.SodaButtleLogic);
            itemLogicDictionary.Add("sodaCan(Clone)", sodaCan.SodaCanLogic);
            itemLogicDictionary.Add("wineRed(Clone)", wineRed.WineRedLogic);
            itemLogicDictionary.Add("carrot(Clone)", carrot.CarrotLogic);

            itemLogicDictionary.Add("honey(Clone)", honey.HoneyLogic);
            itemLogicDictionary.Add("strawBerry(Clone)", strawBerry.StrawBerryLogic);
            itemLogicDictionary.Add("steak(Clone)", steak.SteakLogic);
            itemLogicDictionary.Add("candyBar(Clone)", candyBar.CandyBarLogic);
            itemLogicDictionary.Add("choco(Clone)", choco.ChocoLogic);
            itemLogicDictionary.Add("orange(Clone)", orange.OrangeLogic);
            

        }

        /*protected void SetUseItemProperties(){        // 실험중
            itemDTO = ItemDTO.Instance;

            recoveryHP = UseItem.recoveryHP;
            recoveryStamina = UseItem.recoveryStamina;
            recoveryHunger = UseItem.recoveryHunger;
            Cooldown = UseItem.Cooldown;
        }

        public void updateUseItemDTO()
        {
            ItemDTO.setRecoveryHP(recoveryHP);
            ItemDTO.setRecoveryStamina(recoveryStamina);
            ItemDTO.setRecoveryHunger(recoveryHunger);
            ItemDTO.setCooldown(Cooldown);
        }*/
    }
}

            /*grenade.GrenadeLogic(); 
            smokeGrenade.SmokeGrenadeLogic();*/ 
