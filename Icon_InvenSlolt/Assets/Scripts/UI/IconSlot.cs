using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IconSlot : MonoBehaviour
    , IDragHandler
    , IDropHandler
    , IBeginDragHandler
    , IEndDragHandler
    , IPointerUpHandler
    , IPointerClickHandler
    , IPointerDownHandler
{

    


    [SerializeField]
    protected Image m_IconImage = null;

    private void Awake()
    {
        if(m_IconImage == null)
            m_IconImage = GetComponentInChildren<Image>();

        m_ItemCountText = GetComponentInChildren<Text>();

        if( true)
        {
            // 테스트 코드
            //SetIcon( m_ItemID );

            SetPlayerItemAt(m_PlayerItemListAt);
        }
        
    }


    [SerializeField]
    int m_PlayerItemListAt = -1;
    PlayerItemTableData m_LinkItemData = null;

    public void SetPlayerItemAt(int p_at)
    {
        m_PlayerItemListAt = p_at;
        UpdateUI();
    }

    public void UpdateUI()
    {
        m_LinkItemData = PlayerItemDataManager.Instance.GetItemAt(m_PlayerItemListAt);

        if(m_LinkItemData == null)
        {
            m_IconImage.gameObject.SetActive(false);
            return;
        }

        m_IconImage.gameObject.SetActive(true);
        m_IconImage.sprite = m_LinkItemData.SpriteImg;
        m_ItemCountText.text = $"{m_LinkItemData.ItemCount}";
    }



    [SerializeField]
    E_ItemType m_ItemID;
    [SerializeField]
    Text m_ItemCountText = null;
    //public int ItemCount = 1;


    [SerializeField]
    protected ItemTableData m_LinkTableData = null;
    public void SetIcon( E_ItemType p_id )
    {
        m_ItemID = p_id;

        if( m_ItemID == E_ItemType.None)
        {
            m_IconImage.gameObject.SetActive(false);
            return;
        }

        m_IconImage.gameObject.SetActive(true);
        //ItemTableData itemdata = ItemDataManager.GetInstance.GetItemData(p_id);
        m_LinkTableData = ItemDataManager.GetInstance.GetItemData(p_id);
        m_IconImage.sprite = m_LinkTableData.SpriteImg;// p_sprite;

        m_ItemCountText.text = "1";

    }



    void Update()
    {
        
    }



    [SerializeField]
    protected MoveIcon m_LinkMove = null;
    bool m_ISDrag = false;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.selectedObject == null)
            return;
        

        Debug.Log( $"드랍 : {this.name}, {eventData.pointerDrag.name }, {eventData.selectedObject.name}");

        MoveIcon icon = eventData.selectedObject.GetComponent<MoveIcon>();
        IconSlot slot = eventData.pointerDrag.GetComponent<IconSlot>();

        //E_ItemType itemtype = this.m_ItemID;
        //// 치환이되었고
        //this.SetIcon(icon.ItemType);

        //// 치환하기
        //slot.SetIcon(itemtype);

        int prevat = this.m_PlayerItemListAt;
        this.SetPlayerItemAt(slot.m_PlayerItemListAt);
        slot.SetPlayerItemAt(prevat);
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (m_ItemID == E_ItemType.None)
            return;

        Debug.Log("드래그 ");

        m_LinkMove.transform.position = Input.mousePosition;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (m_ItemID == E_ItemType.None)
            return;

        
        m_ISDrag = true;
        m_LinkMove = ItemDataManager.GetInstance.MoveIcon;
        //m_LinkMove.BeginDrag(m_ItemID);
        m_LinkMove.BeginDrag(this.m_PlayerItemListAt);

        eventData.selectedObject = m_LinkMove.gameObject;

        Debug.Log("드래그 시작 ");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        m_ISDrag = false;
        //m_LinkMove = ItemDataManager.GetInstance.MoveIcon;
        m_LinkMove.EndDrag();
        m_LinkMove = null;
        Debug.Log( $"드래그 끝 : {this.name}, {eventData.pointerDrag.name} ");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("마우스업 ");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("마우스 클릭 ");

        if (!m_ISDrag)
        {
            Debug.Log("아이템사용");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        m_ISDrag = false;
    }
}
