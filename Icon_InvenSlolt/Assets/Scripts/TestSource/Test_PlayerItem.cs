using System;
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



        foreach (var item in Enum.GetValues(typeof(E_ItemType)))
        {
            int val = (int)item;
            Debug.Log($" {item} : {val}");

            PlayerItemDataManager.Instance.AddItem( (E_ItemType)item );
        }

        


    }


    [ContextMenu("È®ÀÎ¿ë")]
    void _Editor_Source()
    {
        foreach (var item in Enum.GetValues(typeof(E_ItemType)))
        {
            int val = (int)item;
            Debug.Log( $" {item} : {val}" );
        }
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
