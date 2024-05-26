using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_SkillType
{
    Active,
    Passive,
}

public enum E_BuffType
{
    Atk     = 0x0001,
    Def     = 0x0002,
    Mag     = 0x0004,

    Speed   = 0x0010,
}

public struct BuffWeightData
{
    public E_BuffType BuffType;
    public float WeightVal;
}

public class CompareSkillNode
{
    public SkillNode CompareNode = null;
    public int SkillLV = 0;
}
public abstract class ISkillNode
{
    public string SkillName = "";
    public string SkillDescript = "";
    public bool ISActive = false;
    public SkillNode ParentSkillNode = null;
    public CompareSkillNode[] CompareNode = null;

    public abstract void Execute();
}

public class BuffAtkSkill : ISkillNode
{
    public List<BuffWeightData> BuffWeightDataList = null;
    public float AliveSec = -1f;

    public override void Execute()
    {
        throw new System.NotImplementedException();
    }
}


public class SkillNode : ISkillNode
{
    public string SkillName = "";
    public string SkillDescript = "";
    public bool ISRoot = false;
    public bool ISActive = false;
    public SkillNode ParentSkillNode = null;
    public CompareSkillNode[] CompareNode = null;


    public override void Execute()
    {

    }



    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
