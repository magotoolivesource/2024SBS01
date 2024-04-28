using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text m_LinkText;
    protected static int ScoreVal = 0;
    public static void AddScore()
    {
        TextMeshPro

        ScoreVal += 1;
        Debug.Log($"Á¡¼ö : {ScoreVal} ");
    }
    void Update()
    {
        m_LinkText.text = $"Score:{ScoreVal}";
    }
}
