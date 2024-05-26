using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class PlayerItemTableData : ItemTableData
{

    public PlayerItemTableData(ItemTableData p_itemtable)
    {
        ID = p_itemtable.ID;
        ItemTypeID = p_itemtable.ItemTypeID;
        ItemName = p_itemtable.ItemName;
        ItemDescript = p_itemtable.ItemDescript;

        SpritePath = p_itemtable.SpritePath;
        SpriteImg = p_itemtable.SpriteImg;
    }
    //public ItemTableData m_LinkTableData;
    public int ItemCount = 0;
}

public class PlayerItemDataManager : SingletonT<PlayerItemDataManager>
{
    [SerializeField]
    protected List<PlayerItemTableData> m_PlayerItemTableDataList = new List<PlayerItemTableData>();


    public PlayerItemTableData GetItemAt(int p_at)
    {
        if (p_at <= -1 && m_PlayerItemTableDataList.Count >= p_at)
            return null;

        return m_PlayerItemTableDataList[p_at];
    }
    public PlayerItemTableData GetItem(E_ItemType p_itemtype)
    {
        foreach (var item in m_PlayerItemTableDataList)
        {
            if( item.ItemTypeID == p_itemtype )
            {
                return item;
            }
        }

        return null;
    }
    public void AddItem( E_ItemType p_itemtype )
    {
        PlayerItemTableData item = GetItem(p_itemtype);
        if(item == null)
        {
            ItemTableData tabledata = ItemDataManager.GetInstance.GetItemData(p_itemtype);
            item = new PlayerItemTableData(tabledata);
            m_PlayerItemTableDataList.Add(item);
        }
        item.ItemCount += 1;
        
    }
    public void UseItem(E_ItemType p_itemtype)
    {
        PlayerItemTableData item = GetItem(p_itemtype);
        if( item == null)
        {
            Debug.LogError("값이 없습니다 확인하세요");
            return;
        }

        item.ItemCount -= 1;
        if( item.ItemCount <= 0)
        {
            m_PlayerItemTableDataList.Remove(item);
        }
    }
    public void RemoveItem(E_ItemType p_itemtype)
    {

    }

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
