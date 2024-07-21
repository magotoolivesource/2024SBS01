using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;
using UnityEngine.Serialization;
using UnityEngine.UI;

//[RequireComponent(typeof(Rigidbody2D))]
public class Trigger2DCallbackFN : MonoBehaviour
{

    [Serializable]
    public class TriggerEvent : UnityEvent<Collider2D>
    {
    }

    [FormerlySerializedAs("2DEnter")]
    [SerializeField]
    private TriggerEvent m_EnterCallFNEvent = new TriggerEvent();

    [FormerlySerializedAs("2DExit")]
    [SerializeField]
    private TriggerEvent m_ExitCallFNEvent = new TriggerEvent();


    //// 나중에 중복 함수들 호출하지 말아야지 될때
    //protected HashSet< Action<Collider2D> > m_EnterCallBackFN = null;
    //protected Action<Collider2D> m_ExitCallBackFN = null;

    //protected Event<Action<Collider2D>> m_EventEnter = null;


    //public void InitTriggerSetting(Action<Collider2D> p_entercallfn
    //    , Action<Collider2D> p_exitcallfn)
    //{
    //    //Func<string, int> m_FN;

    //    m_EnterCallBackFN = p_entercallfn;
    //    m_ExitCallBackFN =(p_exitcallfn);


    //    m_EnterCallFNEvent.AddListener( TestCall );

    //}

    public void InitCallEvent(UnityAction<Collider2D> p_entercallfn
    , UnityAction<Collider2D> p_exitcallfn)
    {
        m_EnterCallFNEvent.AddListener(p_entercallfn);
        m_ExitCallFNEvent.AddListener(p_exitcallfn);

    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log( $"충돌 콜백용 : {this.name}, {collision.name} ");

        //if (m_EnterCallBackFN != null)
        //    m_EnterCallBackFN(collision);


        //if (m_EnterCallFNEvent!= null
        //    && m_EnterCallFNEvent.GetPersistentEventCount() > 0)

        m_EnterCallFNEvent.Invoke(collision);
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        //if(m_ExitCallBackFN != null)
        //    m_ExitCallBackFN.Invoke(collision);


        //if (m_ExitCallFNEvent != null 
        //    && m_ExitCallFNEvent.GetPersistentEventCount() > 0 )

        m_ExitCallFNEvent.Invoke(collision);
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
