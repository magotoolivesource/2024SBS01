using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Trigger2DCallbackFN : MonoBehaviour
{

    protected Action<Collider2D> m_EnterCallBackFN = null;
    protected Action<Collider2D> m_ExitCallBackFN = null;

    //protected Event<Action<Collider2D>> m_EventEnter = null;


    public void InitTriggerSetting(Action<Collider2D> p_entercallfn
        , Action<Collider2D> p_exitcallfn)
    {
        m_EnterCallBackFN = p_entercallfn;
        m_ExitCallBackFN =(p_exitcallfn);

    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log( $"충돌 콜백용 : {this.name}, {collision.name} ");

        if (m_EnterCallBackFN != null)
            m_EnterCallBackFN(collision);
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if(m_ExitCallBackFN != null)
            m_ExitCallBackFN(collision);
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
