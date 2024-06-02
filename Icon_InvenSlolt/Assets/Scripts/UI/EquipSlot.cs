using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipSlot : BaseIconSlot
{

    protected override void InitAwake()
    {
        if (m_ISinit)
            return;

        // 추가 초기화용 작업하기

        base.InitAwake();
    }

    public override void OnDrop(PointerEventData eventData)
    {
        if (eventData.selectedObject == null)
            return;


        MoveIcon icon = eventData.selectedObject.GetComponent<MoveIcon>();
        BaseIconSlot slot = eventData.pointerDrag.GetComponent<BaseIconSlot>();

        // 아이템 정보 가져오기

        int playerat = slot.PlayerItemListAt;
        m_LinkItemData = PlayerItemDataManager.Instance.GetItemAt(playerat);
        if(m_LinkItemData == null)
        {
            return;
        }


        base.OnDrop(eventData);

    }


}
