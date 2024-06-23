using System;
using UnityEngine;


public abstract class BuffNDebuff_ScriptableObj : ScriptableObject
{

    public virtual E_BuffNDebuffType BuffType
    {
        get
        {
            return E_BuffNDebuffType.MAX;
        }
    }

    public abstract void AddBuffNDebuffCompoment(GameObject p_intargetobj);


    public BuffNDebuff Runtime_AddBuffNDevuffCompoment(GameObject p_intargetobj)
    {
        Type currtype = Type.GetType($"{BuffType.ToString()}_COM");
        if (currtype != null)
        {
            return p_intargetobj.AddComponent(currtype) as BuffNDebuff;
        }
        else
        {
            Debug.LogError($"Ŭ������ ���������� �� ���������� : ");
        }

        return null;
    }
}


