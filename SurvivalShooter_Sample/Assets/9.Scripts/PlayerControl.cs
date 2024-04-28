using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float MoveSpeed = 1f;
    public LayerMask HitLayer;


    void UpdateFire()
    {

    }

    void UpdateMove()
    {
        // wsad 방식 이동
        float xx = Input.GetAxis("Horizontal");
        float zz = Input.GetAxis("Vertical");

        Vector3 temppos = transform.position;
        temppos.x += xx * MoveSpeed * Time.deltaTime;
        temppos.z += zz * MoveSpeed * Time.deltaTime;

        transform.position = temppos;
        //transform.Translate()

        // 애니메이터 이동처리
        if( xx != 0f || zz != 0f )
        {
            GetComponent<Animator>().SetBool("Move", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Move", false);
        }
    }


    [Header("[확인용]")]
    public Vector3 mousepos;
    public float Radian;
    void UpdateRotation()
    {
        ////Screen.width;
        //Camera cam;
        //cam.pixelWidth

        // 1920 X 1080
        //Vector3 centerpos = new Vector3(1920.0f * 0.5f
        //    , 1080f * 0.5f
        //    , 0f);

        Vector3 centerpos = m_MainCamera.WorldToScreenPoint(transform.position);
        centerpos.z = 0f;

        Vector3 mpos = Input.mousePosition;

        Vector3 offsetpos = centerpos - mpos;
        float radian = Mathf.Atan2( -offsetpos.y, offsetpos.x);
        Radian = radian * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f
            , (radian * Mathf.Rad2Deg) - 90f
            , 0f);

       mousepos = mpos;
        //Debug.Log($"{mpos}");

    }

    //public Camera m_MainCamera = null;
    public Vector3 Screen2WorldPos;


    public Vector3 HitPos;
    public Transform HitCube;

    /// <summary>
    /// //3D월드를 기준으로한 회전
    /// </summary>
    void UpdateRoation2()
    {
        Vector3 mpos = Input.mousePosition;
        Vector3 wpos = m_MainCamera.ScreenToWorldPoint(mpos);
        Screen2WorldPos = wpos;


        Ray ray = m_MainCamera.ScreenPointToRay(mpos);

        RaycastHit hitinfo;

        //Physics.Raycast(ray, 10000 )
        if ( Physics.Raycast(ray, out hitinfo, 1000f, HitLayer) )
        {
            Vector3 hitpos = hitinfo.point;
            HitPos = hitpos;
            HitCube.position = hitpos;

            transform.rotation = Quaternion.LookRotation(hitpos - transform.position
                , Vector3.up );
        }
        


    }

    Camera m_MainCamera = null;
    void Start()
    {
        m_MainCamera = Camera.main;
    }

    
    void Update()
    {
        UpdateMove();
        UpdateRotation();
        //UpdateRoation2();
        UpdateFire();

    }
}
