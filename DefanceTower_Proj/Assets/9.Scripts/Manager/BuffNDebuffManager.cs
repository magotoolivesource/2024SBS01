using System;
using System.Collections.Generic;
using UnityEngine;



public enum E_BuffNDebuffType
{
    // Ÿ���� ����
    TowerAttackSpeedUP,
    TowerAttackDamgUP,

    // ���Ϳ� �� ����
    MoveDebuff,
    DotDamageDebuff,

    DotDamageDebuff2,

    MAX
}

public class BuffNDebuffManager : Du3Core.Singleton_Mono<BuffNDebuffManager>
{

    /// <summary>
    /// enum �̿��� add compoment �����ϱ�
    /// </summary>
    /// <param name="p_type"></param>
    /// <param name="p_inobj"></param>
    public void CreateBuffNDebuff_AddCompoment(E_BuffNDebuffType p_type, GameObject p_inobj)
    {

        Type currtype = Type.GetType($"{p_type.ToString()}_COM");
        if (currtype != null)
        {
            var currbuff = p_inobj.GetComponent(currtype);
            if (currbuff)
                return;

            p_inobj.AddComponent(currtype);
        }
        else
        {
            Debug.LogError($"Ŭ������ ���������� �� ���������� : ");
        }


    }




    #region   ������� �ʴ� �ڵ��

    //// ����� �ҽ� ������� ����
    ////protected List<BuffNDebuff> m_AllBuffNDebuff = new List<BuffNDebuff>((int)E_BuffNDebuffType.MAX);

    //public void InitSettingManager()
    //{
    //    //// �ϵ��ڵ� ���
    //    //m_AllBuffNDebuff[(int)E_BuffNDebuffType.MoveDebuff] = new MoveDebuff_COM();
    //    //m_AllBuffNDebuff[(int)E_BuffNDebuffType.DotDamageDebuff] = new DotDamageDebuff_COM();


    //    ////Test_ReflectionType();

    //}



    /// <summary>
    /// �׽�Ʈ �ҽ� ���ڿ��� new �����ϱ�
    /// </summary>
    [ContextMenu("[�׽�Ʈ �ҽ�]")]
    protected void Test_ReflectionType()
    {
        // ���÷���
        E_BuffNDebuffType temptype = E_BuffNDebuffType.MoveDebuff;
        Type currtype = Type.GetType(E_BuffNDebuffType.MoveDebuff.ToString() + "_COM");
        gameObject.AddComponent(currtype);




        //List<BuffNDebuff> alldebuff = new List<BuffNDebuff>() { null, null, null, null, null};
        //alldebuff[(int)E_BuffNDebuffType.MoveDebuff] = new MoveDebuff();
        //alldebuff[(int)E_BuffNDebuffType.DotDamageDebuff] = new DotDamageDebuff();


        //MoveDebuff movedebuff = new MoveDebuff();
        //MoveDebuff movedebuff2 = gameObject.AddComponent<MoveDebuff>();




        //var obj = Activator.CreateInstance(currtype);
        //MoveDebuff deff = obj as MoveDebuff;

    }



    #endregion


}
