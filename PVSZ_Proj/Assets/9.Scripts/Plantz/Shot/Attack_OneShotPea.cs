using DG.Tweening;
using UnityEngine;


public class Attack_OneShotPea : Plantz_BaseShot
{
    [Header("��������")]
    [SerializeField]
    protected BulletData m_BulletData;


    protected override void CreateBullet()
    {
        Bullet_Pea pea = Resources.Load<Bullet_Pea>("Prefabs/Plantz/ShotPea");
        //Bullet_Pea clonepea = GameObject.Instantiate(pea);
        //Transform clonepeat = PoolManage2.Instance.CreatePoolObject(pea.transform);
        Bullet_Pea clonepea = PoolManage2.Instance.CreatePoolObjectT(pea);

        clonepea.SetDatas(m_BulletData);
        clonepea.transform.position = m_RayCastTrans.position;

    }

}
