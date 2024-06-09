using UnityEngine;

[System.Serializable]
public class PlayerSkillTableData : SkillTableData
{
    public int CurrentLV;

    public PlayerSkillTableData(SkillTableData p_data)
    {
        ID = p_data.ID;
        SkillName = p_data.SkillName;
        SkillDescript = p_data.SkillDescript;
        MaxLV = p_data.MaxLV;
        SpritePath = p_data.SpritePath;
        SpriteImg = p_data.SpriteImg;

    }


}