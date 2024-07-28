using DG.Tweening;
using System;
using UnityEngine;


// create
public partial class Zombi
{
    public int a = 10;

    protected void Create_Enter()
    {
        // ���� ������ ���� ����Ʈ�� ���� �÷��� �ǵ��� �ϱ�
        Debug.Log($"���� : {a}");

        DOVirtual.DelayedCall(2f, () => {
            SetChangeState(E_ZOMBISTATETYPE.Move);
        });
    }
    protected void Create_Exit()
    {
        // ���� �ݺ��Ǵ� ����Ʈ
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
        // ���� �̵��� ���õǾ ����
    }
    protected void Move_Update()
    {
        Vector3 temppos = transform.position;
        temppos.x += -MoveSpeed * Time.deltaTime;
        transform.position = temppos;
        if (transform.position.x <= -10)
        {
            // ����� 1�� ���ֱ�
            //SetChangeState()
        }
    }
    protected void Move_Exit()
    {

    }

}
