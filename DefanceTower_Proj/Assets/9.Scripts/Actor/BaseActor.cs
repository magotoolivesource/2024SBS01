using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;



public class BaseActor : MonoBehaviour
{
    //public int HP = 0;


    [SerializeField]
    protected Transform m_TargetTrans;


    [Header("확인용")]
    [SerializeField]
    protected Animator m_LinkAnimator;
    protected Vector2 m_DirectionVec = Vector2.zero;

    E_Direction m_Driection = E_Direction.Down;

    //protected Stack<Vector3> m_PathData = new Stack<Vector3>();

    private void Awake()
    {
        m_LinkAnimator = GetComponentInChildren<Animator>();

        // 임시용
        SetTarget(m_TargetTrans);
    }

    void UpdateTarget()
    {
        if (m_TargetTrans == null)
            return;

        Vector3 dirvec = m_TargetTrans.transform.position - transform.position;
        m_DirectionVec = dirvec.normalized;

        if (m_DirectionVec.x > 0.5f)
        {
            m_LinkAnimator.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            m_LinkAnimator.transform.localScale = Vector3.one;
        }
    }

    void Update()
    {
        // 이동처리
        UpdateTargetMove();


        // 보는 방향
        UpdateTarget();
        m_LinkAnimator.SetFloat("MoveX", m_DirectionVec.x);
        m_LinkAnimator.SetFloat("MoveY", m_DirectionVec.y);

    }


    public void SetDebuffMoveSpeed(float p_movespeed, float p_lifesec )
    {

    }
    // 1초동안 이동 디버프
    public void SetMoveSpeed(float p_movespeed)
    {
        MoveSpeed = p_movespeed;
    }

    
    public E_NaigationType MoveID = 0;
    public float MoveSpeed = 1f;
    protected Vector3 m_MoveDirection = Vector3.zero;
    protected void UpdateTargetMove()
    {
        // 유도냐 아니면 그냥 목표지점으로 이동 시킬것이냐
        if (false)
            SetTargetDirection();

        Vector3 temppos = transform.position;
        temppos += (m_MoveDirection * MoveSpeed * Time.deltaTime);

        transform.position = temppos;
    }

    protected void SetTargetDirection()
    {
        if (m_TargetTrans == null)
            return;

        m_MoveDirection = m_TargetTrans.position - transform.position;
        m_MoveDirection.Normalize();
    }
    // 타겟지정
    public void SetTarget(Transform p_target)
    {
        m_TargetTrans = p_target;
        SetTargetDirection();
    }
}
