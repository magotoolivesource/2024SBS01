using UnityEngine;
using UnityEngine.UI;


public class CodeBaseUI : MonoBehaviour
{

    public RectTransform m_World;
    public RectTransform m_Local;
    public RectTransform m_Option;


    protected void SetPrevExit()
    {
        Image img = GetComponent<Image>();
        //GameObject.Destroy(img);
    }
    protected void SetWorldEnter()
    {
        m_World.gameObject.SetActive(true);
        // 월드에서 사용되는 모든 소스 작업
        this.gameObject.AddComponent<Image>();
    }

    protected void SetLocalEnter()
    {
        m_Local.gameObject.SetActive(true);
        // 월드에서 사용되는 모든 소스 작업
        this.gameObject.AddComponent<Animator>();

    }

    public void ChangeUIState( E_UIState p_changetype )
    {
        SetPrevExit();
        m_World.gameObject.SetActive(false);
        m_Local.gameObject.SetActive(false);
        m_Option.gameObject.SetActive(false);
        switch (p_changetype)
        {
            case E_UIState.World:
                SetWorldEnter();
                
                break;
            case E_UIState.Local:
                //m_Local.gameObject.SetActive(true);
                SetLocalEnter();
                break;
            case E_UIState.Option:
                m_Option.gameObject.SetActive(true);
                break;
            default:
                break;
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
