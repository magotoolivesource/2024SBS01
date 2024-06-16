using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class Tower : MonoBehaviour
{
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






    public void Fire()
    {

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
        
    }
}
