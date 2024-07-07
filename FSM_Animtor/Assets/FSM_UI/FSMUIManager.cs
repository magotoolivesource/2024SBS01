using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor.Animations;
using UnityEngine;


[RequireComponent (typeof(Animator))]
public class FSMUIManager : MonoBehaviour
{
    protected Animator m_LinkAnimator = null;
    protected RuntimeAnimatorController m_LinkAniControl = null;


    protected List<IUI_Be> m_UIStateList = new List<IUI_Be> ();
    protected void Init()
    {

        m_LinkAnimator = GetComponent<Animator> ();
        m_LinkAniControl = m_LinkAnimator.runtimeAnimatorController;

        // 초기화
        int size = (int)E_UIState.Max;
        for (int i = 0; i < size; i++)
        {
            //m_UIStateList.Add(null);

            E_UIState state = (E_UIState)i;  // World
            string statestr = state.ToString ();
            GameObject uiobj = GameObject.Find(  $"{statestr}_UIMap");
            

            //Type type = Type.GetType ($"{statestr}UI_Be");
            //m_LinkAnimator.GetBehaviour(type);


            IUI_Be becom = null;
            switch (state)
            {
                case E_UIState.World:
                    becom = m_LinkAnimator.GetBehaviour<WorldUI_Be>();//.WorldUIObj = uiobj;
                    break;
                case E_UIState.Local:
                    becom = m_LinkAnimator.GetBehaviour<LocalUI_Be>();
                    break;
                case E_UIState.Option:
                    break;
                default:
                    break;
            }

            m_UIStateList.Add(becom);
            uiobj.SetActive(false);

            if ( becom != null && uiobj != null )
            {
                becom.Init(uiobj);
            }
            else
            {
                Debug.LogError($"값 없음 꼭 확인하기 : {state} 데이터들 없음");
            }
            
        }

    }
    private void Awake()
    {
        Init();

        ChangeUI(E_UIState.World);
    }

    [SerializeField]
    E_UIState m_CurrentState = E_UIState.Max;
    [SerializeField]
    E_UIState m_PrevState = E_UIState.Max;
    public void ChangeUI( E_UIState p_state, bool p_direct = false )
    {
        if (m_CurrentState == p_state)
        {
            return;
        }

        if(m_CurrentState != E_UIState.Max)
        {
            m_LinkAnimator.SetBool($"{m_CurrentState}_Trn", false);
        }

        m_PrevState = m_CurrentState;
        m_CurrentState = p_state;
        m_LinkAnimator.SetBool($"{m_CurrentState}_Trn", true);

    }


    [ContextMenu("[월드이동]")]
    protected void _Editor_UI(E_UIState p_state)
    {
        ChangeUI((E_UIState)p_state);
    }


    public void _On_UIChangeState(int p_state)
    {
        ChangeUI((E_UIState)p_state);
    }


    //[ContextMenu("[월드이동]")]
    //protected void _Editor_UIWorld()
    //{
    //    ChangeUI(E_UIState.World);
    //}
    //[ContextMenu("[로컬이동]")]
    //protected void _Editor_UILocal()
    //{
    //    ChangeUI(E_UIState.Local);
    //}
    //[ContextMenu("[옵션이동]")]
    //protected void _Editor_UIOption()
    //{
    //    ChangeUI(E_UIState.Local);
    //}
}
