using System;
using UnityEngine;
using UnityEngine.EventSystems;


[System.Serializable]
public class TowerBuildSlot : InGameBaseSlot
{

    [ReadOnlyInspector]
    public InGameTowerData TestTowerData;


    [ReadOnlyInspector]
    public Tower2UI m_LinkTower2UI = null;

    [Obsolete("���� ����������� m_LinkTower2UI �����")]
    public System.Action<TowerDragMoveUI> m_CallBackFN = null;

    protected override void InitAwake()
    {
        base.InitAwake();
        m_DropType = E_SLOTDATAUPDATE.ONLYDATA;
    }

    protected override void _OnDropDatas(PointerEventData eventData)
    {
        Debug.Log($"��� ���� : {this.name}, {eventData.pointerDrag.name}, {eventData.selectedObject.name}");

        // �����
        //InGameDragMoveUI icon2 = eventData.selectedObject.GetComponent<InGameDragMoveUI>();
        //MoveIcon<int> icon3 = eventData.selectedObject.GetComponent<MoveIcon<int>>();
        TowerDragMoveUI icon = eventData.selectedObject.GetComponent<TowerDragMoveUI>();
        if (icon == null)
            return;

        var itemdata = icon.LinkData;
        m_LinkData = icon.LinkData;

        if ( true )
        {
            m_LinkTower2UI.SetTowerData(icon);
        }
        else
        {
            if (m_CallBackFN != null)
            {
                m_CallBackFN(icon);
            }
        }
        

        //m_LinkTower2UI.setItemData();
    }

}
