using UnityEditor.Purchasing;
using UnityEngine;

public class TowerDragMoveUI : InGameDragMoveUI
{

    public Sprite m_Test_Image = null;

    public override void _On_BeginDrag()
    {
        int at = m_LinkData;

        // at �̿��ؼ� Ÿ�� �̹��� �о� ������ �ϱ�
        m_LinkImg.sprite = m_Test_Image;

    }
}
