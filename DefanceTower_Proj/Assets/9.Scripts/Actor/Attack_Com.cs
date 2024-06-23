#define NEW_BUFFDEBUFFUSE

using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Attack_Com : MonoBehaviour
{



    [SerializeField]
    protected bool m_ISUse = true;
    [SerializeField]
    protected Tower m_Attacker;
    [SerializeField]
    protected TowerAttackState m_AttackState;
    //protected BaseActor m_Target;
    [SerializeField]
    protected ActorState m_TargetActorState;
    protected Vector3 m_TargetPos;

    [SerializeField]
    protected float LifeSec = 3f;
    [SerializeField]
    protected Vector3 m_ThowDirection = Vector3.zero;
    [SerializeField]
    protected Vector3 m_PrevPos = Vector3.zero;


    [SerializeField]
    protected SpriteRenderer m_ChildSpriteRender = null;

    protected bool m_ISInit = false;
    protected Transform m_Test_ChildTrans = null;
    protected void Init()
    {
        if (m_ISInit)
            return;

        m_ISInit=true;
        m_Test_ChildTrans = GetComponent<Transform>();

        m_ChildSpriteRender = GetComponentInChildren<SpriteRenderer>(true);
    }
    private void Start()
    {
        Init();
    }

    public void SetAttackDatas(Tower p_tower
        //, TowerAttackState p_attackstate
        , BaseActor p_actor )
    {
        Init();


        m_Attacker = p_tower;
        m_AttackState = m_Attacker.AttackState;
        m_TargetActorState = p_actor.GetComponent<ActorState>();
        m_TargetPos = m_TargetActorState.transform.position;
        m_ISUse = true;

        InitSetting();

        UpdateAttack();
    }
    protected void InitSetting()
    {
        if( m_AttackState.m_SpriteModel == null)
        {
            m_ChildSpriteRender.gameObject.SetActive(false);
        }
        else
        {
            m_ChildSpriteRender.gameObject.SetActive(true);
            m_ChildSpriteRender.sprite = m_AttackState.m_SpriteModel;
        }
        

        LifeSec = InGameDatas.BulletLifeSec;

        if (m_AttackState.AtkType == E_AttackType.DirectAttack )
        {
            if(m_AttackState.AtkTargetType == E_AttackTargetType.One)
            {
                transform.position = m_TargetActorState.transform.position;
            }
            else if(m_AttackState.AtkTargetType == E_AttackTargetType.Range)
            {
                transform.position = m_Attacker.transform.position;
            }
        }
        else if(m_AttackState.AtkType == E_AttackType.Throw )
        {
            m_ThowDirection = (m_TargetActorState.transform.position - m_Attacker.transform.position).normalized;
            transform.position = m_Attacker.transform.position;
        }
        else if( m_AttackState.AtkType == E_AttackType.HomingThrow
            )
        {
            transform.position = m_Attacker.transform.position;
        }

    }

    private void OnDrawGizmos()
    {
        if(m_TargetActorState == null)
        {
            return;
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, m_AttackState.AtkTargetTypeRange);

    }

    protected void SetDestroyObj()
    {
        GameObject.Destroy(this.gameObject, 2f);
        m_ISUse = false;
        m_ChildSpriteRender.gameObject.SetActive(false);
    }

    protected void UpdateMove()
    {
        LifeSec -= Time.deltaTime;

        if( LifeSec <= 0)
        {
            SetDestroyObj();
            return;
        }

        if(m_AttackState.AtkType == E_AttackType.Throw)
        {
            LayerMask mask = LayerMask.GetMask("Enemy");

            Vector3 offsetpos = m_ThowDirection * Time.deltaTime;
            Vector3 currpos = transform.position;
            m_PrevPos = currpos;
            //-offsetpos;
            transform.position = currpos + offsetpos;

            if( false )
            {
                // 레이캐스트 범위방식
                var allhitcastinfoarr = Physics2D.CircleCastAll(transform.position
                , m_AttackState.AtkTargetTypeRange
                , -offsetpos
                , offsetpos.magnitude
                , mask);
                if( allhitcastinfoarr.Length > 0 )
                {
                    SetAttack();
                }
            }
            else
            {
                // 현재 위치에서 범위안에 있는 상대 찾아서 공격
                List<ActorState> alllist = ExtendCore.GetRangeObjectAll<ActorState>(this.transform.position
                                        , m_AttackState.AtkTargetTypeRange
                                        , mask);
                if (alllist.Count > 0)
                {
                    SetAttack();
                }
            }

        }
        if(m_AttackState.AtkType == E_AttackType.HomingThrow )
        {
            if( m_TargetActorState != null 
                && !m_TargetActorState.ISDie )
            {
                m_TargetPos = m_TargetActorState.transform.position;
            }

            // 100 프로 호밍 공격
            Vector3 targetpos = m_TargetPos;// m_TargetActorState.transform.position;
            Vector3 currpos = transform.position;
            Vector3 targetvec3 = (targetpos - currpos);

            Vector3 direction = targetvec3.normalized
                * m_AttackState.MoveSpeed
                * Time.deltaTime;

            if (targetvec3.sqrMagnitude < direction.sqrMagnitude)
            {
                transform.position = targetpos;
                SetAttack();
            }
            else
            {
                transform.position = currpos + direction;
            }
        }
        
    }

    protected void SetAttack()
    {
        if (m_AttackState.AtkTargetType == E_AttackTargetType.One)
        {
            //ActorState state = m_Target.GetComponent<ActorState>();
            m_TargetActorState.SetDamage(m_AttackState.Atk);
        }
        else if (m_AttackState.AtkTargetType == E_AttackTargetType.Range)
        {
            LayerMask mask = LayerMask.GetMask("Enemy");
            List<ActorState> alllist = ExtendCore.GetRangeObjectAll<ActorState>(this.transform.position
                                        , m_AttackState.AtkTargetTypeRange
                                        , mask);

            foreach (ActorState actor in alllist)
            {
                actor.SetDamage(m_AttackState.Atk);
            }
        }

#if !NEW_BUFFDEBUFFUSE
        if (m_AttackState.DebuffType != E_BuffNDebuffType.MAX)
        {
            BuffNDebuff buff = BuffNDebuffManager.GetI.CreateBuffNDebuff_AddCompoment(m_AttackState.DebuffType
                , m_TargetActorState.gameObject );

            // 예제코드
            MoveDebuff_COM com = buff as MoveDebuff_COM;// m_TargetActorState.GetComponent<MoveDebuff_COM>();
            com.SetInit(5, 0.5f);

        }
#else
        if(m_AttackState.m_DebuffObj )
        {
            m_AttackState.m_DebuffObj.AddBuffNDebuffCompoment(m_TargetActorState.gameObject);
        }
        
#endif


        SetDestroyObj();
    }

    public void UpdateAttack()
    {
        if (!m_ISUse)
            return;

        if ( m_AttackState.AtkType == E_AttackType.DirectAttack )
        {
            SetAttack();

        }
        else if( m_AttackState.AtkType == E_AttackType.Throw
            || m_AttackState.AtkType == E_AttackType.HomingThrow )
        {
            UpdateMove();
        }
    }

    void Update()
    {
        UpdateAttack();
    }



}
