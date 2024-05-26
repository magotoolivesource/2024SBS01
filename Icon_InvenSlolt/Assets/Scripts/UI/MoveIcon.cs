using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent( typeof(Image) )]
public class MoveIcon : MonoBehaviour
{
    [SerializeField]
    protected E_ItemType m_ItemType;

    [Header("[È®ÀÎ¿ë]")]
    [SerializeField]
    protected Image m_LinkImg;

    public void BeginDrag(E_ItemType p_itemtype)
    {
        gameObject.SetActive(true);
        SetItem(p_itemtype);
    }

    public void EndDrag()
    {
        gameObject.SetActive(false);
    }

    void SetItem(E_ItemType p_itemtype)
    {
        m_ItemType = p_itemtype;
        ItemTableData data = ItemDataManager.GetInstance.GetItemData(m_ItemType);
        m_LinkImg.sprite = data.SpriteImg;
    }

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
}
