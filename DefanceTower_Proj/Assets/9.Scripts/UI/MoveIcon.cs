using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent( typeof(Image) )]
public class MoveIcon<T_DATA> : MonoBehaviour // where T : struct
{
    //[SerializeField]
    //protected E_ItemType m_ItemType;

    //public E_ItemType ItemType
    //{
    //    get
    //    {
    //        return m_ItemType;
    //    }
    //}

    [Header("[È®ÀÎ¿ë]")]
    [SerializeField]
    protected Image m_LinkImg;

    protected T_DATA m_LinkData;
    public void BeginDrag(T_DATA p_icondata )
    {
        //T val = default(T); 

        gameObject.SetActive(true);
        m_LinkData = p_icondata;

        //SetItem(p_itemtype);

        //SetItemAt(p_playeritemat);
    }

    

    public void EndDrag()
    {
        gameObject.SetActive(false);
    }


    //public int ItemAt = -1;
    //protected PlayerItemTableData m_LinkItemTable = null;
    //void SetItemAt(int p_playeritemat)
    //{
    //    ItemAt = p_playeritemat;
    //    m_LinkItemTable = PlayerItemDataManager.Instance.GetItemAt(ItemAt);

    //    m_ItemType = m_LinkItemTable.ItemTypeID;
    //    m_LinkImg.sprite = m_LinkItemTable.SpriteImg;
    //}

    //void SetItem(E_ItemType p_itemtype)
    //{
    //    m_ItemType = p_itemtype;
    //    ItemTableData data = ItemDataManager.GetInstance.GetItemData(m_ItemType);
    //    m_LinkImg.sprite = data.SpriteImg;
    //}

    void InitSettings()
    {
        m_LinkImg = GetComponent<Image>();
    }

    private void Awake()
    {
        gameObject.SetActive(false);
        InitSettings();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    //protected int m_SkillID = -1;
    //public int SkillID
    //{
    //    get { return m_SkillID; }
    //}
    //public void BeginDragSkill(int p_skillid)
    //{
        
    //    gameObject.SetActive(true);
    //    //SetItem(p_itemtype);

    //    SetSkillID(p_skillid);
    //}

    //protected void SetSkillID(int p_skillid)
    //{
    //    m_LinkItemTable = null;

    //    m_SkillID = p_skillid;
    //    SkillTableData tabledata = SkillDataManager.Instance.GetSkillTableData_ID(p_skillid);
    //    //m_ItemType = m_LinkItemTable.ItemTypeID;
    //    m_LinkImg.sprite = tabledata.SpriteImg;

    //}

}
