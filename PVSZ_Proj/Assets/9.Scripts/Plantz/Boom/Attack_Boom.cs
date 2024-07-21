using DG.Tweening;
using UnityEngine;


public class Attack_Boom : MonoBehaviour
{
    public Bounds InSizeBoomBounds;


    // BulletData ���߿� �ٲٱ� 
    public Bounds AttackBounds;
    public BulletData m_BoomBulletData;


    protected void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"�浹 ó�� : {this.name}, {collision.name} ");

    }

    [SerializeField, ReadOnlyInspector]
    protected Trigger2DCallbackFN m_ChildAttackSize = null;

    protected void InitSetting()
    {
        m_ChildAttackSize = transform.GetComponentInChildrenNName<Trigger2DCallbackFN>("AttackSize");
        //m_ChildAttackSize.InitTriggerSetting(OnTriggerAttackEnter, null);
        m_ChildAttackSize.InitCallEvent(OnTriggerAttackEnter, null);
    }

    protected void OnTriggerAttackEnter(Collider2D other)
    {
        Debug.Log($"���� ó�� : {this.name}, {other.name} ");


        

        // 1������ ���
        StateHP hp = other.GetComponent<StateHP>();
        if(hp == null 
            || hp.gameObject.layer != LayerMask.NameToLayer("Enemy") )
        {
            return;
        }

        SetAttackBoom(hp);
    }

    protected void SetAttackBoom(StateHP p_targetstat)
    {
        p_targetstat.SetDamage(100);

        //GameObject.Destroy(gameObject, 3);
        DOVirtual.DelayedCall(3, () =>
        {
            if (true)
            {
                //GameObject.Destroy(gameObject);
                PoolManage2.Instance.RemoveObject(this);
            }
        }
        );
    }

    [ContextMenu("Ȯ�ο�")]
    void Editor_Mask()
    {
        int tval = 1 << 1;


        int val = LayerMask.NameToLayer("Enemy"); // 7
        int val2 = LayerMask.GetMask( "Enemy", "Player"); // 128  

        Debug.Log($"{val}, {val2}");
    }

    void Awake()
	{
        InitSetting();


    }
    //void Start()
    //{
    //    
    //}

    //void Update()
    //{
    //    
    //}
}
