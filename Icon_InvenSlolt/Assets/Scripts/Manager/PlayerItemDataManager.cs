using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class PlayerItemTableData : ItemTableData
{
    // uuid
    public long ItemUID = 0;

    public PlayerItemTableData(ItemTableData p_itemtable) : base(p_itemtable)
    {
        
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
            if(tabledata != null)
            {
                item = new PlayerItemTableData(tabledata);

                // 현재 생성된 시간
                item.ItemUID = ExtendFNs.GetUinqeID();

                m_PlayerItemTableDataList.Add(item);
            }
            else
            {
                Debug.LogError($"아이템 값 이상함 : {p_itemtype}");
                return;
            }
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
