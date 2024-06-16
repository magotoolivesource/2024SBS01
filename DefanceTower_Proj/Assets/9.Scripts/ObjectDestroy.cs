
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    public List<GameObject> m_ObjectList = new List<GameObject>();
    public int m_DelectIndex = 0;


    [ContextMenu("[삭제 적용]")]
    protected void DestroyObject()
    {
        GameObject.Destroy( m_ObjectList[m_DelectIndex].gameObject );
        m_ObjectList.RemoveAt(m_DelectIndex);

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
