using System.Collections;
using UnityEngine;

public class Zombi : MonoBehaviour
{

    public float MoveSpeed = 1f;
    void Update()
    {
        UpdateMove();
    }


    //protected IEnumerator Update2()
    //{
    //    while (true)
    //    {
    //        UpdateMove();
    //        yield return null;
    //    }
    //}

    //void Start()
    //{
    //    StartCoroutine( Update2() );
    //}



    protected virtual void UpdateMove()
    {
        //transform.Translate(new Vector3(-MoveSpeed, 0, 0) );

        Vector3 temppos = transform.position;
        temppos.x += -MoveSpeed * Time.deltaTime;
        transform.position = temppos;
        if( transform.position.x <= -10)
        {
            // 목숨값 1개 없애기
        }
    }

	void Awake()
	{
		//GetComponent<Rigidbody2D>().velocityX = 1;
	}



}
