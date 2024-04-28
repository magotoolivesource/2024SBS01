using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    void MyCollsion()
    {
        // 총알 지우기
        // 운석 지우기

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log( $"충돌 : {this.name}, {collision.gameObject.name}" );
    //    GameObject.Destroy(this.gameObject);
    //}

    public GameObject BoomParticle = null;
    void CreateBoomParticle()
    {
        if (BoomParticle == null)
            return;

        GameObject cloneparticl = GameObject.Instantiate(BoomParticle);
        cloneparticl.transform.position = this.transform.position;

        GameObject.Destroy(cloneparticl, 5f);
    }

    //public ScoreManager m_ScoreManager = null;
    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag != "Asteroid")
            return;

        //ScoreManager manage = m_ScoreManager;
        ScoreManager.AddScore();

        //Debug.Log($"트리거 : {this.name}, {other.gameObject.name}");
        // 자신 총알 지우기
        GameObject.Destroy( this.gameObject );

        // 운석 지우기
        GameObject.Destroy(other.gameObject);


        CreateBoomParticle();

    }




    void Start()
    {
        
    }

    public float MoveSpeed = 1f;
    void Update()
    {
        Vector3 temppos = this.transform.position;
        temppos.z += MoveSpeed * Time.deltaTime;
        this.transform.position = temppos;

        // 앞으로 진행때문에 삭제코드
        if( temppos.z > 15f)
        {
            GameObject.Destroy( this.gameObject );
        }

        // 뒤로 진행 운석
        if( temppos.z < -15f)
        {
            GameObject.Destroy(this.gameObject);
        }

    }
}
