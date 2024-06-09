using UnityEngine;


public class SingletonT<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (!instance)
            {
                //T obj;
                //obj = GameObject.Find(typeof(T).Name);
                
                T objtype = GameObject.FindAnyObjectByType<T>();
                if (!objtype)
                {
                    string singletonname = typeof(T).Name;
                    GameObject obj = new GameObject( singletonname );
                    instance = obj.AddComponent<T>();
                }
                else
                {
                    instance = objtype;// obj.GetComponent<T>();
                }
            }
            return instance;
        }
    }

    //public void Awake()
    //{
    //    //DontDestroyOnLoad(gameObject);
    //}

}
