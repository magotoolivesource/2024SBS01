using DG.Tweening;
using UnityEngine;

[System.Serializable]
public struct BulletData
{
    public float DamageVal;
    public float MoveSpeed;

    public BulletData(float p_dmg = 1
        , float p_movespeed = 1f)
    {
        DamageVal = p_dmg;
        MoveSpeed = p_movespeed;
    }
}

public class OneShopPea : MonoBehaviour
{
    public Transform BulletPos;
    public float DealyShotSec = 1f;

    [SerializeField]
    protected BulletData m_BulletData;


    protected void CreateBullet()
    {
        Bullet_Pea pea = Resources.Load<Bullet_Pea>("Prefabs/Plantz/ShotPea");
        Bullet_Pea clonepea = GameObject.Instantiate(pea);

        clonepea.SetDatas(m_BulletData);
        clonepea.transform.position = BulletPos.position;

    }
    void Init()
    {
        DOVirtual.DelayedCall(DealyShotSec, () => { CreateBullet(); }, false ).SetLoops(-1);

    }

    void Start()
    {
        Init();
    }


    void Update()
    {
        
    }
}
