using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public interface INotes
{
    /// <summary>
    /// êNì¸Çí ím
    /// </summary>
    void EnterNotification();
    void MissNotification();
}

public class TimeLineBarMovement : MonoBehaviour
{
    [SerializeField, Header("îöî≠obj")]
    private GameObject[] bombObj;

    CancellationTokenSource source = new CancellationTokenSource();

    Collider col;

    

    private void Awake()
    {
        KeyCheck().Forget();
    }

    private void OnTriggerStay(Collider other)
    {
        col = other;

        var target = other.GetComponent<INotes>();

        if (target != null)
        {
            target.MissNotification();
        }
    }

    async UniTask KeyCheck()
    {
        CancellationToken tkn = source.Token;

        while(true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(col != null && col.GetComponent<Notes>() != null)
                {
                    var target = col.GetComponent<INotes>();

                    if (target != null && !col.GetComponent<Notes>().isFailed)
                    {
                        target.EnterNotification();
                        Instantiate(bombObj[Random.Range(0, bombObj.Length)], new Vector3(transform.position.x, transform.position.y + 3, transform.position.z + 10), Quaternion.identity);
                    }
                }
                //else
                //{
                //    NotesManager.Instance.bar.TakeDamage();
                //}
            }

            await UniTask.Delay(1, cancellationToken: tkn);
        }
    }

    private void OnDestroy()
    {
        source.Cancel();
    }

}