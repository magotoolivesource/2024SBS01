using UnityEngine;
using UnityEngine.UI;

public class TestSource : MonoBehaviour
{
    public LayerMask mask2;
    void Start()
    {
        gameObject.layer = mask2;

        LayerMask mask = LayerMask.GetMask("Enemy", "Tower");
        Debug.Log($"{this.gameObject.layer}, {mask.value}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
