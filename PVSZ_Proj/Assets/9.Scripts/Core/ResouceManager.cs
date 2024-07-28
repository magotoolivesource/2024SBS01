using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class ResouceManager : SingletonT<ResouceManager>
{


    protected Dictionary<string, Object> m_AllResourceDict = new Dictionary<string, Object>();


    public static T Load<T>(string path) where T : Component
    {
        return Instance.LoadResouce<T>(path);
    }

    public T LoadResouce<T>(string path) where T : Component
    {
        if( m_AllResourceDict.ContainsKey(path) )
        {
            return m_AllResourceDict[path] as T;
        }

        T result = Resources.Load<T>(path);
        m_AllResourceDict.Add(path, result);
        return result;
    }

    // 
    public void RemoveResoucePrefDatas(string path)
    {
        if( m_AllResourceDict.ContainsKey(path) )
        {
            Resources.UnloadAsset( m_AllResourceDict[path] as Object );
            m_AllResourceDict.Remove(path);
        }
        
    }

    public void ClearAll()
    {
        foreach (var item in m_AllResourceDict)
        {
            Resources.UnloadAsset(item.Value as Object);
        }
        
        m_AllResourceDict.Clear();
    }


}
