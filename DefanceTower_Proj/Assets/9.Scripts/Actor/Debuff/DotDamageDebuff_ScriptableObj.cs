using UnityEngine;

[CreateAssetMenu(fileName = "DotDamageDubuff", menuName = "���������/�����_��Ʈ������")]
public class DotDamageDebuff_ScriptableObj : BuffNDebuff_ScriptableObj
{

    public override E_BuffNDebuffType BuffType
    {
        get
        {
            return E_BuffNDebuffType.DotDamageDebuff;
        }
    }

    public float LifeSec = 1f;
    public float DotDamageVal = 1f;

    public override void AddBuffNDebuffCompoment(GameObject p_intargetobj)
    {
        DotDamageDebuff_COM com = Runtime_AddBuffNDevuffCompoment(p_intargetobj) as DotDamageDebuff_COM;
        if(com )
        {
            com.SetInit(LifeSec, DotDamageVal);
        }
    }
}
