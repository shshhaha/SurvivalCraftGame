using Item_Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRecipe : MonoBehaviour
{
    public static ItemRecipe instance;
    public List<Item> RecipeList = new List<Item>();

    void Start()
    {
        instance = this;
    }

    #region //---------------------무기 레시피--------------------------//
    public List<Item> BulletRecipe()
    {
        RecipeList.Clear();
        RecipeList.Add(new Item("gunpowder(Clone)", "화약", "총알을 제작할때 필요한 아이템이다", Item.ItemType.Craft, Item.UnderType.Null, 2));

        return RecipeList;
    }

    public List<Item> UziRecipe()
    {
        RecipeList.Clear();
        RecipeList.Add(new Item("gun parts(Clone)", "총기 부품", "", Item.ItemType.Craft, Item.UnderType.Null, 3));
        RecipeList.Add(new Item("wood(Clone)", "나무", "", Item.ItemType.Craft, Item.UnderType.Null, 3));
        RecipeList.Add(new Item("pipe(Clone)", "pipe", "", Item.ItemType.Craft, Item.UnderType.Null, 3));
        RecipeList.Add(new Item("gear(Clone)", "기어", "   ", Item.ItemType.Craft, Item.UnderType.Null, 3));
        RecipeList.Add(new Item("screw(Clone)", "나사", "", Item.ItemType.Craft, Item.UnderType.Null, 3));
        RecipeList.Add(new Item("spring(Clone)", " ", "", Item.ItemType.Craft, Item.UnderType.Null, 3));
        RecipeList.Add(new Item("nail(Clone)", " ", "", Item.ItemType.Craft, Item.UnderType.Null, 3));
        return RecipeList;
    }

    public List<Item> AKRecipe()
    {
        RecipeList.Clear();
        RecipeList.Add(new Item("gun parts(Clone)", "총기 부품", "", Item.ItemType.Craft, Item.UnderType.Null, 5));
        RecipeList.Add(new Item("wood(Clone)", "나무", "", Item.ItemType.Craft, Item.UnderType.Null, 5));
        RecipeList.Add(new Item("pipe(Clone)", "pipe", "", Item.ItemType.Craft, Item.UnderType.Null, 5));
        RecipeList.Add(new Item("gear(Clone)", "기어", "   ", Item.ItemType.Craft, Item.UnderType.Null, 5));
        RecipeList.Add(new Item("screw(Clone)", "나사", "", Item.ItemType.Craft, Item.UnderType.Null, 5));
        RecipeList.Add(new Item("spring(Clone)", "화약", "", Item.ItemType.Craft, Item.UnderType.Null, 5));
        RecipeList.Add(new Item("nail(Clone)", "총알", "", Item.ItemType.Craft, Item.UnderType.Null, 5));
        return RecipeList;
    }

    public List<Item> M4Recipe()
    {
        RecipeList.Clear();
        RecipeList.Add(new Item("gun parts(Clone)", "총기 부품", "", Item.ItemType.Craft, Item.UnderType.Null, 5));
        RecipeList.Add(new Item("wood(Clone)", "나무", "", Item.ItemType.Craft, Item.UnderType.Null, 5));
        RecipeList.Add(new Item("pipe(Clone)", "pipe", "", Item.ItemType.Craft, Item.UnderType.Null, 5));
        RecipeList.Add(new Item("gear(Clone)", "기어", "   ", Item.ItemType.Craft, Item.UnderType.Null, 5));
        RecipeList.Add(new Item("screw(Clone)", "나사", "", Item.ItemType.Craft, Item.UnderType.Null, 5));
        RecipeList.Add(new Item("spring(Clone)", "화약", "", Item.ItemType.Craft, Item.UnderType.Null, 5));
        RecipeList.Add(new Item("nail(Clone)", "총알", "", Item.ItemType.Craft, Item.UnderType.Null, 5));
        return RecipeList;
    }
    
    public List<Item> DoubleRecipe()
    {
        RecipeList.Clear();
        RecipeList.Add(new Item("gun parts(Clone)", "총기 부품", "", Item.ItemType.Craft, Item.UnderType.Null, 7));
        RecipeList.Add(new Item("wood(Clone)", "나무", "", Item.ItemType.Craft, Item.UnderType.Null, 7));
        RecipeList.Add(new Item("pipe(Clone)", "pipe", "", Item.ItemType.Craft, Item.UnderType.Null, 7));
        RecipeList.Add(new Item("gear(Clone)", "기어", "   ", Item.ItemType.Craft, Item.UnderType.Null, 7));
        RecipeList.Add(new Item("screw(Clone)", "나사", "", Item.ItemType.Craft, Item.UnderType.Null, 7));
        RecipeList.Add(new Item("spring(Clone)", "화약", "", Item.ItemType.Craft, Item.UnderType.Null, 7));
        RecipeList.Add(new Item("nail(Clone)", "총알", "", Item.ItemType.Craft, Item.UnderType.Null, 7));
        return RecipeList;
    }

    public List<Item> PumpRecipe()
    {
        RecipeList.Clear();
        RecipeList.Add(new Item("gun parts(Clone)", "총기 부품", "", Item.ItemType.Craft, Item.UnderType.Null, 7));
        RecipeList.Add(new Item("wood(Clone)", "나무", "", Item.ItemType.Craft, Item.UnderType.Null, 7));
        RecipeList.Add(new Item("pipe(Clone)", "pipe", "", Item.ItemType.Craft, Item.UnderType.Null, 7));
        RecipeList.Add(new Item("gear(Clone)", "기어", "   ", Item.ItemType.Craft, Item.UnderType.Null, 7));
        RecipeList.Add(new Item("screw(Clone)", "나사", "", Item.ItemType.Craft, Item.UnderType.Null, 7));
        RecipeList.Add(new Item("spring(Clone)", "화약", "", Item.ItemType.Craft, Item.UnderType.Null, 7));
        RecipeList.Add(new Item("nail(Clone)", "총알", "", Item.ItemType.Craft, Item.UnderType.Null, 7));
        return RecipeList;
    }

    public List<Item> M249Recipe()
    {
        RecipeList.Clear();
        RecipeList.Add(new Item("gun parts(Clone)", "총기 부품", "", Item.ItemType.Craft, Item.UnderType.Null, 10));
        RecipeList.Add(new Item("wood(Clone)", "나무", "", Item.ItemType.Craft, Item.UnderType.Null, 10));
        RecipeList.Add(new Item("pipe(Clone)", "pipe", "", Item.ItemType.Craft, Item.UnderType.Null, 10));
        RecipeList.Add(new Item("gear(Clone)", "기어", "   ", Item.ItemType.Craft, Item.UnderType.Null, 10));
        RecipeList.Add(new Item("screw(Clone)", "나사", "", Item.ItemType.Craft, Item.UnderType.Null, 10));
        RecipeList.Add(new Item("spring(Clone)", "화약", "", Item.ItemType.Craft, Item.UnderType.Null, 10));
        RecipeList.Add(new Item("nail(Clone)", "총알", "", Item.ItemType.Craft, Item.UnderType.Null, 10));
        return RecipeList;
    }

    public List<Item> RPGRecipe()
    {
        RecipeList.Clear();
        RecipeList.Add(new Item("gun parts(Clone)", "총기 부품", "", Item.ItemType.Craft, Item.UnderType.Null, 12));
        RecipeList.Add(new Item("wood(Clone)", "나무", "", Item.ItemType.Craft, Item.UnderType.Null, 12));
        RecipeList.Add(new Item("pipe(Clone)", "pipe", "", Item.ItemType.Craft, Item.UnderType.Null, 12));
        RecipeList.Add(new Item("gear(Clone)", "기어", "   ", Item.ItemType.Craft, Item.UnderType.Null, 12));
        RecipeList.Add(new Item("screw(Clone)", "나사", "", Item.ItemType.Craft, Item.UnderType.Null, 12));
        RecipeList.Add(new Item("spring(Clone)", "화약", "", Item.ItemType.Craft, Item.UnderType.Null, 12));
        RecipeList.Add(new Item("nail(Clone)", "총알", "", Item.ItemType.Craft, Item.UnderType.Null, 12));
        return RecipeList;
    }
    #endregion

    #region //---------------------모자 레시피--------------------------//
    public List<Item> Hat1Recipe()
    {
        RecipeList.Clear();
        RecipeList.Add(new Item("cloth(Clone)", "", "", Item.ItemType.Craft, Item.UnderType.Null, 5));
        RecipeList.Add(new Item("pipe(Clone)", "", " ", Item.ItemType.Craft, Item.UnderType.Null, 3));
        RecipeList.Add(new Item("gear(Clone)", "기어", " ", Item.ItemType.Craft, Item.UnderType.Null, 3));
        RecipeList.Add(new Item("screw(Clone)", "나사", "", Item.ItemType.Craft, Item.UnderType.Null, 3));
        RecipeList.Add(new Item("nail(Clone)", "", "", Item.ItemType.Craft, Item.UnderType.Null, 3));
        return RecipeList;
    }

    public List<Item> Hat2Recipe()
    {
        RecipeList.Clear();
        RecipeList.Add(new Item("cloth(Clone)", "", "", Item.ItemType.Craft, Item.UnderType.Null, 8));
        RecipeList.Add(new Item("pipe(Clone)", "", " ", Item.ItemType.Craft, Item.UnderType.Null, 5));
        RecipeList.Add(new Item("gear(Clone)", "기어", " ", Item.ItemType.Craft, Item.UnderType.Null, 5));
        RecipeList.Add(new Item("screw(Clone)", "나사", "", Item.ItemType.Craft, Item.UnderType.Null, 5));
        RecipeList.Add(new Item("nail(Clone)", "", "", Item.ItemType.Craft, Item.UnderType.Null, 5));
        return RecipeList;
    }

    public List<Item> Hat3Recipe()
    {
        RecipeList.Clear();
        RecipeList.Add(new Item("cloth(Clone)", "", "", Item.ItemType.Craft, Item.UnderType.Null, 11));
        RecipeList.Add(new Item("pipe(Clone)", "", " ", Item.ItemType.Craft, Item.UnderType.Null, 9));
        RecipeList.Add(new Item("gear(Clone)", "기어", " ", Item.ItemType.Craft, Item.UnderType.Null, 9));
        RecipeList.Add(new Item("screw(Clone)", "나사", "", Item.ItemType.Craft, Item.UnderType.Null, 9));
        RecipeList.Add(new Item("nail(Clone)", "", "", Item.ItemType.Craft, Item.UnderType.Null, 9));
        return RecipeList;
    }

    public List<Item> Hat4Recipe()
    {
        RecipeList.Clear();
        RecipeList.Add(new Item("cloth(Clone)", "", "", Item.ItemType.Craft, Item.UnderType.Null, 18));
        RecipeList.Add(new Item("pipe(Clone)", "", " ", Item.ItemType.Craft, Item.UnderType.Null, 13));
        RecipeList.Add(new Item("gear(Clone)", "기어", " ", Item.ItemType.Craft, Item.UnderType.Null, 13));
        RecipeList.Add(new Item("screw(Clone)", "나사", "", Item.ItemType.Craft, Item.UnderType.Null, 13));
        RecipeList.Add(new Item("nail(Clone)", "", "", Item.ItemType.Craft, Item.UnderType.Null, 13));
        return RecipeList;
    }
    #endregion

    #region //---------------------상의 레시피--------------------------//
    public List<Item> Shirt1Recipe()
    {
        RecipeList.Clear();
        RecipeList.Add(new Item("cloth(Clone)", "", "", Item.ItemType.Craft, Item.UnderType.Null, 5));
        RecipeList.Add(new Item("pipe(Clone)", "", " ", Item.ItemType.Craft, Item.UnderType.Null, 3));
        RecipeList.Add(new Item("gear(Clone)", "기어", " ", Item.ItemType.Craft, Item.UnderType.Null, 3));
        RecipeList.Add(new Item("screw(Clone)", "나사", "", Item.ItemType.Craft, Item.UnderType.Null, 3));
        RecipeList.Add(new Item("nail(Clone)", "", "", Item.ItemType.Craft, Item.UnderType.Null, 3));
        return RecipeList;
    }

    public List<Item> Shirt2Recipe()
    {
        RecipeList.Clear();
        RecipeList.Add(new Item("cloth(Clone)", "", "", Item.ItemType.Craft, Item.UnderType.Null, 8));
        RecipeList.Add(new Item("pipe(Clone)", "", " ", Item.ItemType.Craft, Item.UnderType.Null, 5));
        RecipeList.Add(new Item("gear(Clone)", "기어", " ", Item.ItemType.Craft, Item.UnderType.Null, 5));
        RecipeList.Add(new Item("screw(Clone)", "나사", "", Item.ItemType.Craft, Item.UnderType.Null, 5));
        RecipeList.Add(new Item("nail(Clone)", "", "", Item.ItemType.Craft, Item.UnderType.Null, 5));
        return RecipeList;
    }

    public List<Item> Shirt3Recipe()
    {
        RecipeList.Clear();
        RecipeList.Add(new Item("cloth(Clone)", "", "", Item.ItemType.Craft, Item.UnderType.Null, 11));
        RecipeList.Add(new Item("pipe(Clone)", "", " ", Item.ItemType.Craft, Item.UnderType.Null, 9));
        RecipeList.Add(new Item("gear(Clone)", "기어", " ", Item.ItemType.Craft, Item.UnderType.Null, 9));
        RecipeList.Add(new Item("screw(Clone)", "나사", "", Item.ItemType.Craft, Item.UnderType.Null, 9));
        RecipeList.Add(new Item("nail(Clone)", "", "", Item.ItemType.Craft, Item.UnderType.Null, 9));
        return RecipeList;
    }

    public List<Item> Shirt4Recipe()
    {
        RecipeList.Clear();
        RecipeList.Add(new Item("cloth(Clone)", "", "", Item.ItemType.Craft, Item.UnderType.Null, 18));
        RecipeList.Add(new Item("pipe(Clone)", "", " ", Item.ItemType.Craft, Item.UnderType.Null, 13));
        RecipeList.Add(new Item("gear(Clone)", "기어", " ", Item.ItemType.Craft, Item.UnderType.Null, 13));
        RecipeList.Add(new Item("screw(Clone)", "나사", "", Item.ItemType.Craft, Item.UnderType.Null, 13));
        RecipeList.Add(new Item("nail(Clone)", "", "", Item.ItemType.Craft, Item.UnderType.Null, 13));
        return RecipeList;
    }

    #endregion

    #region //---------------------하의 레시피--------------------------//
    public List<Item> Pants1Recipe()
    {
        RecipeList.Clear();
        RecipeList.Add(new Item("gear(Clone)", "기어", " ", Item.ItemType.Craft, Item.UnderType.Null, 5));
        RecipeList.Add(new Item("cloth(Clone)", "", "", Item.ItemType.Craft, Item.UnderType.Null, 10));
        RecipeList.Add(new Item("screw(Clone)", "나사", "", Item.ItemType.Craft, Item.UnderType.Null, 5));
        return RecipeList;
    }

    public List<Item> Pants2Recipe()
    {
        RecipeList.Clear();
        RecipeList.Add(new Item("gear(Clone)", "기어", " ", Item.ItemType.Craft, Item.UnderType.Null, 8));
        RecipeList.Add(new Item("cloth(Clone)", "", "", Item.ItemType.Craft, Item.UnderType.Null, 13));
        RecipeList.Add(new Item("screw(Clone)", "나사", "", Item.ItemType.Craft, Item.UnderType.Null, 8));
        return RecipeList;
    }

    public List<Item> Pants3Recipe()
    {
        RecipeList.Clear();
        RecipeList.Add(new Item("gear(Clone)", "기어", " ", Item.ItemType.Craft, Item.UnderType.Null, 11));
        RecipeList.Add(new Item("cloth(Clone)", "", "", Item.ItemType.Craft, Item.UnderType.Null, 17));
        RecipeList.Add(new Item("screw(Clone)", "나사", "", Item.ItemType.Craft, Item.UnderType.Null, 11));
        return RecipeList;
    }

    public List<Item> Pants4Recipe()
    {
        RecipeList.Clear();
        RecipeList.Add(new Item("gear(Clone)", "기어", " ", Item.ItemType.Craft, Item.UnderType.Null, 16));
        RecipeList.Add(new Item("cloth(Clone)", "", "", Item.ItemType.Craft, Item.UnderType.Null, 23));
        RecipeList.Add(new Item("screw(Clone)", "나사", "", Item.ItemType.Craft, Item.UnderType.Null, 16));
        return RecipeList;
    }

    #endregion

}