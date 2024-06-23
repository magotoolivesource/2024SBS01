using UnityEngine;


public abstract class BuffNDebuff : MonoBehaviour
{
    [SerializeField]
    protected BaseActor m_LinkActor = null;
    [SerializeField]
    protected float m_LifeSec = 0;
}

public class MoveDebuff_COM : BuffNDebuff
{
    [SerializeField]
    protected float m_DubuffSpeed = 0;
    [SerializeField]
    protected float m_OriginalSpeed = 0;
    
    public void SetInit(float p_lifesec, float p_DebuffSpeed )
    {
        m_DubuffSpeed = p_DebuffSpeed;
        m_LifeSec = p_lifesec;
        m_LinkActor = GetComponent<BaseActor>();

        m_OriginalSpeed = m_LinkActor.MoveSpeed;
        m_LinkActor.MoveSpeed = p_DebuffSpeed;
    }

    void Update()
    {
        m_LifeSec -= Time.deltaTime;
        if(m_LifeSec <= 0)
        {
            if( GetComponents<MoveDebuff_COM>().Length <= 1)
                m_LinkActor.MoveSpeed = m_OriginalSpeed;

            GameObject.Destroy(this);
        }
    }
}
