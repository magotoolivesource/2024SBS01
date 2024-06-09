using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillDataManager : SingletonT<SkillDataManager>
{

    [Header("[확인용]")]
    [SerializeField]
    protected List<SkillTableData> m_SkillTableDataList = new List<SkillTableData>();

    public SkillTableData GetSkillTableData_ID(int p_skillid)
    {
        foreach (var item in m_SkillTableDataList)
        {
            if( item.ID == p_skillid)
            {
                return item;
            }
        }

        return null;
    }


    [Header("[플레이어 스킬 정보]")]
    [SerializeField]
    protected List<PlayerSkillTableData> m_PlayerSkillTableDataList = new List<PlayerSkillTableData>();


    public void AddSkillID(int p_skillid)
    {
        SkillTableData skilldata = GetSkillTableData_ID(p_skillid);
        if (skilldata == null)
        {
            Debug.LogError("스킬 정보 없음 확인하기");
            return;
        }

        PlayerSkillTableData data = new PlayerSkillTableData(skilldata);
        m_PlayerSkillTableDataList.Add(data);
    }
    public void AddSkill(PlayerSkillTableData p_skilldata)
    {
        m_PlayerSkillTableDataList.Add(p_skilldata);
    }

    public PlayerSkillTableData GetSkillID( int p_skillid )
    {
        foreach (var item in m_PlayerSkillTableDataList)
        {
            if( item.ID == p_skillid )
            {
                return item;
            }
        }
        return null;
    }

    public void RemoveSkill(int p_skillid)
    {
        PlayerSkillTableData tabledata = GetSkillID(p_skillid);
        if (tabledata != null) 
        {
            m_PlayerSkillTableDataList.Remove(tabledata);
        }
    }

}
