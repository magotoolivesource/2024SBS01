using UnityEngine;

public class Test_Parent : MonoBehaviour
{

    protected virtual void Awake()
    {
        Debug.Log("상위 Awake 호출");
        Init();
    }

    protected virtual void Init()
    {

    }

    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

}
