using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_ItemType
{
    None = 0,

    Food = 10,
    Apple,
    Beer,
    Bread,


    Equipment = 1000,
    Bag,

    Max = 99999999
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

    [ContextMenu("[°ª¼¼ÆÃ]")]
    public void InitSetting()
    {
        //SpritePath = $"{prevresouceitem}/{E_ItemType.Food}/{E_ItemType.Apple}

        ID = (int)ItemTypeID;
        SpriteImg = Resources.Load<Sprite>(SpritePath);
        
    }


}
