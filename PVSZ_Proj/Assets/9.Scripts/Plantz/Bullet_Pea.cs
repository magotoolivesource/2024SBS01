#define MOVECOLLSION

using DG.Tweening;
using UnityEngine;


public class Bullet_Pea : MonoBehaviour
{
    [SerializeField, ReadOnlyInspector]
    protected BulletData m_BulletData;

    public void SetDatas(BulletData bulletData)
    {
        m_BulletData = bulletData;

        //transform.DOMoveX(20f, 5f)
        //    .SetEase(Ease.Linear)
        //    .OnUpdate(() => UpdateCollision());

#if MOVECOLLSION
        // 规过 1
        GetComponent<Rigidbody2D>().velocityX = 1f;
#endif     
    }

#if MOVECOLLSION
    // 规过 1
    protected void OnTriggerEnter2D(Collider2D collision)
    {
#else
    protected void OnTriggerEnter2D(Collider2D collision)
    {
#endif

        StateHP hp = collision.GetComponent<StateHP>();
        hp.SetDamage( m_BulletData.DamageVal );
        //GameObject.Destroy(gameObject);

        PoolManage2.Instance.RemoveObject(this);

    }


    protected void UpdateCollision()
    {
        return;

        Collider2D col2d = Physics2D.OverlapCircle( transform.position, 1f );
        if (col2d != null)
        {

        }
    }


    protected void UpdateMove()
    {
        return;

    }


    protected void UpdateDestroy()
    {
        //GameObject.Destroy(gameObject);

        if( transform.position.x >= 20f)
            PoolManage2.Instance.RemoveObject(this);
    }


    void Start()
    {
        
    }

    void Update()
    {
        UpdateMove();
        UpdateCollision();
        UpdateDestroy();


    }
}
