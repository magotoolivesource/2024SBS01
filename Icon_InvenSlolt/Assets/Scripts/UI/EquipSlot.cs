using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipSlot : BaseIconSlot
{
    [Header("[Ȯ�� �۾���]")]
    public E_ItemCategory ItemCategory;

    public E_EquipType EquipType;
    public E_WeaponType WeaponType;

    protected override void InitAwake()
    {
        if (m_ISinit)
            return;

        // �߰� �ʱ�ȭ�� �۾��ϱ�

        base.InitAwake();
    }


    protected bool ISWeaponType(E_WeaponType p_weaponitem)
    {
        int outval = ((int)WeaponType & (int)p_weaponitem);
        if( outval == (int)p_weaponitem)
        {
            return true;
        }

        return false;
    }
    public override void OnDrop(PointerEventData eventData)
    {
        if (eventData.selectedObject == null)
            return;

        MoveIcon icon = eventData.selectedObject.GetComponent<MoveIcon>();
        BaseIconSlot slot = eventData.pointerDrag.GetComponent<BaseIconSlot>();

        if (slot as SkillSlot)
        {
            return;
        }

        // ������ ���� ��������

        int playerat = slot.PlayerItemListAt;
        m_LinkItemData = PlayerItemDataManager.Instance.GetItemAt(playerat);
        if(m_LinkItemData == null)
        {
            return;
        }


        if(m_LinkItemData.ItemCategory != ItemCategory)
        {
            return;
        }

        if(m_LinkItemData.ItemCategory == E_ItemCategory.Equip )
        {
            if(m_LinkItemData.ItemEquipType == EquipType)
            {
                base.OnDrop(eventData);
            }
        }
        else if(m_LinkItemData.ItemCategory == E_ItemCategory.Weapon)
        {
            if( ISWeaponType(m_LinkItemData.ItemWeaponType) )
            {
                base.OnDrop(eventData);
            }
        }



    }


}
