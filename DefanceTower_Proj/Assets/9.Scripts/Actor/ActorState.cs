using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;





public class ActorState : MonoBehaviour
{
    [SerializeField]
    protected bool m_ISDie = false;

    [SerializeField]
    protected int m_HP;
    protected int m_MaxHP;
    protected float m_Def;

    [SerializeField]
    protected SpriteRenderer HPBarSpriteBar;

    public bool ISDie
    {
        get { return m_ISDie; }
    }

    //public bool ISDie1 => m_ISDie;

    [ContextMenu("[공격적용]")]
    private void _Editor_SetDamage()
    {
        SetDamage(1);
    }

    public void SetDamage(float p_attack)
    {
        if (m_ISDie) return;

        float atk = p_attack - m_Def;

        if (atk <= 0)
            atk = 0;

        m_HP -= (int)atk;

        if( m_HP < 0 )
        {
            m_HP = 0;
            m_ISDie = true;

            //GameObject.Destroy(gameObject, 5f);
        }
        UpdateUI();
    }

    protected void UpdateUI()
    {
        Vector2 vec2 = HPBarSpriteBar.size;
        vec2.x = (float)m_HP / m_MaxHP;
        HPBarSpriteBar.size = vec2;
    }

    private void Awake()
    {
        m_MaxHP = m_HP;
        //HPBarSpriteBar = GetComponentInChildren<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
