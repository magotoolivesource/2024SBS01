using UnityEngine;


public class Attack_Boom : MonoBehaviour
{
    public Bounds InSizeBoomBounds;


    // BulletData 나중에 바꾸기 
    public Bounds AttackBounds;
    public BulletData m_BoomBulletData;


    protected void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"충돌 처리 : {this.name}, {collision.name} ");

    }

    [SerializeField, ReadOnlyInspector]
    protected Trigger2DCallbackFN m_ChildAttackSize = null;

    protected void InitSetting()
    {
        m_ChildAttackSize = transform.GetComponentInChildrenNName<Trigger2DCallbackFN>("AttackSize");
        m_ChildAttackSize.InitTriggerSetting(OnTriggerAttackEnter, null);
    }

    protected void OnTriggerAttackEnter(Collider2D other)
    {
        Debug.Log($"공격 처리 : {this.name}, {other.name} ");
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
