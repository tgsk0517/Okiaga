using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    //プログレスバーを取得
    [SerializeField]private Image progressBar;
    //表示テキストを取得
    [SerializeField]private TextMeshProUGUI progressText;
    //時間を取得
    private float time;
    //残り時間を取得
    [SerializeField] private float timeLimit = 60f;

    void Start()
    {
        StartCoroutine(ProgressBarTime());
        StartCoroutine(TimeResult());
    }

    #region 残り時間を表示する
    IEnumerator TimeResult()
    {
        while(true)
        {
            time += Time.deltaTime;
            progressText.text = Mathf.Ceil(timeLimit - time) + "";
            if (progressBar.fillAmount < 0)
            {
                break;
            }
            yield return null;
        }
    }
    #endregion

    #region プログレスバーを残り秒数/timeLimit分動かす
    IEnumerator ProgressBarTime()
    {
        while(true)
        {
            progressBar.fillAmount = (timeLimit - time)/ timeLimit;
            if(progressBar.fillAmount < 0)
            {
                break;
            }
            yield return null;
        }
    }
    #endregion
}
