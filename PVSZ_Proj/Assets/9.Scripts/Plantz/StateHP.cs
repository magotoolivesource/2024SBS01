using UnityEngine;

public class StateHP : MonoBehaviour
{
    public int MAXHP;

    [SerializeField, ReadOnlyInspector]
    protected int HP;
    [field:SerializeField, ReadOnlyInspector]
    protected bool ISDie { get; set; }

    protected float m_NormalizeWeight = 0f;
    public float CurrentHPNormalize()
    {
        return HP * m_NormalizeWeight;
    }
    public void SetDamage(float p_damage)
    {
        if (ISDie)
            return;

        HP -= (int)p_damage;

        if(HP < 0)
        {
            ISDie = true;
            SetDie();
        }
    }

    public void SetDie()
    {
        // 副府令 贸府 
        Collider2D[] arr = GetComponents<Collider2D>();
        foreach (var item in arr)
        {
            item.enabled = false;
        }

    }

    protected void ResetAllDatas()
    {
        ISDie = false;
        HP = MAXHP;

        m_NormalizeWeight = 1/MAXHP;
    }

    private void Awake()
    {
        ResetAllDatas();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
