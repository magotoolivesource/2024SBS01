using UnityEditor.Purchasing;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(menuName = "스킬/addskill", order = 10)]
public class SkillTableData : ScriptableObject
{
    private static int SkillCurrentID = 0;

    public int ID;
    public string SkillName;
    public string SkillDescript;
    public int MaxLV;

    public string SpritePath;
    public Sprite SpriteImg;


    public int ParentSkillID = -1;
    public int ParentSkillLV;


    [ContextMenu("[id 시작 초기화]")]
    protected void _Editor_IDReset()
    {
        SkillTableData.SkillCurrentID = 0;
    }
    [ContextMenu("[스킬 id지정하기]")]
    protected void _Editor_AllID()
    {
        //ID = 3;
        ID = SkillTableData.SkillCurrentID++;
    }
}



