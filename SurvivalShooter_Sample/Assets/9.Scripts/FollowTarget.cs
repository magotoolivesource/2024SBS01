using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform Target = null;
    public float LerpVal = 0.1f; // 0 ~ 1f;

    protected Vector3 m_OffsetPos;
    void Start()
    {
        m_OffsetPos = Target.position - transform.position;
    }

    void Update()
    {
        //Vector3.SmoothDamp()
        //Vector3.Slerp()

        Vector3 targetpos = Target.position - m_OffsetPos;
        Vector3 lerppos = Vector3.Lerp(transform.position
                            , targetpos
                            , LerpVal * Time.deltaTime );

        transform.position = lerppos;
    }
}
