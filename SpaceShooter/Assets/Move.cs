using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    void MyCollsion()
    {
        // �Ѿ� �����
        // � �����

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log( $"�浹 : {this.name}, {collision.gameObject.name}" );
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

        //Debug.Log($"Ʈ���� : {this.name}, {other.gameObject.name}");
        // �ڽ� �Ѿ� �����
        GameObject.Destroy( this.gameObject );

        // � �����
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

        // ������ ���ට���� �����ڵ�
        if( temppos.z > 15f)
        {
            GameObject.Destroy( this.gameObject );
        }

        // �ڷ� ���� �
        if( temppos.z < -15f)
        {
            GameObject.Destroy(this.gameObject);
        }

    }
}
