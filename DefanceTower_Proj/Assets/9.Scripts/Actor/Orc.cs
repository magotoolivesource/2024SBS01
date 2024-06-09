using UnityEngine;

public enum E_Direction
{
    Up,
    Down, 
    Left, 
    Right
}

public class Orc : MonoBehaviour
{
    [SerializeField]
    protected Transform m_TargetTrans;


    [Header("È®ÀÎ¿ë")]
    [SerializeField]
    protected Animator m_LinkAnimator;
    protected Vector2 m_DirectionVec = Vector2.zero;

    E_Direction m_Driection = E_Direction.Down;

    

    private void Awake()
    {
        m_LinkAnimator = GetComponentInChildren<Animator>();

    }
    
    void UpdateTarget()
    {
        Vector3 dirvec = m_TargetTrans.transform.position - transform.position;
        m_DirectionVec = dirvec.normalized;

        if(m_DirectionVec.x > 0.5f)
        {
            m_LinkAnimator.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            m_LinkAnimator.transform.localScale = Vector3.one;
        }
    }

    void Update()
    {
        UpdateTarget();


        m_LinkAnimator.SetFloat("MoveX", m_DirectionVec.x);
        m_LinkAnimator.SetFloat("MoveY", m_DirectionVec.y);

    }
}
