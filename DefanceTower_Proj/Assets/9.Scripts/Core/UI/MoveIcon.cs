using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
[RequireComponent( typeof(Image) )]
public abstract class MoveIcon<T_DATA> : MonoBehaviour // where T : struct
{
    [Header("[È®ÀÎ¿ë]")]
    [SerializeField]
    protected Image m_LinkImg;

    protected T_DATA m_LinkData;
    public T_DATA LinkData
    {
        get
        {
            return m_LinkData; 
        }
    }
    public void BeginDrag( T_DATA p_icondata )
    {
        //T val = default(T); 
        gameObject.SetActive(true);
        m_LinkData = p_icondata;

        _On_BeginDrag();
    }

    public virtual void _On_BeginDrag()
    {

    }

    public void EndDrag()
    {
        gameObject.SetActive(false);
    }

    void InitSettings()
    {
        m_LinkImg = GetComponent<Image>();
        m_LinkImg.raycastTarget = false;
    }

    private void Awake()
    {
        gameObject.SetActive(false);
        InitSettings();
    }

    //void Start()
    //{
        
    //}

    //void Update()
    //{
        
    //}



}
