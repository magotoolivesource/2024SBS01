using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;


public class ItemDataManager : MonoBehaviour
{
    // 싱글톤
    // 
    private static ItemDataManager m_Instance = null;
    public static ItemDataManager GetInstance
    {
        get
        {
            if(m_Instance == null)
            {
                GameObject obj = new GameObject();
                m_Instance = obj.AddComponent<ItemDataManager>();
                m_Instance.name = "Singltton_ItemDataMaanger1";
                m_Instance.Init();
            }

            return m_Instance;
        }
    }



    private void Awake()
    {
        //Init();
        MoveIcon = GameObject.FindObjectOfType<MoveIcon>(true);
    }

    public MoveIcon MoveIcon = null;


    [SerializeField]
    protected List<ItemTableData> m_ItemTableDataList = new List<ItemTableData>();

    protected Dictionary< E_ItemType, ItemTableData> m_ItemTableDataDict = 
        new Dictionary<E_ItemType, ItemTableData>();



    public string GetItemType2ResoucePath(E_ItemType type)
    {
        //{ E_ItemType.Food}/{ E_ItemType.Apple}
        //E_ItemType.Apple // 1001
        //E_ItemType.Belt // 2002

        E_ItemType GroupItemType = (E_ItemType)((int)((int)type / 1000) * 1000);
        return $"Pixel Art Icon Pack - RPG/{GroupItemType}/{type}";
    }

    public void Init()
    {
        m_ItemTableDataList.Clear();

        string prevresouceitem = "Pixel Art Icon Pack - RPG";
        // 하드코딩 방식 아이템 추가
        ItemTableData tabledata = new ItemTableData()
        {
            ItemTypeID = E_ItemType.Apple,
            ItemName = "사과",
            SpritePath = $"{prevresouceitem}/{E_ItemType.Food}/{E_ItemType.Apple}",
            ItemCategory = E_ItemCategory.UseItem,
            
        };
        ItemTableData tabledata2 = new ItemTableData()
        {
            ItemTypeID = E_ItemType.Beer,
            ItemName = "맥주",
            SpritePath = $"{prevresouceitem}/{E_ItemType.Food}/{E_ItemType.Beer}",
            ItemCategory = E_ItemCategory.UseItem,
            ItemEquipType = 0,
        };
        ItemTableData tabledata3 = new ItemTableData()
        {
            ItemTypeID = E_ItemType.Bread,
            ItemName = "빵",
            SpritePath = $"{prevresouceitem}/{E_ItemType.Food}/{E_ItemType.Bread}",
            ItemCategory = E_ItemCategory.UseItem,
        };

        ItemTableData tabledata4 = new ItemTableData()
        {
            ItemTypeID = E_ItemType.Bag,
            ItemName = "가방",
            SpritePath = $"{prevresouceitem}/{E_ItemType.Equipment}/{E_ItemType.Bag}",
            ItemCategory = E_ItemCategory.UseItem,
        };


        //Sprite sprite = Resources.Load<Sprite>("Pixel Art Icon Pack - RPG/Food/Apple");
        //tabledata.SpriteImg = sprite;

        m_ItemTableDataList.Add(tabledata);
        m_ItemTableDataList.Add(tabledata2);
        m_ItemTableDataList.Add(tabledata3);
        m_ItemTableDataList.Add(tabledata4);


        // 
        foreach (var item in Enum.GetValues(typeof(E_ItemType)))
        {
            E_ItemType itemtype = (E_ItemType)item;
            int id = (int)itemtype;
            if ( itemtype >= E_ItemType.Belt
                && (id % 1000) != 0 
                && itemtype < E_ItemType.Max )
            {
                ItemTableData temptabledata = new ItemTableData()
                {
                    ItemTypeID = itemtype,
                    ItemName = itemtype.ToString(),
                    SpritePath = this.GetItemType2ResoucePath(itemtype),
                    ItemCategory = E_ItemCategory.UseItem,
                    ItemEquipType = 0,
                };

                m_ItemTableDataList.Add(temptabledata);
            }
        }

        foreach (var item in m_ItemTableDataList)
        {
            item.InitSetting();

            m_ItemTableDataDict.Add(item.ItemTypeID, item);
        }


        //// 세팅 부분
        //m_ItemTableDataDict[E_ItemType.Helm].ItemCategory = E_ItemCategory.Equip;
        //m_ItemTableDataDict[E_ItemType.Helm].ItemEquipType = E_EquipType.Helm;

        // 타입들 강제 세팅
        ItemTableData data = null;
        // Equip 타입들
        GetItemDataDict(E_ItemType.Belt)?.SetItemCategory(E_ItemCategory.Equip);// ItemCategory = E_ItemCategory.Equip;
        GetItemDataDict(E_ItemType.Belt)?.SetEquip(E_EquipType.Belt);

        data = GetItemDataDict(E_ItemType.Helm);
        data?.SetItemCategory(E_ItemCategory.Equip);
        data?.SetEquip(E_EquipType.Helm);

        data = GetItemDataDict(E_ItemType.Iron_Armor);
        data?.SetItemCategory(E_ItemCategory.Equip);
        data?.SetEquip(E_EquipType.Armor);

        data = GetItemDataDict(E_ItemType.Iron_Boot);
        data?.SetItemCategory(E_ItemCategory.Equip);
        data?.SetEquip(E_EquipType.Boot);

        // 무기형
        data = GetItemDataDict(E_ItemType.Arrow);
        data?.SetItemCategory(E_ItemCategory.Weapon);
        data?.SetItemWeaponType(E_WeaponType.Arrow);

        data = GetItemDataDict(E_ItemType.Axe);
        data?.SetItemCategory(E_ItemCategory.Weapon);
        data?.SetItemWeaponType(E_WeaponType.Axe);

        data = GetItemDataDict(E_ItemType.Bow);
        data?.SetItemCategory(E_ItemCategory.Weapon);
        data?.SetItemWeaponType(E_WeaponType.Bow);

        data = GetItemDataDict(E_ItemType.Golden_Sword);
        data?.SetItemCategory(E_ItemCategory.Weapon);
        data?.SetItemWeaponType(E_WeaponType.Sword);

        data = GetItemDataDict(E_ItemType.Hammer);
        data?.SetItemCategory(E_ItemCategory.Weapon);
        data?.SetItemWeaponType(E_WeaponType.Hammer);

        data = GetItemDataDict(E_ItemType.Iron_Shield);
        data?.SetItemCategory(E_ItemCategory.Weapon);
        data?.SetItemWeaponType(E_WeaponType.Shield);

    }

    [ContextMenu("[초기화 하기]")]
    protected void _Editor_Init()
    {
        Init();

    }

    public ItemTableData GetItemDataDict(E_ItemType p_itemtype)
    {
        if( m_ItemTableDataDict.ContainsKey(p_itemtype) )
        {
            return m_ItemTableDataDict[p_itemtype];
        }

        return null;
    }
    public ItemTableData GetItemData(E_ItemType p_itemtype)
    {
        foreach (var item in m_ItemTableDataList)
        {
            if( item.ItemTypeID == p_itemtype)
            {
                return item;
            }
        }

        return null;
    }


    
}
