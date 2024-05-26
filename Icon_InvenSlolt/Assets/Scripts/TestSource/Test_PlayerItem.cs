using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_PlayerItem : MonoBehaviour
{
    private void Awake()
    {

        PlayerItemDataManager.Instance.AddItem(E_ItemType.Apple);
        PlayerItemDataManager.Instance.AddItem(E_ItemType.Apple);
        PlayerItemDataManager.Instance.AddItem(E_ItemType.Apple);

        PlayerItemDataManager.Instance.AddItem(E_ItemType.Beer);
        PlayerItemDataManager.Instance.AddItem(E_ItemType.Beer);

        PlayerItemDataManager.Instance.AddItem(E_ItemType.Bread);

        PlayerItemDataManager.Instance.AddItem(E_ItemType.Bag);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
