using UnityEditor.Experimental.GraphView;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuickSlot : BaseIconSlot
{

    protected override void InitAwake()
    {
        if (m_ISinit)
            return;



        base.InitAwake();
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        m_ISEndDragDelete = true;
        base.OnBeginDrag(eventData);
    }
    public override void OnDrop(PointerEventData eventData)
    {
        
        if (eventData.selectedObject == null)
            return;

        MoveIcon icon = eventData.selectedObject.GetComponent<MoveIcon>();
        BaseIconSlot slot = eventData.pointerDrag.GetComponent<BaseIconSlot>();

        // ������ ���� ��������
        int playerat = slot.PlayerItemListAt;
        m_LinkItemData = PlayerItemDataManager.Instance.GetItemAt(playerat);
        if (m_LinkItemData == null)
        {
            return;
        }

        if(m_LinkItemData.ItemCategory != E_ItemCategory.UseItem)
        {
            return;
        }


        // inven -> quick
        if(slot is InvenSlot)
        {
            // ���縦 �ض�
            this.SetPlayerItemAt(playerat);

            // ����ó���ϱ�

        }
        else if(slot is QuickSlot)
        {
            // quick -> quick
            // �߰� ������ �ٲٵ��� �ϱ�
            ((slot) as QuickSlot).m_ISEndDragDelete = false;
            // ����ġȯ
            base.OnDrop(eventData);

            
        }

    }

    protected bool m_ISEndDragDelete = false;
    public void SetEndDragNotDelete()
    {
        m_ISEndDragDelete = false;
    }
    //public bool ISEndDragDelete
    //{
    //    get { return m_ISEndDragDelete; }
    //    set { m_ISEndDragDelete = value; }
    //}

    public override void OnEndDrag(PointerEventData eventData)
    {
        m_ISDrag = false;
        m_LinkMove.EndDrag();
        m_LinkMove = null;
        Debug.Log($"�巡�� �� : {this.name}, {eventData.pointerDrag.name} ");

        if(m_ISEndDragDelete)
        {
            //m_PlayerItemListAt = -1;
            this.SetPlayerItemAt(-1);
        }
        
    }
}
