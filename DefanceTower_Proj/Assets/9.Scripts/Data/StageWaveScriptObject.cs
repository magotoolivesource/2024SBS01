using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "스테이지웨이브스크립트"
    , menuName = "Scriptable Objects/웨이브데이터")]
public class StageWaveScriptObject : ScriptableObject
{
    [System.Serializable]
    public struct WaveElement
    {
        public BaseActor m_Actor;
        public E_NaigationType m_NaviType;
        public float m_RemineSec;// = 0f;
    }

    public string m_StageInfo;
    public List<WaveElement> m_WaveList = new List<WaveElement>();

}
