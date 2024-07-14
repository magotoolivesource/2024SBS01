using UnityEngine;



public class InGameInfoManager : SingletonT<InGameInfoManager>
{
    [SerializeField, ReadOnlyInspector]
    protected int m_SolaVal = 0;



    private void Init()
    {
        m_SolaVal = 100;
    }

    void Awake()
    {
        Init();
    }

    public void AddSola(int p_sola)
    {
        m_SolaVal += p_sola;
    }
    public int GetSola()
    {
        return m_SolaVal;
    }
    public bool UseSola(int p_usesola)
    {
        if( p_usesola <= m_SolaVal )
        {
            m_SolaVal -= p_usesola;
            return true;
        }
        
        return false;
    }

}
