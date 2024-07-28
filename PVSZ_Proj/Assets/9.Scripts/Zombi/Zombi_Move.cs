using DG.Tweening;
using System;
using UnityEngine;


// create
public partial class Zombi
{
    public int a = 10;

    protected void Create_Enter()
    {
        // 좀비 생성에 대한 이팩트및 사운드 플레이 되도록 하기
        Debug.Log($"생성 : {a}");

        DOVirtual.DelayedCall(2f, () => {
            SetChangeState(E_ZOMBISTATETYPE.Move);
        });
    }
    protected void Create_Exit()
    {
        // 무한 반복되는 이팩트
    }
    protected void Create_Update()
    {

    }

}


// move
public partial class Zombi
{

    protected void Move_Enter()
    {
        // 좀이 이동에 관련되어서 세팅
    }
    protected void Move_Update()
    {
        Vector3 temppos = transform.position;
        temppos.x += -MoveSpeed * Time.deltaTime;
        transform.position = temppos;
        if (transform.position.x <= -10)
        {
            // 목숨값 1개 없애기
            //SetChangeState()
        }
    }
    protected void Move_Exit()
    {

    }

}
