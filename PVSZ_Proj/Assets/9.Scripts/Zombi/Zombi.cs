using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;





public enum E_ZOMBISTATETYPE
{
    Create,
    Idle,
    Move,
    Attack,
    Attack1,
    Skill1,
    Damage,
    Die,

    Max,
}

public delegate void MyAction();

public partial class Zombi : MonoBehaviour
{

    public float MoveSpeed = 1f;
    void Update()
    {
        if (m_CurrentUpdateFN != null)
        {
            m_CurrentUpdateFN(); // Crate_Update
        }
    }

    [ContextMenu("테스트함수")]
    protected void Init()
    {

        //// enter 배열
        //m_AllEnterActionFNArray[(int)E_ZOMBISTATETYPE.Create] = Create_Enter;
        //m_AllEnterActionFNArray[(int)E_ZOMBISTATETYPE.Move] = Move_Enter;

        //// update 배열
        //m_AllUpdateActionFNArray[(int)E_ZOMBISTATETYPE.Create] = Crate_Update;
        //m_AllUpdateActionFNArray[(int)E_ZOMBISTATETYPE.Idle] = null;
        //m_AllUpdateActionFNArray[(int)E_ZOMBISTATETYPE.Move] = Move_Update;

        //// exit 배열
        //m_AllExitActionFNArray[(int)E_ZOMBISTATETYPE.Create] = Crate_Exit;
        //m_AllExitActionFNArray[(int)E_ZOMBISTATETYPE.Move] = Move_Exit;



        Debug.Log("Init 호출");

        int count = (int)E_ZOMBISTATETYPE.Max;
        m_AllEnterActionFNArray = new Action[count];
        m_AllUpdateActionFNArray = new Action[count];
        m_AllExitActionFNArray = new Action[count];

        E_ZOMBISTATETYPE temptype;
        Type currtype = typeof(Zombi);
        Action tempaction = null;
        for (int i = 0; i < count; i++)
        {
            temptype = (E_ZOMBISTATETYPE)i;

            string tempstr = temptype.ToString(); // Create_Enter
            string enter_findmethodstr = $"{tempstr}_Enter";
            string exit_findmethodstr = $"{tempstr}_Exit";
            string update_findmethodstr = $"{tempstr}_Update";

            // enter
            MethodInfo methodinfo = currtype.GetMethod(enter_findmethodstr
                , BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public
                );
            if (methodinfo != null)
            {
                Delegate tempdel = methodinfo.CreateDelegate(typeof(Action), this);
                m_AllEnterActionFNArray[i] = tempdel as Action;
            }

            methodinfo = currtype.GetMethod(exit_findmethodstr
                , BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public
                );
            if (methodinfo != null)
            {
                Delegate tempdel = methodinfo.CreateDelegate(typeof(Action), this);
                m_AllExitActionFNArray[i] = tempdel as Action;
            }

            methodinfo = currtype.GetMethod(update_findmethodstr
                , BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public
                );
            if (methodinfo != null)
            {
                Delegate tempdel = methodinfo.CreateDelegate(typeof(Action), this);
                m_AllUpdateActionFNArray[i] = tempdel as Action;
            }
        }


        //        m_AllEnterActionFNArray[0]();
        SetChangeState(E_ZOMBISTATETYPE.Create);
    }

    protected void TempInit()
    {
        SetChangeState(E_ZOMBISTATETYPE.Create);
        // 시간이 지나서

        SetChangeState(E_ZOMBISTATETYPE.Move);
    }


    protected MethodInfo[] m_AllEnterActionFNArray2;


    protected Action[] m_AllEnterActionFNArray;
    protected Action[] m_AllUpdateActionFNArray;
    protected Action[] m_AllExitActionFNArray;

    //protected Dictionary<E_ZOMBISTATETYPE, Action[]>



    [SerializeField]
    E_ZOMBISTATETYPE m_TestState = E_ZOMBISTATETYPE.Create;
    [ContextMenu("상태 변경")]
    protected void _Editor_StateChange()
    {
        SetChangeState(m_TestState);
    }

    [SerializeField, ReadOnlyInspector]
    E_ZOMBISTATETYPE m_CurrentStateType = E_ZOMBISTATETYPE.Max;
    [SerializeField, ReadOnlyInspector]
    E_ZOMBISTATETYPE m_PrevStateType = E_ZOMBISTATETYPE.Max;

    protected Action m_CurrentUpdateFN = null;
    public void SetChangeState(E_ZOMBISTATETYPE p_state)
    {
        m_PrevStateType = m_CurrentStateType;

        // exit 쪽 호출
        if (m_CurrentStateType != E_ZOMBISTATETYPE.Max
            && m_AllExitActionFNArray[(int)m_CurrentStateType] != null)
        {
            m_AllExitActionFNArray[(int)m_CurrentStateType]();
        }

        
        m_CurrentStateType = p_state;

        // enter 쪽 호출
        if (m_AllEnterActionFNArray[(int)m_CurrentStateType] != null)
        {
            m_AllEnterActionFNArray[(int)m_CurrentStateType]();
        }

        // update 등록
        m_CurrentUpdateFN = m_AllUpdateActionFNArray[(int)m_CurrentStateType];
    }


	void Awake()
	{
        Init();
    }



}
