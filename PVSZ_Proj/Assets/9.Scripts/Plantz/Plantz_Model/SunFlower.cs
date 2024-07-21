using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;



[System.Serializable]
public struct SunFlowerData
{
    public float CreateSunSec;// = 1f;
    public int CreateSunCount;// = 1;
    public int AddSolaVal;// = 25;

    public SunFlowerData( float p_createsunsec = 1
        , int p_createcount = 1
        , int addval = 25 )
    {
        CreateSunSec = p_createsunsec;
        CreateSunCount = p_createcount;
        AddSolaVal = addval;
    }
}

public class SunFlower : MonoBehaviour
{
    public SunFlowerData InSunFlowerData;

    protected float m_DurationSec = 0f;
    void Start()
    {
        m_DurationSec = InSunFlowerData.CreateSunSec;

        DOVirtual.DelayedCall(InSunFlowerData.CreateSunSec, CreateSun, false)
            .SetLoops(-1);
    }


    void CreateSun()
    {
        // 썬만들기
        Sola prefabs = Resources.Load<Sola>("Prefabs/Sola");
        //Sola cloneprefabs = GameObject.Instantiate(prefabs);
        var cloneprefabs = PoolManage2.Instance.CreatePoolObjectT(prefabs);

        cloneprefabs.SetFlowerData(InSunFlowerData);
        cloneprefabs.AddComponent<SolaJumpMove_Com>().SetSunFlowerCreateMove(transform.position, 2f);
        //cloneprefabs.SetSunFlowerCreateMove(transform.position, 2f, InSunFlowerData);

        
    }


    //void Update()
    //{
    //    m_DurationSec -= Time.deltaTime;
    //    if(m_DurationSec <= 0f)
    //    {

    //    }
    //}



    #region 테스트용 소스들

    [ContextMenu("[돈만들기]")]
    void _Test_CreatSun()
    {
        CreateSun();

        Debug.LogError("테스트");
    }

    #endregion
}
