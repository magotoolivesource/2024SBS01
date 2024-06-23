using System;
using System.Collections.Generic;
using UnityEngine;



public enum E_BuffNDebuffType
{
    // 타워만 적용
    TowerAttackSpeedUP,
    TowerAttackDamgUP,

    // 몬스터에 만 적용
    MoveDebuff,
    DotDamageDebuff,

    DotDamageDebuff2,

    MAX
}

public class BuffNDebuffManager : Du3Core.Singleton_Mono<BuffNDebuffManager>
{

    /// <summary>
    /// enum 이용한 add compoment 적용하기
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
            Debug.LogError($"클래스명 같은것으로 꼭 만들어야지됨 : ");
        }


    }




    #region   사용하지 않는 코드들

    //// 참고용 소스 사용하지 않음
    ////protected List<BuffNDebuff> m_AllBuffNDebuff = new List<BuffNDebuff>((int)E_BuffNDebuffType.MAX);

    //public void InitSettingManager()
    //{
    //    //// 하드코딩 방식
    //    //m_AllBuffNDebuff[(int)E_BuffNDebuffType.MoveDebuff] = new MoveDebuff_COM();
    //    //m_AllBuffNDebuff[(int)E_BuffNDebuffType.DotDamageDebuff] = new DotDamageDebuff_COM();


    //    ////Test_ReflectionType();

    //}



    /// <summary>
    /// 테스트 소스 문자열로 new 생성하기
    /// </summary>
    [ContextMenu("[테스트 소스]")]
    protected void Test_ReflectionType()
    {
        // 리플렉션
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
