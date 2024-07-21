using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Du3Project
{
    [System.Serializable]
    public class GameObjectPoolData
    {
        public int PrevCount = 0;
        public GameObject PoolObject = null;
    }



	public class ObjectPoolManager : SingletonT <ObjectPoolManager>
	{
        
        protected Dictionary<GameObject, Stack<GameObject>> m_PoolManager2 = new Dictionary<GameObject, Stack<GameObject>>();


        public List<GameObjectPoolData> m_PrevObjectList = new List<GameObjectPoolData>();
        private void Awake()
        {
            InitSettingPrevObject();
        }

        protected void InitSettingPrevObject()
        {
            // 강제 등록
            foreach (var item in m_PrevObjectList)
            {
                Stack<GameObject> tempstack = new Stack<GameObject>();
                m_PoolManager2.Add(item.PoolObject, tempstack);

                for (int i=0; i<item.PrevCount; ++i)
                {
                    GameObject copyobj = GameObject.Instantiate(item.PoolObject);
                    m_PoolManager2.Add(copyobj, tempstack);
                }
            }
        }

        public Transform CreateObject(Transform p_trans, Transform p_ParentTransform = null)
        {
            Transform outresult = null;
            Stack<GameObject> tempstack = null;

            if (m_PoolManager2.ContainsKey(p_trans.gameObject))
            {
                tempstack = m_PoolManager2[p_trans.gameObject];
            }
            else
            {
                tempstack = new Stack<GameObject>();
                m_PoolManager2.Add(p_trans.gameObject, tempstack);
            }


            if (tempstack.Count > 0)
            {
                outresult = tempstack.Pop().transform;
            }
            else
            {
                outresult = GameObject.Instantiate(p_trans);
                m_PoolManager2.Add(outresult.gameObject, tempstack);
            }

            if (p_ParentTransform != null)
            {
                outresult.transform.SetParent(p_ParentTransform);
            }

            outresult.gameObject.SetActive(true);
            return outresult;
        }

        
        public T CreateObject<T>(T p_CloneObject, Transform p_ParentTransform = null) where T : Component
        {
            T outresult = null;
            Stack<GameObject> tempstack = null;


            if (m_PoolManager2.ContainsKey(p_CloneObject.gameObject))
            {
                tempstack = m_PoolManager2[p_CloneObject.gameObject];
            }
            else
            {
                tempstack = new Stack<GameObject>();
                m_PoolManager2.Add(p_CloneObject.gameObject, tempstack);
            }

            if (tempstack.Count > 0)
            {
                outresult = tempstack.Pop().GetComponent<T>();
            }
            else
            {
                outresult = GameObject.Instantiate<T>(p_CloneObject);
                m_PoolManager2.Add(outresult.gameObject, tempstack);
            }

            if (p_ParentTransform != null)
            {
                outresult.transform.SetParent(p_ParentTransform);
            }

            outresult.gameObject.SetActive(true);
            return outresult;
        }


        //void RemoveObject()
        IEnumerator RemoveObjectCoroutinue(float p_removesec, Transform p_trans, Transform p_parenttrans = null)
        {
            yield return new WaitForSeconds(p_removesec);

            RemoveObject(p_trans, p_parenttrans);
        }
        public Transform CreateDelayRemoveObject(Transform p_trans
            , float p_removesec
            , Transform p_parenttrans = null
            , Transform p_removeparent = null)
        {
            Transform copyobj = null;
            if (p_removesec > 0f)
            {
                copyobj = CreateObject(p_trans, p_parenttrans);
                StartCoroutine(RemoveObjectCoroutinue(p_removesec, copyobj, p_removeparent));
            }

            return copyobj;
        }

        public void RemoveObject(Transform p_trans, Transform p_parenttrans = null)
        {
            if (p_parenttrans != null)
            {
                p_trans.SetParent(p_parenttrans);
            }

            if ( m_PoolManager2.ContainsKey(p_trans.gameObject) )
            {
                m_PoolManager2[p_trans.gameObject].Push(p_trans.gameObject);
                p_trans.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogErrorFormat("풀에 데이터가 없음 확인 해야지됨 강제로 지웠음 : {0}", p_trans.name );
                GameObject.Destroy(p_trans.gameObject);
            }
        }

        public void RemoveObject<T>(T p_object, Transform p_parenttrans = null) where T : Component
        {
            if (p_parenttrans != null)
            {
                p_object.transform.SetParent(p_parenttrans);
            }

            if (m_PoolManager2.ContainsKey(p_object.gameObject))
            {
                m_PoolManager2[p_object.gameObject].Push(p_object.gameObject);
                p_object.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogErrorFormat("풀에 데이터가 없음 확인 해야지됨 강제로 지웠음 2 : {0}", p_object.name);
                GameObject.Destroy(p_object.gameObject);
            }
        }



        //public Transform CreateObject(Transform p_trans)
        //{
        //    //Queue<GameObject> outque = null;
        //    //if(m_PoolManagerDict.TryGetValue(p_trans.gameObject, out outque) )
        //    //{
        //    //    outque.Count
        //    //    return outputobj
        //    //}

        //    GameObject copyobj = null;
        //    if ( m_PoolQueue.Count <= 0 )
        //    {
        //        copyobj = GameObject.Instantiate(p_trans.gameObject);
        //        //m_PoolQueue.Enqueue(copyobj);
        //        //m_PoolStatck.Push();
        //    }
        //    else
        //    {
        //        copyobj = m_PoolQueue.Dequeue();
        //        copyobj = m_PoolStatck.Pop();
        //    }

        //    return copyobj.transform;
        //}



        void Start()
		{
			
		}

		void Update()
		{
			
		}
	}
}