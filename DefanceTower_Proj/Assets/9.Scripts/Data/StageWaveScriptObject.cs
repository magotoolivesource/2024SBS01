using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "�����������̺꽺ũ��Ʈ"
    , menuName = "Scriptable Objects/���̺굥����")]
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
