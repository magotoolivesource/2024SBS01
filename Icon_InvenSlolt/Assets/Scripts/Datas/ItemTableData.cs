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

public enum E_WeaponType
{
    None,
    Sword,
    Bow,
    Arrow,
    Hammer,
    Axe,
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

    //public int SubItemType;

    [ContextMenu("[값세팅]")]
    public void InitSetting()
    {
        //SpritePath = $"{prevresouceitem}/{E_ItemType.Food}/{E_ItemType.Apple}

        ID = (int)ItemTypeID;
        SpriteImg = Resources.Load<Sprite>(SpritePath);
        
    }


}
