using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    public Camera m_LinkCam;
    void Start()
    {
        Bullet.gameObject.SetActive(false);

        HeightSize = m_LinkCam.orthographicSize;
        WidthSize = m_LinkCam.orthographicSize * m_LinkCam.aspect;
    }

    public float MoveSpeed = 1f;
    public float WidthSize = 6.6666f;
    public float HeightSize = 10f;

    void UpdateMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 temppos = this.transform.position;
        temppos.x += (x * MoveSpeed * Time.deltaTime);
        temppos.z += (z * MoveSpeed * Time.deltaTime);

        if(temppos.x > WidthSize)
            temppos.x = WidthSize;
        if (temppos.x < -WidthSize)
            temppos.x = -WidthSize;

        if( temppos.z >= HeightSize)
            temppos.z = HeightSize;
        if (temppos.z <= -HeightSize)
            temppos.z = -HeightSize;

        this.transform.position = temppos;
    }

    public Move Bullet = null;
    public Transform BulletPosTrans = null;
    void Fire()
    {
        //if( Input.GetKeyDown(KeyCode.Space) )
        if( Input.GetButtonDown("Jump") )
        {
            Move cloneobj = GameObject.Instantiate(Bullet);
            cloneobj.gameObject.SetActive(true);
            cloneobj.transform.position = BulletPosTrans.position;

        }
    }

    void Update()
    {
        UpdateMove();
        Fire();
    }
}
