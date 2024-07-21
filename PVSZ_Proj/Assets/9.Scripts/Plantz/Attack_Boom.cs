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
        m_ChildAttackSize.InitTriggerSetting(OnTriggerAttackEnter, null);
    }

    protected void OnTriggerAttackEnter(Collider2D other)
    {
        Debug.Log($"���� ó�� : {this.name}, {other.name} ");
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
