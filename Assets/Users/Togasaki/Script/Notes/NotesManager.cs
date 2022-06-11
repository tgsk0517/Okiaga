using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class NotesManager : SingletonMonoBehaviour<NotesManager>, INotificationReceiver
{
    /// <summary>
    /// ノートスピード
    /// </summary>
    private float notesSpeed;

    [SerializeField, Header("ノートオブジェクト")]
    private GameObject notesObj;

    /// <summary>
    /// 動きはじめの距離
    /// </summary>
    public Transform startPos;

    /// <summary>
    /// 動き終わりの距離
    /// </summary>
    public Transform endPos;

    public Transform mugenEndPos;

    /// <summary>
    /// HPバースクリプト
    /// </summary>
    public HPControler bar;

    [SerializeField]
    private PlayableDirector pd;

    public float resultColorVal = 0.01f;
    [SerializeField]
    private GameObject resultObj;

    CancellationTokenSource source = new CancellationTokenSource();
    CancellationTokenSource afterResultSource = new CancellationTokenSource();


    [SerializeField]
    private GameObject objthth;

    [SerializeField]
    private Rank[] rank;

    /// <summary>
    /// ミスした回数
    /// </summary>
    public int missNum = 0;

    /// <summary>
    /// 倒した起き上がり数
    /// </summary>
    public int beatedOkiagari = 0;

    [SerializeField]
    private TextMeshProUGUI missTex;

    [SerializeField]
    private TextMeshProUGUI beatedTxt;

    private void Start()
    {
        //OkiagariGenerater.Instance.GenerateOkiagari();
        ini(source.Token).Forget();
    }

    async UniTask ini(CancellationToken tkn)
    {
        await UniTask.Delay(2000, cancellationToken: tkn);
        pd.Play();
        SoundManager.Instance.PlayBGM(BGMLabel.BGM1,false);
        await UniTask.Delay(45000, cancellationToken: tkn);
        ShowResult();
    }

    public void ShowResult()
    {
        missTex.text = missNum.ToString();
        beatedTxt.text = beatedOkiagari.ToString();
        resultObj.SetActive(true);
        foreach(Rank r in rank)
        {
            r.Appear().Forget();
        }
        AfterResult().Forget();
        Destroy(objthth);
    }

    async UniTask AfterResult()
    {
        CancellationToken tkn = afterResultSource.Token;
        bool b = true;

        await UniTask.Delay(2000,cancellationToken:tkn);
        while(b)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                b = false;
            }
            await UniTask.Delay(1, cancellationToken: tkn);
        }

        NextSceneTransition.instance.GotoNextScene();

        afterResultSource.Cancel();

    }

    public void SpawnNotes(float spd,float wid,int num ,int type)
    {
        switch (type)
        {
            case 0:
                GameObject obj = Instantiate(notesObj, startPos.position, Quaternion.identity);
                obj.GetComponent<Notes>().attackNum = num;
                obj.GetComponent<Notes>().barSpeed = spd;
                obj.transform.localScale = new Vector3(wid, obj.transform.localScale.y, obj.transform.localScale.z);
                obj.GetComponent<Notes>().BarInit();
                break;

            case 1:
                GameObject ob = Instantiate(notesObj, startPos.position, Quaternion.identity);
                ob.GetComponent<Notes>().attackNum = num;
                ob.GetComponent<Notes>().barSpeed = spd;
                ob.GetComponent<Notes>().typeNum = type;
                ob.transform.localScale = new Vector3(wid, ob.transform.localScale.y, ob.transform.localScale.z);
                ob.GetComponent<Notes>().BarInit();

                break;
            default:
                break;
        }

    }

    public void OnNotify(Playable origin, INotification notification, object context)
    {
        var target = notification as NotesMarker;
        if (target == null)
            return;

        SpawnNotes(target.speed, target.notesWidth , target.notesNum ,target.type);
    }

}
