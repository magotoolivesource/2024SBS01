using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillDataManager : SingletonT<SkillDataManager>
{

    protected List<PlayerSkillTableData> m_PlayerSkillTableDataList = new List<PlayerSkillTableData>();

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
