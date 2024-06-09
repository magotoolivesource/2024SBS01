using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InvenSlot : BaseIconSlot
{
    [Header("[확인용]")]
    [SerializeField]
    protected Text m_ItemCountText = null;

    protected override void InitAwake()
    {
        if (m_ISinit)
            return;

        m_ItemCountText = GetComponentInChildren<Text>();
        base.InitAwake();

    }

    public override void UpdateUI()
    {
        InitAwake();

        base.UpdateUI();

        if(m_LinkItemData != null )
            m_ItemCountText.text = $"{m_LinkItemData.ItemCount}";

    }

    public override void OnDrop(PointerEventData eventData)
    {
        if (eventData.selectedObject == null)
            return;

        Debug.Log($"드랍 : {this.name}, {eventData.pointerDrag.name}, {eventData.selectedObject.name}");
        MoveIcon icon = eventData.selectedObject.GetComponent<MoveIcon>();
        BaseIconSlot slot = eventData.pointerDrag.GetComponent<BaseIconSlot>();

        if (slot as SkillSlot)
        {
            return;
        }
            

        // inven -> inven, equip -> inven
        if ( !(slot is QuickSlot) )
        {
            base.OnDrop(eventData);
            return;
        }


        // quick -> inven 예외처리
        int prevat = this.m_PlayerItemListAt;
        int slotat = slot.PlayerItemListAt;
        // 찾기
        InvenSlot[] invenslotarr = this.transform.parent.GetComponentsInChildren<InvenSlot>();
        foreach (var slotitem in invenslotarr)
        {
            if(slotitem.PlayerItemListAt == slotat)
            {
                slotitem.SetPlayerItemAt(-1);
            }
        }

        this.SetPlayerItemAt(slotat);
        QuickSlot quickslot = slot as QuickSlot;

        if( slotat != prevat )
        {
            quickslot.SetEndDragNotDelete();
            quickslot.SetPlayerItemAt(prevat);
        }
        else
        {
            //quickslot.SetPlayerItemAt(-1);
        }
        
        
        
    }



    //protected void Awake()
    //{
    //    base.Awake();
    //}



}
