using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatorFSMUI_Manager_Old : MonoBehaviour
{

    public GameObject m_worldmapobj;
    void Old_init()
    {
        GameObject worldmapobj = m_worldmapobj;// GameObject.Find("World_Map");
        GameObject localmapobj = GameObject.Find("Local_Map");
        GameObject optionmapobj = GameObject.Find("Option");


        // 애니메이터에 세팅
        Animator animator = GetComponent<Animator>();
        WorldUI_Be[] worlduiarr = animator.GetBehaviours<WorldUI_Be>();
        foreach (var be_ui in worlduiarr)
        {
            be_ui.WorldUIObj = worldmapobj;
        }

        LocalUI_Be[] localarr = animator.GetBehaviours<LocalUI_Be>();
        foreach (var be_ui in localarr)
        {
            be_ui.LocalMapUI = localmapobj;
        }


        worldmapobj.SetActive(false);
        localmapobj.SetActive(false);
        optionmapobj.SetActive(false);
    }

    void Awake()
    {
        Old_init();
    }


    public void ChangeUI(E_UIState state)
    {
        GetComponent<Animator>().SetBool("World", false);
        GetComponent<Animator>().SetBool("Local", false);

        switch (state)
        {
            case E_UIState.World:
                GetComponent<Animator>().SetBool("World", true);
                break;
            case E_UIState.Local:
                GetComponent<Animator>().SetBool("Local", true);
                break;
            case E_UIState.Option:
                break;
            default:
                break;
        }
    }

    [ContextMenu("[월드이동]")]
    protected void _Editor_UIWorld()
    {
        ChangeUI(E_UIState.World);
    }
    [ContextMenu("[로컬이동]")]
    protected void _Editor_UILocal()
    {
        ChangeUI(E_UIState.Local);
    }

}
