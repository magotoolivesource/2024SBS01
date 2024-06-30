using UnityEngine;

public class Tower2UI : MonoBehaviour
{
    [Header("[값 꼭 등록하기용]")]
    // 2d UI parent
    public RectTransform _2DUIPanelParent = null;
    // 2d UI 드래그용
    public TowerBuildSlot m_PrefabSlot = null;


    //public Camera m_IngameCam = null;


    // 참고용
    [Header("[확인용]")]
    [SerializeField]
    protected TowerBuildSlot m_2DUILinkSlot = null;
    [SerializeField]
    protected Canvas m_PrentCanvas = null;


    private void CallBackFN(TowerDragMoveUI p_moveui)
    {
        Debug.Log($"콜백 함수 : {p_moveui}");
        SetTowerData(p_moveui);
    }

    public void SetTowerData(TowerDragMoveUI p_moveui)
    {
        Debug.Log($"타워 세팅 해주기: {p_moveui}");
        var data = p_moveui.LinkData;
        // 실제 3d타워 정보들 업데이트 시키기

    }

    private void Awake()
    {
        m_PrentCanvas = _2DUIPanelParent.GetComponentInParent<Canvas>();

        m_2DUILinkSlot = GameObject.Instantiate(m_PrefabSlot, _2DUIPanelParent);

        m_2DUILinkSlot.m_LinkTower2UI = this;
        m_2DUILinkSlot.m_CallBackFN = CallBackFN; // 현재 사용하지 않는방식
        //m_2DUILinkSlot.m_CallBackFN = GetComponent<Tower>().CallBackFN2;


        // 3d월드 상에 위치 -> 2D 위치로 바꾸기
        Camera cam = m_PrentCanvas.worldCamera;
        if (cam == null 
            || m_PrentCanvas.renderMode == RenderMode.ScreenSpaceOverlay
            )
        {
            // 3d위치
            Camera ingamecam = Camera.main;
            Vector3 screenpos = ingamecam.WorldToScreenPoint(transform.position);

            // 2d위치
            m_2DUILinkSlot.transform.position = screenpos;//Input.mousePosition;
        }
        else
        {

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
