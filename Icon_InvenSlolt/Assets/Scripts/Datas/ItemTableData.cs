using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 아이템 모든 정보
public enum E_ItemType
{
    None = 0,



    Food = 1000, // Food
    Apple,
    Beer,
    Bread,


    Equipment = 2000, // Equipment
    Bag, //4
    Belt,
    Helm,
    Iron_Armor, //7
    Iron_Boot,

    WeaponType = 3000, // WeaponType
    Arrow, // 9
    Axe, 
    Bow,
    Golden_Sword,
    Hammer,
    Iron_Shield,


    Max = 99999999
}

public enum E_ItemCategory
{
    UseItem,
    Equip,
    Weapon,
    Skill,


}

public enum E_EquipType
{
    None,
    Helm,
    Armor,
    Belt,
    Boot,
    Bag,
}

[Flags]
public enum E_WeaponType
{
    None = 0,
    //Sword   = 0b0000001,
    //Bow     = 0b0000010,
    //Arrow   = 0b0000100,
    //Hammer  = 0b0001000,
    //Axe     = 0b0010000,
    //Shield  = 0b0100000,

    //Sword = 1 << 0,
    //Bow = 1 << 1,
    //Arrow = 1 << 2,
    //Hammer = 1 << 3,
    //Axe = 1 << 4,
    //Shield = 1 << 5,

    Sword       = 0x0001,
    Bow         = 0x0002,
    Arrow       = 0x0004,
    Hammer      = 0x0008,
    Axe         = 0x0010,
    Shield      = 0x0020,
}



[System.Serializable]
//[CreateAssetMenu()]
public class ItemTableData// : ScriptableObject
{
    public int ID;
    public E_ItemType ItemTypeID;
    public string ItemName;
    public string ItemDescript;

    public string SpritePath;
    public Sprite SpriteImg;

    public E_ItemCategory ItemCategory;
    public E_EquipType ItemEquipType = E_EquipType.None;
    public E_WeaponType ItemWeaponType = E_WeaponType.None;


    public ItemTableData() { }
    public ItemTableData( ItemTableData p_itemtable)
    {
        ID = p_itemtable.ID;
        ItemTypeID = p_itemtable.ItemTypeID;
        ItemName = p_itemtable.ItemName;
        ItemDescript = p_itemtable.ItemDescript;

        SpritePath = p_itemtable.SpritePath;
        SpriteImg = p_itemtable.SpriteImg;

        ItemCategory = p_itemtable.ItemCategory;
        ItemEquipType = p_itemtable.ItemEquipType;
        ItemWeaponType = p_itemtable.ItemWeaponType;
    }

    public void SetItemCategory(E_ItemCategory p_type)
    {
        ItemCategory = p_type;
    }
    public void SetEquip(E_EquipType p_type)
    {
        ItemEquipType = p_type;
    }
    public void SetItemWeaponType(E_WeaponType p_type)
    {
        ItemWeaponType = p_type;
    }

    //public int SubItemType;

    [ContextMenu("[값세팅]")]
    public void InitSetting()
    {
        //SpritePath = $"{prevresouceitem}/{E_ItemType.Food}/{E_ItemType.Apple}

        ID = (int)ItemTypeID;
        SpriteImg = Resources.Load<Sprite>(SpritePath);
        
    }


}
