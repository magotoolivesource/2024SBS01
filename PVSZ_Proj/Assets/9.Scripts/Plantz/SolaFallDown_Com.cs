using DG.Tweening;
using System.Collections;
using UnityEngine;

public class SolaFallDown_Com : MonoBehaviour
{


    // 속도 값을 
    IEnumerator SetSolaFallDownCortouine()
    {
        float ypos = 6.05f;
        float randxpos = Random.Range(-8.3f, 8.3f);
        transform.position = new Vector3(randxpos, ypos, 0f);

        yield return null;

        float randypos = Random.Range(-3.67f, 3.6f);
        float durationsec = (ypos - randypos) * InGameSolaManager.Instance.m_DownWeightVal;
        transform.DOMoveY(randypos, durationsec);

        yield return new WaitForSeconds(durationsec);

        yield return new WaitForSeconds(5f);

        GameObject.Destroy(gameObject);
    }

    void SetSolaFallDownSequence()
    {

        float ypos = 6.05f;
        Sequence seq = DOTween.Sequence();
        //seq.AppendInterval(0.1f);

        float randypos = Random.Range(-3.67f, 3.6f);
        float durationsec = (ypos - randypos) * InGameSolaManager.Instance.m_DownWeightVal;
        seq.Append(transform.DOLocalMoveY(randypos, durationsec));

        seq.AppendInterval(5f);
        seq.AppendCallback(() => { GameObject.Destroy(gameObject); });
    }

    private void Awake()
    {
        float ypos = 6.05f;
        float randxpos = Random.Range(-8.3f, 8.3f);
        transform.position = new Vector3(randxpos, ypos, 0f);
    }
    

    void Start()
    {
        if (false)
            StartCoroutine(SetSolaFallDownCortouine());
        else
        {
            //SetSolaFallDownTween();
            SetSolaFallDownSequence();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
