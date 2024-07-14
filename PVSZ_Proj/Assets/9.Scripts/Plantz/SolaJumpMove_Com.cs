using DG.Tweening;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class SolaJumpMove_Com : MonoBehaviour
{

    public float JumpPower = 1f;
    public float DurationSec = 1f;
    public float LifeSec = 5f;

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

        ////GameObject.Destroy(gameObject, 5f);
        DOVirtual.DelayedCall(LifeSec, () =>
        {
            GameObject.Destroy(gameObject);
        }, false);
    }

    protected async void SetSolaDoMoveSync(Vector3 p_centerpos
        , float p_circelsize
        , CancellationToken p_token)
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

        ////GameObject.Destroy(gameObject, 5f);
        DOVirtual.DelayedCall(LifeSec, () =>
        {
            GameObject.Destroy(gameObject);
        }, false);
    }

    Coroutine m_coroutine = null;
    CancellationToken m_Token;
    public void SetSunFlowerCreateMove(Vector3 p_centerpos
        , float p_circelsize)
    {

        if (true)
        {
            m_coroutine = StartCoroutine(SetSolaDoMove(p_centerpos, p_circelsize));
        }
        else
        {
            m_Token = new CancellationToken();
            SetSolaDoMoveSync(p_centerpos, p_circelsize, m_Token);
        }

        //m_Token.ThrowIfCancellationRequested();// = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
