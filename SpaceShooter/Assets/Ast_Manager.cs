using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using MYSourceEngine;


public class Ast_Manager : MonoBehaviour
{
    //public GameObject AsteroidObj;
    //public GameObject AsteroidObj2;
    //public GameObject AsteroidObj3;
    public GameObject[] AstroidArr;
    private void Start()
    {
        GameObject.DontDestroyOnLoad(this);

        m_CurrentSec = m_DelaySec;
        //AsteroidObj.SetActive(false);
        foreach (var item in AstroidArr)
        {
            item.SetActive(false);
        }
        CreateAsteroid();
    }

    void CreateAsteroid()
    {
        //GameObject cloneobj = null;
        //int rand = UnityEngine.Random.Range(0, 3);
        //if( rand == 0)
        //{
        //    cloneobj = GameObject.Instantiate(AsteroidObj);
        //}
        //else if( rand == 1)
        //{
        //    cloneobj = GameObject.Instantiate(AsteroidObj2);
        //}
        //else if (rand == 2)
        //{
        //    cloneobj = GameObject.Instantiate(AsteroidObj3);
        //}

        int[] myarr2 = new int[] { 4, 2, 5, 1, 3 };
        int randval = myarr2.Rand();


        GameObject obj = AstroidArr.Rand();
        GameObject cloneobj = GameObject.Instantiate(obj);

        //int rand = UnityEngine.Random.Range(0, AstroidArr.Length);
        //GameObject cloneobj = GameObject.Instantiate(AstroidArr[rand]);
        
        cloneobj.SetActive(true);
        float randx = UnityEngine.Random.Range(-6, 6);
        cloneobj.transform.position = new Vector3(randx, 0, 11);
    }

    public float m_CurrentSec = 0;
    public float m_DelaySec = 1f;
    void Update()
    {
        // 플레이가 되었을때 경과된 시간
        float sec = Time.time;

        m_CurrentSec -= Time.deltaTime;
        //m_CurrentSec = 
        // 1초에 한번
        if ( m_CurrentSec <= 0f )
        {
            m_CurrentSec = m_DelaySec;
            CreateAsteroid();
        }

        

    }
}
