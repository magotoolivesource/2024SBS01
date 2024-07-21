using DG.Tweening;
using System.Collections;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem.UI;

public class Sola : MonoBehaviour
{
    [SerializeField, ReadOnlyInspector]
    SunFlowerData m_InSunFlowerData;

    public float JumpPower = 1f;
    public float DurationSec = 1f;

    public float LifeSec = 5f;

    private void OnMouseDown()
    {
        //Debug.Log($"마우스 누름 : {this.name}");

        //GameObject.Destroy( gameObject );

        PoolManage2.Instance.RemoveObject(this);
        //점수 추가
        InGameInfoManager.Instance.AddSola( m_InSunFlowerData.AddSolaVal );
    }

    private void OnMouseUp()
    {

    }



    IEnumerator SetSolaDoMove(Vector3 p_centerpos
        , float p_circelsize)
    {
        gameObject.SetActive(true);

        //Random.Range()
        Vector3 randpos = Random.insideUnitCircle * p_circelsize;
        Vector3 targetpos = p_centerpos + randpos;

        transform.position = p_centerpos;

        yield return null;

        transform.DOJump(targetpos, JumpPower, 1, DurationSec);

        //GameObject.Destroy(gameObject, 5f);
        DOVirtual.DelayedCall(LifeSec, () =>
        {
            //GameObject.Destroy(gameObject);
            PoolManage2.Instance.RemoveObject(this);
        }, false);
    }


    protected async void SetSolaDoMoveSync(Vector3 p_centerpos
        , float p_circelsize
        , CancellationToken p_token )
    {
        gameObject.SetActive(true);

        //Random.Range()
        Vector3 randpos = Random.insideUnitCircle * p_circelsize;
        Vector3 targetpos = p_centerpos + randpos;

        transform.position = p_centerpos;


        //while (true)
        {
            await Task.Yield();

            if (p_token != null && p_token.IsCancellationRequested)
            {
                return;
            }
        }

        transform.DOJump(targetpos, JumpPower, 1, DurationSec);

        //GameObject.Destroy(gameObject, 5f);
        DOVirtual.DelayedCall(LifeSec, () =>
        {
            //GameObject.Destroy(gameObject);
            PoolManage2.Instance.RemoveObject(this);
        }, false);
    }


    public void SetFlowerData(SunFlowerData p_flowerdata)
    {
        m_InSunFlowerData = p_flowerdata;
    }


    //Coroutine m_coroutine = null;
    //CancellationToken m_Token;
    //public  void SetSunFlowerCreateMove(Vector3 p_centerpos
    //    , float p_circelsize
    //    , SunFlowerData p_flowerdata )
    //{

    //    m_InSunFlowerData = p_flowerdata;

    //    if ( true)
    //    {
    //        m_coroutine = StartCoroutine(SetSolaDoMove(p_centerpos, p_circelsize));
    //    }
    //    else
    //    {
    //        m_Token = new CancellationToken();
    //        SetSolaDoMoveSync(p_centerpos, p_circelsize, m_Token);
    //    }

    //    //m_Token.ThrowIfCancellationRequested();// = true;
    //}

    
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

        //GameObject.Destroy(gameObject);
        PoolManage2.Instance.RemoveObject(this);
    }

    void SetSolaFallDownTween()
    {
        float ypos = 6.05f;
        float randxpos = Random.Range(-8.3f, 8.3f);
        transform.position = new Vector3(randxpos, ypos, 0f);

        DOVirtual.DelayedCall(0.1f, () => {

            float randypos = Random.Range(-3.67f, 3.6f);
            float durationsec = (ypos - randypos) * InGameSolaManager.Instance.m_DownWeightVal;
            transform.DOMoveY(randypos, durationsec)
                    .OnComplete( () =>
                    {
                        DOVirtual.DelayedCall(5f, () =>
                        {
                            //GameObject.Destroy(gameObject);

                            PoolManage2.Instance.RemoveObject(this);
                        });
                    });
        });
    }
    void SetSolaFallDownSequence()
    {
        float ypos = 6.05f;
        float randxpos = Random.Range(-8.3f, 8.3f);
        transform.position = new Vector3(randxpos, ypos, 0f);

        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(0.1f);

        float randypos = Random.Range(-3.67f, 3.6f);
        float durationsec = (ypos - randypos) * InGameSolaManager.Instance.m_DownWeightVal;
        seq.Append(transform.DOLocalMoveY(randypos, durationsec));

        seq.AppendInterval(5f);
        seq.AppendCallback( () => {
            //GameObject.Destroy(gameObject); 
            PoolManage2.Instance.RemoveObject(this);
        } );
    }


    //public void SetFallDownCreateMove(SunFlowerData SoraFlowerData)
    //{
    //    m_InSunFlowerData = SoraFlowerData;

    //    if( false )
    //        StartCoroutine(SetSolaFallDownCortouine());
    //    else
    //    {
    //        //SetSolaFallDownTween();
    //        SetSolaFallDownSequence();
    //    }
            
    //}



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
