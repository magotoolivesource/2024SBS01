using UnityEngine;
using UnityEngine.UI;

public class Tower2UI : MonoBehaviour
{
    [Header("[�� �� ����ϱ��]")]
    // 2d UI parent
    public RectTransform _2DUIPanelParent = null;
    // 2d UI �巡�׿�
    public TowerBuildSlot m_PrefabSlot = null;


    //public Camera m_IngameCam = null;


    // �����
    [Header("[Ȯ�ο�]")]
    [SerializeField, ReadOnlyInspector]
    protected TowerBuildSlot m_2DUILinkSlot = null;
    
    [SerializeField, ReadOnlyInspector]
    protected Canvas m_PrentCanvas = null;


    private void CallBackFN(TowerDragMoveUI p_moveui)
    {
        Debug.Log($"�ݹ� �Լ� : {p_moveui}");
        SetTowerData(p_moveui);
    }

    public void SetTowerData(TowerDragMoveUI p_moveui)
    {
        var linkdata = p_moveui.LinkData;
        Debug.Log($"Ÿ�� ���� ���ֱ�: {p_moveui}, {linkdata}");

        TowerInfoData data = TowerInfoDataManager.Instance.GetTowerID(linkdata.TowerID);

        // ���� 3dŸ�� ������ ������Ʈ ��Ű��
        GetComponent<Tower>().SetTowerInfoData(linkdata);



        

    }

    private void Awake()
    {
        //GameObject.Find("Panel (1)");
        //Image img = transform.GetComponentInChildrenNName<Image>("�̸�", false);


        //Debug.Log($"{Camera.main.transform.parent}");
        //Transform roottrans = Camera.main.transform.parent;
        
        //Image img = roottrans.GetComponentInChildrenNName<Image>("BottomPanel");
        //_2DUIPanelParent = img.rectTransform;



        m_PrentCanvas = _2DUIPanelParent.GetComponentInParent<Canvas>();

        m_2DUILinkSlot = GameObject.Instantiate(m_PrefabSlot, _2DUIPanelParent);

        m_2DUILinkSlot.m_LinkTower2UI = this;
        m_2DUILinkSlot.m_CallBackFN = CallBackFN; // ���� ������� �ʴ¹��
        //m_2DUILinkSlot.m_CallBackFN = GetComponent<Tower>().CallBackFN2;


        // 3d���� �� ��ġ -> 2D ��ġ�� �ٲٱ�
        Camera cam = m_PrentCanvas.worldCamera;
        if (cam == null 
            || m_PrentCanvas.renderMode == RenderMode.ScreenSpaceOverlay
            )
        {
            // 3d��ġ
            Camera ingamecam = Camera.main;
            Vector3 screenpos = ingamecam.WorldToScreenPoint(transform.position);

            // 2d��ġ
            m_2DUILinkSlot.transform.position = screenpos;//Input.mousePosition;
        }
        else
        {
            Camera ingamecam = Camera.main;
            Vector3 screenpos = ingamecam.WorldToScreenPoint(transform.position);

            // 3d���� ����� ��ġ -> 2d ui Ư�� ��ġ �̵�
            Vector3 wpos;
            RectTransform recttrans = _2DUIPanelParent;
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(recttrans
                , screenpos
                , cam
                , out wpos))
            {
                m_2DUILinkSlot.transform.position = wpos;
            }
        }



    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
