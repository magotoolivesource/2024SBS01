using UnityEngine;

public class Plantz_Pea : MonoBehaviour
{
    [SerializeField, ReadOnlyInspector]
    protected SpriteRenderer m_LinkModel;


    bool m_ISInit = false;
    public void InitSetting()
    {
        if (m_ISInit)
            return;
        m_ISInit = true;

        m_LinkModel = transform.GetComponentInChildrenNName<SpriteRenderer>("Model");

    }

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
