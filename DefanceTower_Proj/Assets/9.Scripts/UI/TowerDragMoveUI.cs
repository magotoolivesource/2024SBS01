using UnityEditor.Purchasing;
using UnityEngine;


[System.Serializable]
public class TowerDragMoveUI : InGameDragMoveUI
{

    //public Sprite m_Test_Image = null;

    public override void _On_BeginDrag()
    {
        //int at = m_LinkData;


        TowerInfoData  data = TowerInfoDataManager.Instance.GetTowerID(m_LinkData.TowerID);
        m_LinkImg.sprite = data.UI3DSprite;

    }
}
