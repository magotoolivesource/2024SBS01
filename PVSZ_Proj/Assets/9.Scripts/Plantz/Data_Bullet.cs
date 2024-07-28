using UnityEngine;



public enum E_BULLETTYPE
{
    Default,
    Slow,
    DotDamage,

}


[System.Serializable]
public struct BulletData
{
    public float DamageVal;
    public float MoveSpeed;

    public E_BULLETTYPE BulletType;// = E_BULLETTYPE.Default;

    public BulletData(float p_dmg = 1
        , float p_movespeed = 1f)
    {
        DamageVal = p_dmg;
        MoveSpeed = p_movespeed;
        BulletType = E_BULLETTYPE.Default;
    }
}

