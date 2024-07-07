using UnityEngine;

public class Test_UGUIPos : MonoBehaviour
{


    public Transform m_3DWorldBox;
    public Transform m_2DUGUIPos;


    public Camera m_InGaemCam;
    public Canvas m_RootCanvas;


    void Start()
    {
        
    }


    protected void UpdateUGUIPos()
    {
        if( Input.GetKeyDown(KeyCode.H) )
        {
            Vector3 wpos;
            bool isflag;
            wpos = UGUIExtendFNs.World2UGuiScreenWorldPos(m_3DWorldBox.position
                , m_InGaemCam
                , m_RootCanvas );

            m_2DUGUIPos.position = wpos;
        }
        
    }
    void Update()
    {
        UpdateUGUIPos();
    }
}
