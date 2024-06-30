using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public enum E_SLOTDATAUPDATE
{
    SWAP = 0,
    SRC2DEST,
    DEST2SRC,
    ONLYDATA,
}

[System.Serializable]
public abstract class BaseIconSlot<T_DATA> : MonoBehaviour
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

    //[SerializeField]
    //protected int m_PlayerItemListAt = -1;
    //public int PlayerItemListAt
    //{
    //    get { return m_PlayerItemListAt; }
    //}

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

        m_LinkCanvas = GetComponentInParent<Canvas>(true);
        SetData(m_LinkData);
        SetMoveIcon();
    }

    protected abstract void SetMoveIcon();
    //{
    //    m_LinkMove = GameObject.FindFirstObjectByType<MoveIcon<T_DATA>>();
    //}

    protected virtual void Awake()
    {
        InitAwake();

    }




    public virtual void SetData(T_DATA p_data)
    {
        m_LinkData = p_data;

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


    [ReadOnlyInspector]
    [SerializeField]
    protected T_DATA m_LinkData;


    [ReadOnlyInspector]
    [SerializeField]
    protected MoveIcon<T_DATA> m_LinkMove = null;
    protected bool m_ISDrag = false;

    public E_SLOTDATAUPDATE m_DropType = E_SLOTDATAUPDATE.SWAP;
    protected virtual void _OnDropDatas(PointerEventData eventData)
    {
        Debug.Log($"드랍 : {this.name}, {eventData.pointerDrag.name}, {eventData.selectedObject.name}");
        MoveIcon<T_DATA> icon = eventData.selectedObject.GetComponent<MoveIcon<T_DATA>>();
        BaseIconSlot<T_DATA> slot = eventData.pointerDrag.GetComponent<BaseIconSlot<T_DATA>>();

        if(m_DropType == E_SLOTDATAUPDATE.SWAP )
        {
            // 서로 치환
            T_DATA prevdata = this.m_LinkData;
            this.SetData(slot.m_LinkData);
            slot.SetData(prevdata);
        }
        else if(m_DropType == E_SLOTDATAUPDATE.SRC2DEST)
        {
            // 원본에서 복사
            T_DATA prevdata = this.m_LinkData;
            this.SetData(slot.m_LinkData);
            //slot.SetData(prevdata);
        }
        else if (m_DropType == E_SLOTDATAUPDATE.DEST2SRC)
        {
            // 원본만 수정
            T_DATA prevdata = this.m_LinkData;
            //this.SetData(slot.m_LinkData);
            slot.SetData(prevdata);
        }

    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.selectedObject == null)
            return;

        _OnDropDatas(eventData);

    }

    public virtual void OnDrag(PointerEventData eventData)
    {

        //Debug.Log("드래그 ");

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
        //m_LinkMove = null;// ItemDataManager.GetInstance.MoveIcon;
        m_LinkMove.BeginDrag( m_LinkData );

        eventData.selectedObject = m_LinkMove.gameObject;

        Debug.Log("드래그 시작 ");
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        m_ISDrag = false;
        m_LinkMove.EndDrag();
        //m_LinkMove = null;
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
