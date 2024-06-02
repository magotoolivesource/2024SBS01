using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InvenSlot : BaseIconSlot
{
    [Header("[È®ÀÎ¿ë]")]
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


    //protected void Awake()
    //{
    //    base.Awake();
    //}



}
