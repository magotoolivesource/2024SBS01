using UnityEngine;

public class TowerUpgradPanel : MonoBehaviour
{

    [SerializeField, ReadOnlyInspector]
    protected Tower m_LinkTower = null;

    public void ShowUpgradPanel(Tower p_linktower)
    {
        gameObject.SetActive(true);

        m_LinkTower = p_linktower;

        SpriteRenderer render = m_LinkTower.m_ModelRender;

        BoxCollider2D collider = render.GetComponent<BoxCollider2D>();
        Bounds bound2d = collider.bounds;
        //Vector3 w_min = bound2d.min;
        Vector3 w_max = bound2d.max - bound2d.min; // 0,0 을기준으로한 월드값반환
        
        // 인게임 카메라
        Camera ingamcam = Camera.main;

        //ingamcam.WorldToViewportPoint()

        Vector3 screen_minpos = ingamcam.WorldToScreenPoint(bound2d.min);
        Vector3 screen_maxpos = ingamcam.WorldToScreenPoint(bound2d.max);
        Vector3 screen_centerpos = ingamcam.WorldToScreenPoint(bound2d.center);

        RectTransform recttrans = GetComponent<RectTransform>();
        recttrans.sizeDelta = screen_maxpos - screen_minpos;
        recttrans.anchoredPosition = screen_centerpos;
        //recttrans.position = bound2d.center;

    }

    public void HidePanel()
    {
        gameObject.SetActive(false);
    }

    public void _On_UpBTNClick()
    {
        Debug.Log($"업데이트 클릭 : {m_LinkTower.name} ");
    }
    public void _On_DownBTNClick()
    {
        Debug.Log($"판매 클릭 : {m_LinkTower.name} ");
    }
    public void _On_CloseBTNClick()
    {
        HidePanel();
    }


    private void Awake()
    {
        gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
