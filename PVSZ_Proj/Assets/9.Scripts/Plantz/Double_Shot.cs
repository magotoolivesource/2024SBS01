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

        // ���� �ٿ� �ִ� �� �ִ��� �ľ� �ϱ�
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


    // �ٸ� ��� �����Ѱ� �ǻ��ڵ�
    //protected virtual void DotweenDelayShot()
    //{
    //    // 0.2f UpdateFineEnemy()
    //    // m_RemindDelayShotSec ���� �ð� ���ؼ�
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
