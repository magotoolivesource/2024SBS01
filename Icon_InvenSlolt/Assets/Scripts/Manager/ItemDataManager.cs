using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemDataManager : MonoBehaviour
{
    // �̱���
    // 
    private static ItemDataManager m_Instance = null;
    public static ItemDataManager GetInstance
    {
        get
        {
            if(m_Instance == null)
            {
                //m_Instance = new ItemDataManager();


                GameObject obj = new GameObject();
                m_Instance = obj.AddComponent<ItemDataManager>();
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


    public void Init()
    {
        m_ItemTableDataList.Clear();

        string prevresouceitem = "Pixel Art Icon Pack - RPG";
        // �ϵ��ڵ� ��� ������ �߰�
        ItemTableData tabledata = new ItemTableData()
        {
            ItemTypeID = E_ItemType.Apple,
            ItemName = "���",
            SpritePath = $"{prevresouceitem}/{E_ItemType.Food}/{E_ItemType.Apple}"
        };
        ItemTableData tabledata2 = new ItemTableData()
        {
            ItemTypeID = E_ItemType.Beer,
            ItemName = "����",
            SpritePath = $"{prevresouceitem}/{E_ItemType.Food}/{E_ItemType.Beer}"
        };
        ItemTableData tabledata3 = new ItemTableData()
        {
            ItemTypeID = E_ItemType.Bread,
            ItemName = "��",
            SpritePath = $"{prevresouceitem}/{E_ItemType.Food}/{E_ItemType.Bread}"
        };
        ItemTableData tabledata4 = new ItemTableData()
        {
            ItemTypeID = E_ItemType.Bag,
            ItemName = "����",
            SpritePath = $"{prevresouceitem}/{E_ItemType.Equipment}/{E_ItemType.Bag}"
        };


        //Sprite sprite = Resources.Load<Sprite>("Pixel Art Icon Pack - RPG/Food/Apple");
        //tabledata.SpriteImg = sprite;

        m_ItemTableDataList.Add(tabledata);
        m_ItemTableDataList.Add(tabledata2);
        m_ItemTableDataList.Add(tabledata3);

        foreach (var item in m_ItemTableDataList)
        {
            item.InitSetting();

            m_ItemTableDataDict.Add(item.ItemTypeID, item);
        }

    }

    [ContextMenu("[�ʱ�ȭ �ϱ�]")]
    protected void _Editor_Init()
    {
        Init();

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
