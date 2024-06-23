using UnityEngine;
using UnityEngine.Playables;

[CreateAssetMenu(fileName ="MoveDebuff", menuName = "버프디버프/디버프_이동")]
public class MoveDebuff_ScriptableObj : BuffNDebuff_ScriptableObj
{
    public E_BuffNDebuffType BuffType 
    { 
        get 
        { 
            return E_BuffNDebuffType.MoveDebuff; 
        } 
    }

    public float LifeSec = 1f;
    public float MoveVal = 1f;
    //public bool ISDupucate = true;

    public override void AddBuffNDebuffCompoment(GameObject p_intargetobj) 
    {
        MoveDebuff_COM tempcom = p_intargetobj.GetComponent<MoveDebuff_COM>();
        if (tempcom != null)
        {
            tempcom.SetInit(LifeSec, MoveVal);
            return;
        }

        MoveDebuff_COM com = p_intargetobj.AddComponent<MoveDebuff_COM>();
        com.SetInit(LifeSec, MoveVal);


    }
}
