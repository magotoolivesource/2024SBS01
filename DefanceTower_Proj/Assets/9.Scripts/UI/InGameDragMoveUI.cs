using UnityEngine;


[System.Serializable]
public struct InGameTowerData
{
    public int TowerID;
    //public Sprite Tower3D_Sprite;
    //public Sprite TowerUI_Sprite;

    public override string ToString()
    {
        return $"InGameTowrData : {TowerID}";// base.ToString();
    }
}


[System.Serializable]
public class InGameDragMoveUI : MoveIcon<InGameTowerData>
{
    

}
