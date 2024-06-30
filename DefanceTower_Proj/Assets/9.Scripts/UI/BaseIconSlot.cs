using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BaseIconSlot : MonoBehaviour
    , IDragHandler
    , IDropHandler
    , IBeginDragHandler
    , IEndDragHandler
    , IPointerUpHandler
    , IPointerClickHandler
    , IPointerDownHandler
{
    [Header("[작업용]")]
    [SerializeField]
    protected Image m_IconImage = null;

    [SerializeField]
    protected int m_PlayerItemListAt = -1;
    public int PlayerItemListAt
    {
        get { return m_PlayerItemListAt; }
    }

    [Header("[확인용]")]
    //[SerializeField]
    //protected PlayerItemTableData m_LinkItemData = null;
    [SerializeField]
    protected Canvas m_LinkCanvas = null;
    //[SerializeField]
    //protected E_ItemType m_ItemID;
    //[SerializeField]
    //protected ItemTableData m_LinkTableData = null;


    protected bool m_ISinit = false;
    protected virtual void InitAwake()
    {
        if (m_ISinit)
            return;

        m_ISinit = true;

        //Debug.Log("아이콘슬롯 : Awake");

        if (m_IconImage == null)
            m_IconImage = GetComponentInChildren<Image>();

        m_LinkCanvas = GetComponentInParent<Canvas>();

        SetPlayerItemAt(m_PlayerItemListAt);
    }

    protected virtual void Awake()
    {
        InitAwake();

    }




    public virtual void SetPlayerItemAt(int p_at)
    {
        m_PlayerItemListAt = p_at;
        UpdateUI();
    }

    public virtual void UpdateUI()
    {

    }




    //public virtual void SetIcon( E_ItemType p_id )
    //{
    //    m_IconImage.gameObject.SetActive(true);

    //    //m_ItemID = p_id;

    //    //if( m_ItemID == E_ItemType.None)
    //    //{
    //    //    m_IconImage.gameObject.SetActive(false);
    //    //    return;
    //    //}


    //    //ItemTableData itemdata = ItemDataManager.GetInstance.GetItemData(p_id);
    //    m_LinkTableData = ItemDataManager.GetInstance.GetItemData(p_id);
    //    m_IconImage.sprite = m_LinkTableData.SpriteImg;// p_sprite;

    //    //m_ItemCountText.text = "1";

    //}


    [SerializeField]
    protected MoveIcon m_LinkMove = null;
    protected bool m_ISDrag = false;

    public virtual void OnDrop(PointerEventData eventData)
    {
        if (eventData.selectedObject == null)
            return;
        

        Debug.Log( $"드랍 : {this.name}, {eventData.pointerDrag.name }, {eventData.selectedObject.name}");

        MoveIcon icon = eventData.selectedObject.GetComponent<MoveIcon>();
        BaseIconSlot slot = eventData.pointerDrag.GetComponent<BaseIconSlot>();

        int prevat = this.m_PlayerItemListAt;
        this.SetPlayerItemAt(slot.m_PlayerItemListAt);
        slot.SetPlayerItemAt(prevat);
    }

    public virtual void OnDrag(PointerEventData eventData)
    {

        Debug.Log("드래그 ");

        Camera cam = m_LinkCanvas.worldCamera;
        if (cam == null 
            || m_LinkCanvas.renderMode == RenderMode.ScreenSpaceOverlay
            )
            m_LinkMove.transform.position = Input.mousePosition;
        else
        {
            Vector3 wpos;
            RectTransform recttrans = GetComponent<RectTransform>();
            if(RectTransformUtility.ScreenPointToWorldPointInRectangle(recttrans
                , Input.mousePosition
                , cam
                , out wpos))
            {
                m_LinkMove.transform.position = wpos;
            }


        }
    }
    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        m_ISDrag = true;

        // 수정하기
        m_LinkMove = null;// ItemDataManager.GetInstance.MoveIcon;
        m_LinkMove.BeginDrag(this.m_PlayerItemListAt);

        eventData.selectedObject = m_LinkMove.gameObject;

        Debug.Log("드래그 시작 ");
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        m_ISDrag = false;
        m_LinkMove.EndDrag();
        m_LinkMove = null;
        Debug.Log( $"드래그 끝 : {this.name}, {eventData.pointerDrag.name} ");
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("마우스업 ");
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("마우스 클릭 ");

        if (!m_ISDrag)
        {
            Debug.Log("아이템사용");
        }
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        m_ISDrag = false;
    }
}
