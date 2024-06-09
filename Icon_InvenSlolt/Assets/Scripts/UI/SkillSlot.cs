using UnityEngine;
using UnityEngine.EventSystems;

public class SkillSlot : BaseIconSlot
{

    protected int SkillIndex;


    public override void SetPlayerItemAt(int p_at)
    {
        return;
        //m_PlayerItemListAt = p_at;
        UpdateUI();
    }

    public override void UpdateUI()
    {


        m_LinkItemData = PlayerItemDataManager.Instance.GetItemAt(m_PlayerItemListAt);

        if (m_LinkItemData == null)
        {
            m_IconImage.gameObject.SetActive(false);
            return;
        }

        m_IconImage.gameObject.SetActive(true);
        m_IconImage.sprite = m_LinkItemData.SpriteImg;
    }


    public override void OnDrop(PointerEventData eventData)
    {
        // 다른쪽에서 내쪽으로 드랍이 되었을때
        return;


        if (eventData.selectedObject == null)
            return;


        Debug.Log($"드랍 : {this.name}, {eventData.pointerDrag.name}, {eventData.selectedObject.name}");


        
        MoveIcon icon = eventData.selectedObject.GetComponent<MoveIcon>();
        BaseIconSlot destslot = eventData.pointerDrag.GetComponent<BaseIconSlot>();

    }


}
