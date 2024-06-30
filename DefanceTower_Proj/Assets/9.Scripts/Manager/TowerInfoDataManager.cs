using System.Collections.Generic;
using UnityEngine;

public class TowerInfoDataManager : SingletonT<TowerInfoDataManager>
{
    public List<TowerInfoData> m_TowerInfoData = new List<TowerInfoData> ();
    protected Dictionary<int, TowerInfoData> m_ToweInfoDataDict = new Dictionary<int, TowerInfoData>();

    public TowerInfoData GetTowerID(int p_towerid)
    {
        if (m_ToweInfoDataDict.ContainsKey(p_towerid))
            return m_ToweInfoDataDict[p_towerid];

        return null;
    }

    protected void InitSettingDatas()
    {
        foreach (var item in m_TowerInfoData)
        {
            m_ToweInfoDataDict.Add(item.Unique_ID, item);
        }
    }

    private void Awake()
    {
        InitSettingDatas();
    }


}
