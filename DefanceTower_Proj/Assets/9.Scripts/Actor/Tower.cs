using UnityEditor.U2D.Aseprite;
using UnityEngine;


public enum E_AttackType
{
    DirectAttack, // 즉발
    Throw,  // 던지기
    HomingThrow, // 
}

public enum E_AttackTargetType
{
    One,  // 단일 객체
    Range,  // 범위 안에 전체 공격
}

public enum E_DamageType
{
    One,  // 
    Range, // 
    RectRange,
}

[System.Serializable]
public class TowerAttackState
{
    // 시즈탱크 데미지 타입
    // E_AttackType.DirectAttack, E_AttackTargetType.One, E_DamageType.Range

    // 마린 타입
    // E_AttackType.DirectAttack, E_AttackTargetType.One, E_DamageType.One;

    // 마린 타입
    // E_AttackType.DirectAttack, E_AttackTargetType.One, E_DamageType.Range;

    // 광전사 낮들고 있는 주변 공격
    // E_AttackType.DirectAttack, E_AttackTargetType.Range, E_DamageType.One

    // 드라군
    // E_AttackType.Throw, E_AttackTargetType.One, E_DamageType.One

    // 발키리
    // HomingThrow, One, Range

    public float Atk;
    public E_AttackType AtkType = E_AttackType.DirectAttack;
    public E_AttackTargetType AtkTargetType = E_AttackTargetType.Range;
    public float AtkTargetTypeRange = 1f;

    public E_DamageType DamageType = E_DamageType.Range;
    public float DamageRange = 1f;
}

public class Tower : MonoBehaviour
{

    public TowerAttackState AttackState;

    public BaseActor m_Targe;
    public float RangeSize = 1f;
    protected CircleCollider2D m_CircleCollider2D;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (m_Targe != null) return;

        BaseActor actor = collision.GetComponent<BaseActor>();
        if (actor == null) return;

        m_Targe = actor;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        BaseActor actor = collision.GetComponent<BaseActor>();
        if (actor == null)
            return;

        if(m_Targe == actor)
        {
            m_Targe = null;
            ReSetRangeEnemy();
        }
    }

    public LayerMask EnemyMask;
    public void ReTargetSerch()
    {
        m_Targe = null;
        ReSetRangeEnemy();
    }

    protected void ReSetRangeEnemy()
    {
        //this.gameObject.layer = LayerMask.NameToLayer("Enemy");
        //LayerMask mask = this.gameObject.layer;

        //Collider2D collider2d = Physics2D.OverlapCircle(m_CircleCollider2D.transform.position
        //    , m_CircleCollider2D.radius
        //    , EnemyMask );

        //if (collider2d == null)
        //{
        //    return;
        //}

        //BaseActor actor = collider2d.GetComponent<BaseActor>();
        //m_Targe = actor;

        if( false )
        {
            m_Targe = ExtendCore.GetRangeFarObject<BaseActor>(m_CircleCollider2D.transform.position
            , m_CircleCollider2D.radius
            , EnemyMask);
        }
        else
        {
            m_Targe = ExtendCore.GetRangeObject<BaseActor>(m_CircleCollider2D.transform.position
            , m_CircleCollider2D.radius
            , EnemyMask);
        }
        

    }



    private void OnDrawGizmos()
    {
        if (m_Targe == null)
            return;

        Vector3 directionpos = m_Targe.transform.position - transform.position;
        ExtendCore.DrawArrowGizmo(transform.position, directionpos.normalized
            , directionpos.magnitude
            , 0.2f
            , Color.green);
    }






    public float DelayFireSec = 1f;
    protected float m_RemineFireSec = 0f;
    public Attack_Com Prefab_AttackCom = null;

    protected void UpdateFire()
    {
        m_RemineFireSec -= Time.deltaTime;
        if(m_RemineFireSec <= 0)
        {
            m_RemineFireSec = DelayFireSec;
            Fire();
        }
    }
    public void Fire()
    {
        if (m_Targe == null)
            return;


        Attack_Com attackcom = GameObject.Instantiate<Attack_Com>(Prefab_AttackCom);
        attackcom.SetAttackDatas(this, m_Targe);


        //Vector3 targetpos = m_Targe.transform.position;

        //ActorState actorstate = m_Targe.GetComponent<ActorState>();
        //actorstate.SetDamage(AttackState.Atk);


        //if ( AttackState.AtkType == E_AttackType.DirectAttack )
        //{
        //    if(AttackState.AtkTargetType == E_AttackTargetType.One)
        //        actorstate.SetDamage(AttackState.Atk);
        //    else if(AttackState.AtkTargetType == E_AttackTargetType.Range)
        //    {

        //    }
        //}
        //else if(AttackState.AtkType == E_AttackType.Throw)
        //{

        //}

    }

    [ContextMenu("[범위변경]")]
    void _Editor_RangeChange()
    {
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        collider.radius = RangeSize;
    }
    void SetRangeChnage()
    {
        m_CircleCollider2D = GetComponent<CircleCollider2D>();
        m_CircleCollider2D.radius = RangeSize;
    }
    private void Awake()
    {
        SetRangeChnage();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        UpdateFire();

    }
}
