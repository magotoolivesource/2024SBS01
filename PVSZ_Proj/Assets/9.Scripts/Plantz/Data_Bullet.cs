using UnityEngine;



[System.Serializable]
public struct BulletData
{
    public float DamageVal;
    public float MoveSpeed;

    public BulletData(float p_dmg = 1
        , float p_movespeed = 1f)
    {
        DamageVal = p_dmg;
        MoveSpeed = p_movespeed;
    }
}

