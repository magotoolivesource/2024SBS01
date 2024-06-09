using UnityEngine;
using UnityEngine.EventSystems;

public class SkillSlot : BaseIconSlot
{
    [SerializeField]
    protected int m_Skill_ID = -1;

    [Header("[Ȯ�ο�]")]
    [SerializeField]
    protected PlayerSkillTableData m_PlayerSkillTableData = null;

    protected override void InitAwake()
    {
        if (m_ISinit)
            return;


        base.InitAwake();

        SetSkillID(m_Skill_ID);
    }

    public void SetSkillID( int p_at)
    {
        m_Skill_ID = p_at;
        UpdateUI();
    }

    public override void SetPlayerItemAt(int p_at)
    {
        return;
        //m_PlayerItemListAt = p_at;
        UpdateUI();
    }

    public override void UpdateUI()
    {
        PlayerSkillTableData skilldata = SkillDataManager.Instance.GetSkillID(m_Skill_ID);
        //SkillTableData skilldata2 = SkillDataManager.Instance.GetSkillTableData_ID(m_SkillIndex);

        if(skilldata == null)
        {
            m_IconImage.gameObject.SetActive(false);
            return;
        }

        m_PlayerSkillTableData = skilldata;
        m_IconImage.gameObject.SetActive(true);
        m_IconImage.sprite = skilldata.SpriteImg;


    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        m_ISDrag = true;
        m_LinkMove = ItemDataManager.GetInstance.MoveIcon;
        m_LinkMove.BeginDragSkill(m_Skill_ID);

        eventData.selectedObject = m_LinkMove.gameObject;

        Debug.Log("�巡�� ���� ");

    }


    public override void OnDrop(PointerEventData eventData)
    {
        // �ٸ��ʿ��� �������� ����� �Ǿ�����
        return;


        if (eventData.selectedObject == null)
            return;


        Debug.Log($"��� : {this.name}, {eventData.pointerDrag.name}, {eventData.selectedObject.name}");


        
        MoveIcon icon = eventData.selectedObject.GetComponent<MoveIcon>();
        BaseIconSlot destslot = eventData.pointerDrag.GetComponent<BaseIconSlot>();

    }


}
