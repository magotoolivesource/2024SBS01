using System.Collections.Generic;
using UnityEngine;

public class PoolManage2 : SingletonT<PoolManage2>
{

    public Transform CreatePoolObject(Transform p_create)
    {

        Transform cloneobj = GameObject.Instantiate(p_create);

        return cloneobj;
    }


    protected Dictionary<GameObject, Stack<GameObject>> m_PoolManager = 
        new Dictionary<GameObject, Stack<GameObject>>();


    //public static T LoadNPoolObject<T>(string p_resourceurl) where T : Component
    //{
    //    PoolManage2.Instance.CreatePoolObject()
    //}

    public T CreatePoolObjectT<T>(T p_create) where T : Component
    {
        T outresult = null;
        Stack<GameObject> tempstack = null;

        if( m_PoolManager.ContainsKey(p_create.gameObject) )
        {
            tempstack = m_PoolManager[p_create.gameObject];
        }
        else
        {
            tempstack = new Stack<GameObject>();
            m_PoolManager.Add(p_create.gameObject, tempstack);
        }

        if(tempstack.Count > 0)
        {
            outresult = tempstack.Pop().GetComponent<T>();
        }
        else
        {
            outresult = GameObject.Instantiate<T>(p_create);
            m_PoolManager.Add(outresult.gameObject, tempstack);
        }

        outresult.gameObject.SetActive(true);
        return outresult;
    }

    public void RemoveObject<T>(T p_object) where T : Component
    {
        if( m_PoolManager.ContainsKey(p_object.gameObject) )
        {
            Stack<GameObject> statck = m_PoolManager[p_object.gameObject];
            statck.Push(p_object.gameObject);

            p_object.gameObject.SetActive(false);
        }
        else
        {
            GameObject.Destroy(p_object.gameObject);
        }

    }



	void Awake()
	{
		
	}
    //void Start()
    //{
    //    
    //}

    //void Update()
    //{
    //    
    //}
}
