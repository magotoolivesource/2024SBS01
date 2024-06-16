using UnityEngine;
using static UnityEditor.Rendering.FilterWindow;

public class WaveManager : MonoBehaviour
{

    public Transform m_CreatePos;
    public StageWaveScriptObject WaveScriptObject;

    [SerializeField]
    protected int m_WaveListIndex = 0;
    [SerializeField]
    protected StageWaveScriptObject.WaveElement m_Element;


    public TargetNavigation m_FirstTarget = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Element = WaveScriptObject.m_WaveList[m_WaveListIndex++]; 

    }

    // Update is called once per frame
    void Update()
    {
        if (m_WaveListIndex >= WaveScriptObject.m_WaveList.Count)
            return;
        
        m_Element.m_RemineSec -= Time.deltaTime;
        if(m_Element.m_RemineSec <= 0f)
        {
            BaseActor cloneactor = GameObject.Instantiate(m_Element.m_Actor);
            cloneactor.SetTarget(m_FirstTarget.transform);
            cloneactor.transform.position = m_CreatePos.position;// new Vector3();
            cloneactor.MoveID = m_Element.m_NaviType;

            m_Element = WaveScriptObject.m_WaveList[m_WaveListIndex++];
        }

    }
}
