using DG.Tweening;
using System.Collections;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;



public class Attack_Double_Shot : Plantz_BaseShot
{
    [Header("[����밪]")]
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
        // ��� 1
        // 1��
        Shot();
        DOVirtual.DelayedCall(DoubleShotDelay, Shot);
    }

    protected void Shot()
    {
        Bullet_Pea pea = Resources.Load<Bullet_Pea>("Prefabs/Plantz/ShotPea");
        Bullet_Pea clonepea = GameObject.Instantiate(pea);
        clonepea.SetDatas(m_BulletData);
        clonepea.transform.position = m_RayCastTrans.position;
    }


}
