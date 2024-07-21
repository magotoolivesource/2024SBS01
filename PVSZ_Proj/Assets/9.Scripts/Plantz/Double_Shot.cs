using DG.Tweening;
using UnityEngine;




public abstract class Plantz_Shot : MonoBehaviour
{

    [SerializeField, ReadOnlyInspector]
    protected Transform m_RayCastTrans;
    protected abstract void CreateBullet();
    protected virtual void Init()
    {
        m_RayCastTrans = 
            transform.GetComponentInChildrenNName<Transform>("BulletPos");
    }

    protected virtual void Awake()
    {
        Init();
    }

    public LayerMask m_EnemyMask;
    public float m_RayLength = 10;
    public float DelayShotSec = 0;

    protected bool m_ISCastShot = false;
    protected float m_RemindDelayShotSec = 0;
    protected virtual void UpdateFineEnemy()
    {
        //RaycastHit? hit;
        //if (hit.collider == null)
        //{
            
        //}

        // 현재 줄에 있는 적 있는지 파악 하기
        RaycastHit2D hit2d = Physics2D.Raycast(m_RayCastTrans.position
            , Vector2.right
            , m_RayLength
            , m_EnemyMask);

        if( hit2d )
        {
            m_ISCastShot = true;
        }
        else
        {
            m_ISCastShot = false;
        }
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
        UpdateFineEnemy();
        UpdateShot();
    }
}

public class Double_Shot : Plantz_Shot
{
    [SerializeField]
    protected BulletData m_BulletData;
    protected override void CreateBullet()
    {
        Bullet_Pea pea = Resources.Load<Bullet_Pea>("Prefabs/Plantz/ShotPea");
        Bullet_Pea clonepea = GameObject.Instantiate(pea);
        clonepea.SetDatas(m_BulletData);
        clonepea.transform.position = m_RayCastTrans.position;

    }



}
