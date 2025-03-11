using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Item_Base;
using DataBase;
using System.Linq;
using Item_Tooltip;



namespace Item_Craft
{
public class ItemCraft : MonoBehaviour
{
    private List<Item> RecipeList = new List<Item>();

    //무기
    public static bool isPistol = false; //static쓰기 싫은데 그럼 DTO에 만들어서 해야됨 아래에 예시코드있음
    public static bool isUzi = false;
    public static bool isAK = false;
    public static bool isM4 = false;
    public static bool isDouble = false;
    public static bool isPump = false;
    public static bool isM249 = false;
    public static bool isRPG = false;

    //모자
    public static bool isHat1 = false;
    public static bool isHat2 = false;
    public static bool isHat3 = false;
    public static bool isHat4 = false;

    //상의
    public static bool isShirt1 = false;
    public static bool isShirt2 = false;
    public static bool isShirt3 = false;
    public static bool isShirt4 = false;

    //하의
    public static bool isPants1 = false;
    public static bool isPants2 = false;
    public static bool isPants3 = false;
    public static bool isPants4 = false;

    /*
    public bool isPistol
    {
        get { return PlayerPrefs.GetInt("isPistol", 0) == 1; }
        set { PlayerPrefs.SetInt("isPistol", value ? 1 : 0); }
    }

    public bool isAK
    {
        get { return PlayerPrefs.GetInt("isAK", 0) == 1; }
        set { PlayerPrefs.SetInt("isAK", value ? 1 : 0); }
    }
    */
    
    #region ---------------------무기 제작--------------------------
    public int Pistol() //test버전 (Pistol은 기본무기여서 만들필요 없음)
    {
        //레시피 가져오기
        RecipeList = ItemRecipe.instance.BulletRecipe();

        // 이미 가지고 있는지 확인
        if (isPistol)
        {
            Debug.Log("이미 Pistol을 가지고 있습니다.");
            return -1;
        }

        // 제작 시작
        if (CraftingItem()) 
        {
            isPistol = true;
            InventoryDAO.inventoryItemList.Add(new Item("Pistol(Clone)","Pistol", "Pistol",Item.ItemType.Equip,Item.UnderType.Gun,1));
            Debug.Log("inventory에 Pistol 추가 성공");
            return 1;
        }
        else
        {
            Debug.Log("inventory에 Pistol 추가 실패");
            return 0;
        }
    }

    public int Uzi()
    {
        RecipeList = ItemRecipe.instance.UziRecipe();

        if (isUzi)
        {
            Debug.Log("이미 Uzi를 가지고 있습니다.");
            return -1;
        }

        if (CraftingItem())
        {
            isUzi = true;
            InventoryDAO.inventoryItemList.Add(new Item("Uzi(Clone)", "Uzi", "Uzi", Item.ItemType.Equip, Item.UnderType.Gun, 1));
            Debug.Log("inventory에 Uzi 추가 성공");
            return 1;
        }
        else
        {
            Debug.Log("inventory에 Uzi 추가 실패");
            return 0;
        }
    }

    public int AK()
    {
        RecipeList = ItemRecipe.instance.AKRecipe();

        if (isAK)
        {
            Debug.Log("이미 AK를 가지고 있습니다.");
            return -1;
        }

        if (CraftingItem())
        {
            isAK = true;
            InventoryDAO.inventoryItemList.Add(new Item("AK(Clone)", "AK", "AK", Item.ItemType.Equip, Item.UnderType.Gun, 1));
            Debug.Log("inventory에 AK 추가 성공");
            return 1;
        }
        else
        {
            Debug.Log("inventory에 AK 추가 실패");
            return 0;
        }
    }

    public int M4()
    {
        RecipeList = ItemRecipe.instance.M4Recipe();

        if (isM4)
        {
            Debug.Log("이미 M4를 가지고 있습니다.");
            return -1;
        }

        if (CraftingItem())
        {
            isM4 = true;
            InventoryDAO.inventoryItemList.Add(new Item("M4(Clone)", "M4", "M4", Item.ItemType.Equip, Item.UnderType.Gun, 1));
            Debug.Log("inventory에 M4 추가 성공");
            return 1;
        }
        else
        {
            Debug.Log("inventory에 M4 추가 실패");
            return 0;
        }
    }

    public int Double()
    {
        RecipeList = ItemRecipe.instance.DoubleRecipe();

        if (isDouble)
        {
            Debug.Log("이미 Double을 가지고 있습니다.");
            return -1;
        }

        if (CraftingItem())
        {
            isDouble = true;
            InventoryDAO.inventoryItemList.Add(new Item("Double(Clone)", "Double", "Double", Item.ItemType.Equip, Item.UnderType.Gun, 1));
            Debug.Log("inventory에 Double 추가 성공");
            return 1;
        }
        else
        {
            Debug.Log("inventory에 Double 추가실패");
            return 0;
        }
    }

    public int Pump()
    {
        RecipeList = ItemRecipe.instance.PumpRecipe();

        if (isPump)
        {
            Debug.Log("이미 Pump을 가지고 있습니다.");
            return -1;
        }

        if (CraftingItem())
        {
            isPump = true;
            InventoryDAO.inventoryItemList.Add(new Item("Pump(Clone)", "Pump", "Pump", Item.ItemType.Equip, Item.UnderType.Gun, 1));
            Debug.Log("inventory에 Pump 추가 성공");
            return 1;
        }
        else
        {
            Debug.Log("inventory에 Pump 추가 실패");
            return 0;
        }
    }

    public int M249()
    {
        RecipeList = ItemRecipe.instance.M249Recipe();

        if (isM249)
        {
            Debug.Log("이미 M249를 가지고 있습니다.");
            return -1;
        }

        if (CraftingItem())
        {
            isM249 = true;
            InventoryDAO.inventoryItemList.Add(new Item("M249(Clone)", "M249", "M249", Item.ItemType.Equip, Item.UnderType.Gun, 1));
            Debug.Log("inventory에 M249 추가 성공");
            return 1;
        }
        else
        {
            Debug.Log("inventory에 M249 추가 실패");
            return 0;
        }
    }

    public int RPG()
    {
        RecipeList = ItemRecipe.instance.RPGRecipe();

        if (isRPG)
        {
            Debug.Log("이미 RPG를 가지고 있습니다.");
            return -1;
        }

        if (CraftingItem())
        {
            isRPG = true;
            InventoryDAO.inventoryItemList.Add(new Item("RPG(Clone)", "RPG", "RPG", Item.ItemType.Equip, Item.UnderType.Gun, 1));
            Debug.Log("inventory에 RPG 추가 성공");
            return 1;
        }
        else
        {
            Debug.Log("inventory에 RPG 추가 실패");
            return 0;
        }
    }

    #endregion


    #region ---------------------소비 제작--------------------------
    public int Bullet()
    {
        if (CraftingItem())
        {
            //InventoryDAO.instance.GetInvenItem("Hat1(Clone)", 1); //소비는 GetInvenItem을 사용해서 추가
            //Debug.Log("inventory에 총알 추가 성공");
            return 1;
        }
        else
        {
            //Debug.Log("inventory에 총알 추가 실패");
            return 0;
        }
    }

    public int Grena()
    {
        return 1;
    }

    public int Smoke()
    {
        return 1;
    }

    #endregion


    #region ---------------------모자 제작--------------------------
    public int Hat1()
    {
        RecipeList = ItemRecipe.instance.Hat1Recipe();

        if (isHat1)
        {
            Debug.Log("이미 Hat을 가지고 있습니다.");
            return -1;
        }

        if (CraftingItem())
        {
            isHat1 = true;
            InventoryDAO.instance.GetInvenItem("Hat1(Clone)", 1);
            Debug.Log("inventory에 Hat 추가 성공");
            return 1;
        }
        else
        {
            Debug.Log("inventory에 Hat 추가 실패");
            return 0;
        }
    }

    public int Hat2() //2단계에만 착용했는지 확인함
    {
        RecipeList = ItemRecipe.instance.Hat2Recipe();

        if (isHat2) // 이미 가지고 있는는 경우
        {
            Debug.Log("이미 Hat2를 가지고 있습니다.");
            return -1;
        }
        else if (isHat1 == false) //이전 장비를 제작하지 않았을 경우
        {
            Debug.Log("Hat1을 가지고 있지 않습니다.");
            return -2;
        }
        else if(ItemTooltip.instance.OnHat_Iamge.sprite != Resources.Load<Sprite>("ItemIcon/Hat1(Clone)")) //이전 장비를 착용하지 않을 경우
        {
            Debug.Log("Hat1을 착용하지 않았습니다.");
            return -3;
        }
        
        if (CraftingItem()) // 제작 완료한 경우
        {
            isHat2 = true; 
            ItemTooltip.instance.OnHat_Iamge.sprite = Resources.Load<Sprite>("ItemIcon/Hat2(Clone)");
            EquipItemEffect.instance.EquipItemEffectLogic("Hat2(Clone)");
            Debug.Log("inventory에 Hat2 적용 성공");
            return 1;
        }
        else // 제작 실패한 경우
        {
            Debug.Log("inventory에 Hat2 추가 실패");
            return 0;
        }
    }

    public int Hat3()
    {
        RecipeList = ItemRecipe.instance.Hat3Recipe();

        if (isHat2 == false) //이전 장비를 제작하지 않았을 경우
        {
            Debug.Log("Hat2을 가지고 있지 않습니다.");
            return -2;
        }
        else if (isHat3) // 이미 가지고 있는는 경우
        {
            Debug.Log("이미 Hat3를 가지고 있습니다.");
            return -1;
        }
        
        if (CraftingItem()) // 제작 완료한 경우
        {
            isHat3 = true; 
            ItemTooltip.instance.OnHat_Iamge.sprite = Resources.Load<Sprite>("ItemIcon/Hat3(Clone)");
            EquipItemEffect.instance.EquipItemEffectLogic("Hat3(Clone)");
            Debug.Log("inventory에 Hat3 적용 성공");
            return 1;
        }
        else // 제작 실패한 경우
        {
            Debug.Log("inventory에 Hat3 추가 실패");
            return 0;
        }
    }

    public int Hat4()
    {
        RecipeList = ItemRecipe.instance.Hat4Recipe();

        if (isHat3 == false) //이전 장비를 제작하지 않았을 경우
        {
            Debug.Log("Hat3을 가지고 있지 않습니다.");
            return -2;
        }
        else if (isHat4) // 이미 가지고 있는는 경우
        {
            Debug.Log("이미 Hat4를 가지고 있습니다.");
            return -1;
        }
        
        if (CraftingItem()) // 제작 완료한 경우
        {
            isHat4 = true; 
            ItemTooltip.instance.OnHat_Iamge.sprite = Resources.Load<Sprite>("ItemIcon/Hat4(Clone)");
            EquipItemEffect.instance.EquipItemEffectLogic("Hat4(Clone)");
            Debug.Log("inventory에 Hat4 적용 성공");
            return 1;
        }
        else // 제작 실패한 경우
        {
            Debug.Log("inventory에 Hat4 추가 실패");
            return 0;
        }
    }

    #endregion


    #region ---------------------상의 제작--------------------------
    public int Shirt1()
    {
        RecipeList = ItemRecipe.instance.Shirt1Recipe();

        if (isShirt1)
        {
            Debug.Log("이미 Shirt을 가지고 있습니다.");
            return -1;
        }

        if (CraftingItem())
        {
            isShirt1 = true;
            InventoryDAO.inventoryItemList.Add(new Item("Shirt1(Clone)", "Shirt", "Shirt", Item.ItemType.Equip, Item.UnderType.Shirt, 1));
            Debug.Log("inventory에 Shirt 추가 성공");
            return 1;
        }
        else
        {
            Debug.Log("inventory에 Shirt 추가 실패");
            return 0;
        }
    }

    public int Shirt2()
    {
        RecipeList = ItemRecipe.instance.Shirt2Recipe();

        if(ItemTooltip.instance.OnShirt_Iamge.sprite != Resources.Load<Sprite>("ItemIcon/Shirt1(Clone)")) //이전 장비를 착용하지 않을 경우
        {
            Debug.Log("Shirt1을 착용하지 않았습니다.");
            return -3;
        }
        else if (isShirt1 == false) //이전 장비를 제작하지 않았을 경우
        {
            Debug.Log("Shirt1을 가지고 있지 않습니다.");
            return -2;
        }
        else if (isShirt2) // 이미 가지고 있는는 경우
        {
            Debug.Log("이미 Shirt2를 가지고 있습니다.");
            return -1;
        }
        
        if (CraftingItem()) // 제작 완료한 경우
        {
            isShirt2 = true; 
            ItemTooltip.instance.OnShirt_Iamge.sprite = Resources.Load<Sprite>("ItemIcon/Shirt2(Clone)");
            EquipItemEffect.instance.EquipItemEffectLogic("Shirt2(Clone)");
            Debug.Log("inventory에 Shirt2 적용 성공");
            return 1;
        }
        else // 제작 실패한 경우
        {
            Debug.Log("inventory에 Shirt2 추가 실패");
            return 0;
        }
    }

    public int Shirt3()
    {
        RecipeList = ItemRecipe.instance.Shirt3Recipe();

        if (isShirt2 == false) //이전 장비를 제작하지 않았을 경우
        {
            Debug.Log("Shirt2을 가지고 있지 않습니다.");
            return -2;
        }
        else if (isShirt3) // 이미 가지고 있는는 경우
        {
            Debug.Log("이미 Shirt3를 가지고 있습니다.");
            return -1;
        }
        
        if (CraftingItem()) // 제작 완료한 경우
        {
            isShirt3 = true; 
            ItemTooltip.instance.OnShirt_Iamge.sprite = Resources.Load<Sprite>("ItemIcon/Shirt3(Clone)");
            EquipItemEffect.instance.EquipItemEffectLogic("Shirt3(Clone)");
            Debug.Log("inventory에 Shirt3 적용 성공");
            return 1;
        }
        else // 제작 실패한 경우
        {
            Debug.Log("inventory에 Shirt3 추가 실패");
            return 0;
        }
    }

    public int Shirt4()
    {
        RecipeList = ItemRecipe.instance.Shirt4Recipe();

        if (isShirt3 == false) //이전 장비를 제작하지 않았을 경우
        {
            Debug.Log("Shirt3을 가지고 있지 않습니다.");
            return -2;
        }
        else if (isShirt4) // 이미 가지고 있는는 경우
        {
            Debug.Log("이미 Shirt4를 가지고 있습니다.");
            return -1;
        }
        
        if (CraftingItem()) // 제작 완료한 경우
        {
            isShirt4 = true; 
            ItemTooltip.instance.OnShirt_Iamge.sprite = Resources.Load<Sprite>("ItemIcon/Shirt4(Clone)");
            EquipItemEffect.instance.EquipItemEffectLogic("Shirt4(Clone)");
            Debug.Log("inventory에 Shirt4 적용 성공");
            return 1;
        }
        else // 제작 실패한 경우
        {
            Debug.Log("inventory에 Shirt4 추가 실패");
            return 0;
        }
    }
    #endregion


    #region ---------------------하의 제작--------------------------
    public int Pants1()
    {
        RecipeList = ItemRecipe.instance.Pants1Recipe();

        if (isPants1)
        {
            Debug.Log("이미 Pants을 가지고 있습니다.");
            return -1;
        }

        if (CraftingItem())
        {
            isPants1 = true;
            InventoryDAO.inventoryItemList.Add(new Item("Pants1(Clone)", "Pants", "Pants", Item.ItemType.Equip, Item.UnderType.Pants, 1));
            Debug.Log("inventory에 Pants 추가 성공");
            return 1;
        }
        else
        {
            Debug.Log("inventory에 Pants 추가 실패");
            return 0;
        }
    }

    public int Pants2()
    {
        RecipeList = ItemRecipe.instance.Pants2Recipe();

        if(ItemTooltip.instance.OnPants_Iamge.sprite != Resources.Load<Sprite>("ItemIcon/Pants1(Clone)")) //이전 장비를 착용하지 않을 경우
        {
            Debug.Log("Pants1을 착용하지 않았습니다.");
            return -3;
        }
        else if (isPants1 == false) //이전 장비를 제작하지 않았을 경우
        {
            Debug.Log("Pants1을 가지고 있지 않습니다.");
            return -2;
        }
        else if (isPants2) // 이미 가지고 있는는 경우
        {
            Debug.Log("이미 Pants2를 가지고 있습니다.");
            return -1;
        }
        
        if (CraftingItem()) // 제작 완료한 경우
        {
            isPants2 = true; 
            ItemTooltip.instance.OnPants_Iamge.sprite = Resources.Load<Sprite>("ItemIcon/Pants2(Clone)");
            EquipItemEffect.instance.EquipItemEffectLogic("Pants2(Clone)");
            Debug.Log("inventory에 Pants2 적용 성공");
            return 1;
        }
        else // 제작 실패한 경우
        {
            Debug.Log("inventory에 Pants2 추가 실패");
            return 0;
        }
    }

    public int Pants3()
    {
        RecipeList = ItemRecipe.instance.Pants3Recipe();

        if (isPants2 == false) //이전 장비를 제작하지 않았을 경우
        {
            Debug.Log("Pants2을 가지고 있지 않습니다.");
            return -2;
        }
        else if (isPants3) // 이미 가지고 있는는 경우
        {
            Debug.Log("이미 Pants3를 가지고 있습니다.");
            return -1;
        }
        
        if (CraftingItem()) // 제작 완료한 경우
        {
            isPants3 = true; 
            ItemTooltip.instance.OnPants_Iamge.sprite = Resources.Load<Sprite>("ItemIcon/Pants3(Clone)");
            EquipItemEffect.instance.EquipItemEffectLogic("Pants3(Clone)");
            Debug.Log("inventory에 Pants3 적용 성공");
            return 1;
        }
        else // 제작 실패한 경우
        {
            Debug.Log("inventory에 Pants3 추가 실패");
            return 0;
        }
    }

    public int Pants4()
    {
        RecipeList = ItemRecipe.instance.Pants4Recipe();

        if (isPants3 == false) //이전 장비를 제작하지 않았을 경우
        {
            Debug.Log("Pants3을 가지고 있지 않습니다.");
            return -2;
        }
        else if (isPants4) // 이미 가지고 있는는 경우
        {
            Debug.Log("이미 Pants4를 가지고 있습니다.");
            return -1;
        }
        
        if (CraftingItem()) // 제작 완료한 경우
        {
            isPants4 = true; 
            ItemTooltip.instance.OnPants_Iamge.sprite = Resources.Load<Sprite>("ItemIcon/Pants4(Clone)");
            EquipItemEffect.instance.EquipItemEffectLogic("Pants4(Clone)");
            Debug.Log("inventory에 Pants4 적용 성공");
            return 1;
        }
        else // 제작 실패한 경우
        {
            Debug.Log("inventory에 Pants4 추가 실패");
            return 0;
        }
    }
    #endregion

    public bool CraftingItem()
    {
        int checkMater = 0;
        int checkRecipe = 0;

        for (int i = 0; i < RecipeList.Count; i++) // 1. 필요한 재료가 있는지 확인
        {
            if (CraftTableDAO.MaterItemList.Exists(item => item.itemID == RecipeList[i].itemID))
            {
                checkMater++;
            }
        }  
        if (checkMater >= RecipeList.Count) // 2. 그 재료의 갯수가 다 있는지 확인
        {
            //Debug.Log("------1. 재료갯수 확인시작------");
            foreach (var recipeItem in RecipeList)
            {
                int recipeItemCount = recipeItem.itemCount;
                int materItemCount = CraftTableDAO.MaterItemList.Where(item => item.itemID == recipeItem.itemID).Sum(item => item.itemCount);

                if (materItemCount < recipeItemCount)
                {   
                    //Debug.Log("1-1. 재료 부족"+ recipeItem.itemID);
                    // 재료부족 판넬 띄우기
                    return false;
                }
                else
                {
                    checkRecipe++;
                }
            }
            //Debug.Log("-----2. 재료갯수 확인완료------");

            foreach (var recipeItem in RecipeList) // 3. 제작 시작
            {
                int recipeItemCount = recipeItem.itemCount;
                for (int i = 0; i < recipeItemCount; i++)
                {
                    var itemToRemove = CraftTableDAO.MaterItemList.Find(item => item.itemID == recipeItem.itemID);
                    //Debug.Log("itemRecipe_67" + (itemToRemove?.itemID??"null"));
                    if (itemToRemove != null)
                    {
                        if (itemToRemove.itemCount == 1)
                        {
                            CraftTableDAO.MaterItemList.Remove(itemToRemove);
                        }
                        else
                        {
                            itemToRemove.itemCount--;
                        }
                    }
                    else
                    {
                        //Debug.Log("아이템을 찾을 수 없습니다: " + recipeItem.itemID);
                        return false;
                    }
                }
                //Debug.Log("2-1. 제작 가능: 재료 차감 완료");
            }
            //Debug.Log("3. 제작 완료");
            return true;
        }
        else
        {
            Debug.Log("0. 재료부족");
            return false;
        }
    }


    public static bool IsSubset<T>(List<T> a, List<T> b)
    {
        // a 리스트의 모든 요소가 b 리스트에 포함되어 있는지 확인
        return a.All(b.Contains); // b > a
    }



}
}

