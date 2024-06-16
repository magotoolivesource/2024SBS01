using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Attack_Com : MonoBehaviour
{

    [SerializeField]
    protected bool m_ISUse = true;
    protected Tower m_Attacker;
    protected TowerAttackState m_AttackState;
    //protected BaseActor m_Target;
    protected ActorState m_TargetActorState;
    public void SetAttackDatas(Tower p_tower
        //, TowerAttackState p_attackstate
        , BaseActor p_actor )
    {
        m_Attacker = p_tower;
        m_AttackState = m_Attacker.AttackState;
        m_TargetActorState = p_actor.GetComponent<ActorState>();
        m_ISUse = true;

        InitSetting();


        UpdateAttack();
    }
    protected void InitSetting()
    {
        if(m_AttackState.AtkType == E_AttackType.DirectAttack )
        {
            transform.position = m_TargetActorState.transform.position;

        }
        else if( m_AttackState.AtkType == E_AttackType.Throw
            || m_AttackState.AtkType == E_AttackType.HomingThrow
            )
        {
            transform.position = m_Attacker.transform.position;
        }

    }

    public void UpdateAttack()
    {
        if (!m_ISUse)
            return;

        if ( m_AttackState.AtkType == E_AttackType.DirectAttack )
        {
            if(m_AttackState.AtkTargetType == E_AttackTargetType.One )
            {
                //ActorState state = m_Target.GetComponent<ActorState>();
                m_TargetActorState.SetDamage(m_AttackState.Atk);
            }
            else if(m_AttackState.AtkTargetType == E_AttackTargetType.Range)
            {
                LayerMask mask = LayerMask.GetMask("Enemy");
                List<ActorState> alllist = ExtendCore.GetRangeObjectAll<ActorState>(this.transform.position
                                            , m_AttackState.AtkTargetTypeRange
                                            , mask);

                foreach (ActorState actor in alllist)
                {
                    actor.SetDamage( m_AttackState.Atk );
                }
            }

            GameObject.Destroy(this.gameObject, 2f);
            m_ISUse = false;
        }
        else
        {

        }
    }


    void Start()
    {
        
    }

    void Update()
    {
        UpdateAttack();
    }
}
