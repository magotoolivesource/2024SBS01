using System.Collections;
using UnityEngine;


//[ExecuteInEditMode]
public abstract class Plantz_BaseShot : MonoBehaviour
{
    [Header("[베이스]")]
    [SerializeField, ReadOnlyInspector]
    protected Transform m_RayCastTrans;


    [ContextMenu("초기화하기")]
    protected void Editor_Init()
    {
        if( Application.isPlaying )
            return;

        m_EnemyMask = LayerMask.GetMask("Enemy");
        m_RayCastTrans =
            transform.GetComponentInChildrenNName<Transform>("BulletPos");
    }


    protected abstract void CreateBullet();
    protected virtual void Init()
    {
        m_RayCastTrans =
            transform.GetComponentInChildrenNName<Transform>("BulletPos");
    }

    protected virtual void Start()
    {
        Editor_Init();
        Init();
    }

    public LayerMask m_EnemyMask; // = LayerMask.GetMask("Enemy");
    public float m_RayLength = 10;
    public float DelayShotSec = 3;

    protected bool m_ISCastShot = false;
    protected float m_RemindDelayShotSec = 0;

    protected virtual bool ISRaycastHit( Vector2 p_raypos )
    {
        RaycastHit2D hit2d = Physics2D.Raycast(p_raypos
            , Vector2.right
            , m_RayLength
            , m_EnemyMask);

        if (hit2d)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected virtual void UpdateFineEnemy()
    {
        //RaycastHit? hit;
        //if (hit.collider == null)
        //{

        //}

        //// 현재 줄에 있는 적 있는지 파악 하기
        //RaycastHit2D hit2d = Physics2D.Raycast(m_RayCastTrans.position
        //    , Vector2.right
        //    , m_RayLength
        //    , m_EnemyMask);

        //if (hit2d)
        //{
        //    m_ISCastShot = true;
        //}
        //else
        //{
        //    m_ISCastShot = false;
        //}

        m_ISCastShot = ISRaycastHit(m_RayCastTrans.position);


    }


    // 다른 방식 생각한것 의사코드
    //protected virtual void DotweenDelayShot()
    //{
    //    // 0.2f UpdateFineEnemy()
    //    // m_RemindDelayShotSec 남은 시간 비교해서
    //    // CreateBullet() -> DelayedCall -> UpdateFineEnemy -> CreateBullet()
    //    DOVirtual.DelayedCall(0.4f, () => UpdateFineEnemy());
    //}

    protected virtual void UpdateShot()
    {
        m_RemindDelayShotSec -= Time.deltaTime;
        if (m_ISCastShot
            && m_RemindDelayShotSec <= 0f)
        {
            CreateBullet();
            m_RemindDelayShotSec = DelayShotSec;
        }
    }

    protected virtual void Update()
    {
        if (!Application.isPlaying )
            return;

        UpdateFineEnemy();
        UpdateShot();
    }


    [SerializeField, ReadOnlyInspector]
    private bool m_ISEditorShow = true;
    [SerializeField, ReadOnlyInspector]
    private Color m_LineColor = Color.yellow;
    private void OnDrawGizmos()
    {
        if (!m_RayCastTrans)
            return;

        if (!m_ISEditorShow)
            return;

        Gizmos.color = m_LineColor;
        Vector3 endpos = m_RayCastTrans.position + (Vector3.right * m_RayLength);
        Gizmos.DrawLine(m_RayCastTrans.position
            , endpos);

        Gizmos.DrawWireSphere(endpos, 0.2f);
    }


}
