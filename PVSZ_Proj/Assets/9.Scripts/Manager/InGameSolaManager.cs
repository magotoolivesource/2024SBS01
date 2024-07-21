using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class InGameSolaManager : SingletonT<InGameSolaManager>
{

    public SunFlowerData SoraFlowerData;

    public float InitDelaySec = 5f;
    public float CreateSolaDelaySec = 3f;

    public float m_DownWeightVal = 0.4f;


    void CreateSun()
    {
        // ½ã¸¸µé±â
        Sola prefabs = Resources.Load<Sola>("Prefabs/Sola");
        //Sola cloneprefabs = GameObject.Instantiate(prefabs);
        var cloneprefabs = PoolManage2.Instance.CreatePoolObjectT(prefabs);

        cloneprefabs.SetFlowerData(SoraFlowerData);
        cloneprefabs.AddComponent<SolaFallDown_Com>();
        //cloneprefabs.SetFallDownCreateMove(SoraFlowerData);
    }

    IEnumerator CreateSolaManager()
    {
        yield return new WaitForSeconds(InitDelaySec);

        while (true)
        {
            yield return new WaitForSeconds(CreateSolaDelaySec);
            CreateSun();
            
        }
    }

    private void Awake()
    {
        StartCoroutine( CreateSolaManager() );

    }

}
