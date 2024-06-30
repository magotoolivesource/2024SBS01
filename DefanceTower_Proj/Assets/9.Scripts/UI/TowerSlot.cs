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

        // �� �Է� �޵��� �ϱ����ؼ� new ���
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



}
