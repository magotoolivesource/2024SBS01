using DG.Tweening;
using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
#if false
using Resources = ResouceManager;
#endif

public class Attack_Double_Shot : Plantz_BaseShot
{
    [Header("[더블용값]")]
    public float DoubleShotDelay = 0.5f;
    [SerializeField]
    protected BulletData m_BulletData;
    protected override void CreateBullet()
    {
        ShotMethod01();
        //ShotMethod02();
        //ShotMethod03();
    }

    // unirx
    protected async void ShotMethod03()
    {
        Shot();
        await Task.Delay( (int)(DoubleShotDelay * 1000) );
        Shot();
    }

    protected IEnumerator DoubleShot()
    {
        Shot();
        yield return new WaitForSeconds(DoubleShotDelay);
        Shot();
    }
    protected void ShotMethod02()
    {
        StartCoroutine( DoubleShot() );
    }

    protected void ShotMethod01()
    {
        // 방법 1
        // 1발
        Shot();
        DOVirtual.DelayedCall(DoubleShotDelay, Shot);
    }

    protected void Shot()
    {
        //Bullet_Pea pea = Resources.Load<Bullet_Pea>( $"Prefabs/Plantz/ShotPea");
        Bullet_Pea pea = ResouceManager.Load<Bullet_Pea>($"Prefabs/Plantz/ShotPea");

        //Bullet_Pea clonepea = GameObject.Instantiate(pea);
        var clonepea = PoolManage2.Instance.CreatePoolObjectT(pea);

        clonepea.SetDatas(m_BulletData);
        clonepea.transform.position = m_RayCastTrans.position;
    }

    public const string ResourceShot = "Prefabs/Plantz/ShotPea";

}

