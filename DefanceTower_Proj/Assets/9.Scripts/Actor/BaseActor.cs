using UnityEngine;

public class BaseActor : MonoBehaviour
{
    [SerializeField]
    protected Transform m_TargetTrans;


    [Header("Ȯ�ο�")]
    [SerializeField]
    protected Animator m_LinkAnimator;
    protected Vector2 m_DirectionVec = Vector2.zero;

    E_Direction m_Driection = E_Direction.Down;



    private void Awake()
    {
        m_LinkAnimator = GetComponentInChildren<Animator>();

        // �ӽÿ�
        SetTarget(m_TargetTrans);
    }

    void UpdateTarget()
    {
        Vector3 dirvec = m_TargetTrans.transform.position - transform.position;
        m_DirectionVec = dirvec.normalized;

        if (m_DirectionVec.x > 0.5f)
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
        // �̵�ó��
        UpdateTargetMove();


        // ���� ����
        UpdateTarget();
        m_LinkAnimator.SetFloat("MoveX", m_DirectionVec.x);
        m_LinkAnimator.SetFloat("MoveY", m_DirectionVec.y);

    }


    public float MoveSpeed = 1f;
    protected Vector3 m_MoveDirection = Vector3.zero;
    protected void UpdateTargetMove()
    {
        // ������ �ƴϸ� �׳� ��ǥ�������� �̵� ��ų���̳�
        if (false)
            SetTargetDirection();

        Vector3 temppos = transform.position;
        temppos += (m_MoveDirection * MoveSpeed * Time.deltaTime);

        transform.position = temppos;
    }

    protected void SetTargetDirection()
    {
        m_MoveDirection = m_TargetTrans.position - transform.position;
        m_MoveDirection.Normalize();
    }
    // Ÿ������
    public void SetTarget(Transform p_target)
    {
        m_TargetTrans = p_target;
        SetTargetDirection();
    }
}
