using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using Cysharp.Threading.Tasks;

public class ResultText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI txt;

    CancellationTokenSource source = new CancellationTokenSource();

    private void Start()
    {
        ColorChange().Forget();
    }

    async UniTask ColorChange()
    {
        CancellationToken tkn = source.Token;
        Color cl = new Color(0, 0, 1, 1);
        bool red = true;
        bool green = false;
        bool blue = false;

        while(true)
        {
            if(red)
            {
                cl += new Color(NotesManager.Instance.resultColorVal, 0, -NotesManager.Instance.resultColorVal, 1);
                if(cl.r > 0.99f)
                {
                    red = false;
                    green = true;
                }
            }
            else if(green)
            {
                cl += new Color(-NotesManager.Instance.resultColorVal, NotesManager.Instance.resultColorVal, 0, 1);
                if(cl.g > 0.99f)
                {
                    green = false;
                    blue = true;
                }
            }
            else if(blue)
            {
                cl += new Color(0, -NotesManager.Instance.resultColorVal, NotesManager.Instance.resultColorVal, 1);
                if (cl.b > 0.99f)
                {
                    blue = false;
                    red = true;
                }
            }
            txt.faceColor = cl;
            await UniTask.Delay(20, cancellationToken: tkn);
        }
    }

    private void OnDestroy()
    {
        source.Cancel();
    }

}
