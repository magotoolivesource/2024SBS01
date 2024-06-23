using UnityEngine;

public class DotDamageDebuff_COM : BuffNDebuff
{
    public float m_OneDamageVal = 1f; // 초당 데미지
    protected float m_DamageSec = 1f;

    protected ActorState m_ActoState;
    public void SetInit(float p_lifesec, float p_dotdamageval)
    {
        m_ActoState = GetComponent<ActorState>();
        m_OneDamageVal = p_dotdamageval;
        m_LifeSec = p_lifesec;
        m_DamageSec = 1f;
    }


    void Update()
    {
        m_DamageSec -= Time.deltaTime;
        if(m_DamageSec <= 0)
        {
            m_DamageSec = 1f;
            m_ActoState.SetDamage(m_OneDamageVal);
        }

        m_LifeSec -= Time.deltaTime;
        if (m_LifeSec <= 0)
        {
            GameObject.Destroy(this);
        }
    }


}
