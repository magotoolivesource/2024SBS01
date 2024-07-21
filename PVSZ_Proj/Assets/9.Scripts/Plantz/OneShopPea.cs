using DG.Tweening;
using UnityEngine;


public class OneShopPea : Plantz_BaseShot
{
    [Header("°³º°½î±â¿ë")]
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
