using UnityEngine;

public class Test_SkillData : MonoBehaviour
{

    private void Awake()
    {

        //PlayerSkillTableData tabledata = new PlayerSkillTableData();
        SkillDataManager.Instance.AddSkillID(0);
        SkillDataManager.Instance.AddSkillID(1);
        SkillDataManager.Instance.AddSkillID(2);




    }
    
}
