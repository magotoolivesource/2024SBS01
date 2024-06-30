using UnityEditor.Purchasing;
using UnityEngine;

public class TowerDragMoveUI : InGameDragMoveUI
{

    public Sprite m_Test_Image = null;

    public override void _On_BeginDrag()
    {
        int at = m_LinkData;

        // at 이용해서 타워 이미지 읽어 오도록 하기
        m_LinkImg.sprite = m_Test_Image;

    }
}
