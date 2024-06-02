using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
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

    [SerializeField]
    protected Canvas m_LinkCanvas = null;
    private void Awake()
    {
        if (m_IconImage == null)
            m_IconImage = GetComponentInChildren<Image>();


        m_ItemCountText = GetComponentInChildren<Text>();
        m_ItemCountText.gameObject.SetActive(false);


        //GameObject.FindObjectOfType<Canvas>();
        m_LinkCanvas = GetComponentInParent<Canvas>();
        //m_LinkCanvas.renderMode

        if (true)
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

        if (m_LinkItemData == null)
        {
            m_IconImage.gameObject.SetActive(false);
            return;
        }

        m_IconImage.gameObject.SetActive(true);
        m_IconImage.sprite = m_LinkItemData.SpriteImg;

        if(m_ItemCountText != null)
        {
            m_ItemCountText.text = $"{m_LinkItemData.ItemCount}";
        }
            
    }



    [SerializeField]
    E_ItemType m_ItemID;
    [SerializeField]
    Text m_ItemCountText = null;
    //public int ItemCount = 1;


    [SerializeField]
    protected ItemTableData m_LinkTableData = null;
    public void SetIcon(E_ItemType p_id)
    {
        m_ItemID = p_id;

        if (m_ItemID == E_ItemType.None)
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


        Debug.Log($"드랍 : {this.name}, {eventData.pointerDrag.name}, {eventData.selectedObject.name}");

        MoveIcon icon = eventData.selectedObject.GetComponent<MoveIcon>();
        IconSlot slot = eventData.pointerDrag.GetComponent<IconSlot>();


        
        int prevat = this.m_PlayerItemListAt;
        this.SetPlayerItemAt(icon.ItemAt);
        //slot.SetPlayerItemAt(prevat);
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (m_ItemID == E_ItemType.None)
            return;

        Debug.Log("드래그 ");

        Camera cam = m_LinkCanvas.worldCamera;
        if (cam == null
            || m_LinkCanvas.renderMode == RenderMode.ScreenSpaceOverlay
            )
            m_LinkMove.transform.position = Input.mousePosition;
        else
        {

            // 화면 카메라모드일시 사용되는 방법
            Vector3 wpos;
            RectTransform recttrans = GetComponent<RectTransform>();
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(recttrans
                , Input.mousePosition
                , cam
                , out wpos))
            {
                m_LinkMove.transform.position = wpos;
            }


        }
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
        Debug.Log($"드래그 끝 : {this.name}, {eventData.pointerDrag.name} ");
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
