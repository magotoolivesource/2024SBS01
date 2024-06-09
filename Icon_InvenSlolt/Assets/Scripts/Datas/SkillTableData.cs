using UnityEngine;

public class SkillTableData
{
    public int ID;
    public string SkillName;
    public string SkillDescript;
    public int MaxLV;

    public string SpritePath;
    public Sprite SpriteImg;

}

public class PlayerSkillTableData : SkillTableData
{
    public int CurrentLV;

}
