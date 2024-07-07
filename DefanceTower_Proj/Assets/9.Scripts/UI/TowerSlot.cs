using UnityEngine;
using UnityEngine.EventSystems;

public class TowerSlot : InGameBaseSlot
{

    public int TowerID = -1;




    protected override void InitAwake()
    {
        base.InitAwake();
        m_DropType = E_SLOTDATAUPDATE.SRC2DEST;

        TowerInfoData infodata = TowerInfoDataManager.Instance.GetTowerID(TowerID);
        m_IconImage.sprite = infodata.UI3DSprite;

        // 값 입력 받도록 하기위해서 new 사용
        m_LinkData = new InGameTowerData();
        m_LinkData.TowerID = TowerID;
    }

    protected override void SetMoveIcon()
    {
        if(m_LinkMove == null)
            m_LinkMove = GameObject.FindFirstObjectByType<TowerDragMoveUI>( FindObjectsInactive.Include );
    }
    
    protected override void _OnDropDatas(PointerEventData eventData)
    {
        // 
        base._OnDropDatas(eventData);

    }


    public override void OnDrag(PointerEventData eventData)
    {
        // 
        Camera cam = m_LinkCanvas.worldCamera;

        if (cam == null
            || m_LinkCanvas.renderMode == RenderMode.ScreenSpaceOverlay
            )
        {
            m_LinkMove.transform.position = Input.mousePosition;
        }
        else
        {
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

        Camera maincam = Camera.main;
        ExtendCore.GridSnapMove(m_LinkMove.GetComponent<RectTransform>(), maincam);

    }

    


}
