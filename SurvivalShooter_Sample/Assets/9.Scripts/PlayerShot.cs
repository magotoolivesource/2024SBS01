using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public Transform GunEndpos;
    public LineRenderer LinkLine;
    void Start()
    {
        m_RemineSec = m_DelaySec;
    }


    [Header("[쏠때딜레이값]")]
    public float m_DelaySec = 1f;
    protected float m_RemineSec = 0f;
    

    [Header("[라인보이는값]")]
    public float m_LineDelaySec = 0.1f;
    protected float m_LineRemineSec = 0f;
    
    void Fire()
    {
        m_RemineSec -= Time.deltaTime;

        if ( Input.GetMouseButton(0) && m_RemineSec <= 0f )
        {
            m_RemineSec = m_DelaySec;

            Vector3 origin = GunEndpos.position;
            Vector3 direction = GunEndpos.forward;
            Vector3 endpos = (direction * 100) + origin;
            RaycastHit hitinfo;
            //Debug.DrawLine(origin, (direction * 100) + origin
            //        , Color.red
            //        , 1f );
            if( Physics.Raycast( origin, direction, out hitinfo ) )
            {
                Debug.Log($"{hitinfo.transform.name }");
                endpos = hitinfo.point;// hitinfo.transform.position;
            }

            LinkLine.gameObject.SetActive(true);
            LinkLine.SetPosition( 0, origin );
            LinkLine.SetPosition( 1, endpos);
            m_LineRemineSec = m_LineDelaySec;
        }

    }

    void UpdateLine()
    {
        m_LineRemineSec -= Time.deltaTime;
        if (m_LineRemineSec <= 0f)
        {
            LinkLine.gameObject.SetActive(false);
        }

    }
    void Update()
    {
        Fire();
        UpdateLine();
    }
}
