using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconSlot : MonoBehaviour
{
    [SerializeField]
    protected Image m_IconImage = null;

    private void Awake()
    {
        if(m_IconImage == null)
            m_IconImage = GetComponentInChildren<Image>();

        // 테스트 코드
        SetIcon(E_ItemType.Apple);
    }

    [SerializeField]
    E_ItemType m_ItemID;
    [SerializeField]
    protected ItemTableData m_LinkTableData = null;
    public void SetIcon( E_ItemType p_id )
    {
        //ItemTableData itemdata = ItemDataManager.GetInstance.GetItemData(p_id);
        m_LinkTableData = ItemDataManager.GetInstance.GetItemData(p_id);
        m_IconImage.sprite = m_LinkTableData.SpriteImg;// p_sprite;

    }

    
    void Update()
    {
        
    }
}
