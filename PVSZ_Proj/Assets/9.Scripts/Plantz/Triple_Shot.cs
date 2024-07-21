using UnityEngine;

public class Triple_Shot : Plantz_BaseShot
{
    [Header("트리플 샷용")]
    [SerializeField]
    protected BulletData m_BulletData;

    [SerializeField]
    protected Vector3 m_TopPos;
    [SerializeField]
    protected Vector3 m_CenterPos;
    [SerializeField]
    protected Vector3 m_BottomPos;
    public Transform m_BottomTans;

    protected override void Init()
    {
        base.Init();
        m_CenterPos = m_RayCastTrans.position;
        m_BottomPos = m_BottomTans.position;
        m_TopPos = (m_CenterPos - m_BottomPos) + m_CenterPos;
    }

    protected override void CreateBullet()
    {
        // 
        Vector3 centerpos = m_RayCastTrans.position;
        Shot(m_TopPos); // 상단
        Shot(m_CenterPos); // 센터
        Shot(m_BottomPos); // 하단
    }


    protected void Shot(Vector2 p_initpos)
    {
        Bullet_Pea pea = Resources.Load<Bullet_Pea>("Prefabs/Plantz/ShotPea");
        Bullet_Pea clonepea = GameObject.Instantiate(pea);
        clonepea.SetDatas(m_BulletData);
        clonepea.transform.position = p_initpos;
    }


    protected override void UpdateFineEnemy()
    {
        m_ISCastShot = false;

        base.UpdateFineEnemy();

        m_ISCastShot |= ISRaycastHit(m_TopPos);
        m_ISCastShot |= ISRaycastHit(m_BottomPos);
    }
}
