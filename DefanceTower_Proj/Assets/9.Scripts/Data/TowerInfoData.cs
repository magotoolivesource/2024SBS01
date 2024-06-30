using UnityEngine;


[CreateAssetMenu(fileName = "TowerData", menuName = "Tower/타워정보")]
public class TowerInfoData : ScriptableObject
{
    public int Unique_ID;
    public string TowerName;

    public Sprite World3DSprite;
    public Sprite UI3DSprite;


}
