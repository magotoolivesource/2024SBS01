using UnityEngine;
using UnityEngine.EventSystems;

public class TowerSlot : InGameBaseSlot
{
    protected override void InitAwake()
    {
        base.InitAwake();
        m_DropType = E_SLOTDATAUPDATE.SRC2DEST;
    }

    protected override void SetMoveIcon()
    {
        if(m_LinkMove == null)
            m_LinkMove = GameObject.FindFirstObjectByType<TowerDragMoveUI>();
    }
    
    protected override void _OnDropDatas(PointerEventData eventData)
    {
        // 
        base._OnDropDatas(eventData);

    }



}
