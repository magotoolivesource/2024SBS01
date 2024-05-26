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
        m_IconImage = GetComponentInChildren<Image>();
    }

    public void SetIcon( int p_id )
    {
        //ItemtableInfo data = GetItemInfo(p_id);
        //m_IconImage.sprite = data.sprite;// p_sprite;
    }

    
    void Update()
    {
        
    }
}
