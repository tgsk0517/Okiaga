using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextSceneTransition : MonoBehaviour
{
    //キャンバスを持っておく変数
    private static Canvas canvas;

    //フェード用のイメージを持っておく変数
    private static Image image;

    //他スクリプトから関数を利用するためのインスタンス
    public static NextSceneTransition instance;

    //遷移先のシーン名を持っておく文字列
    [SerializeField]
    private string nextscene = null;

    //フェードインを使用するときにオンにするbool型変数
    [SerializeField]
    private bool usefadein = true;

    //フェードイアウトを使用するときにオンにするbool型変数
    [SerializeField]
    private bool usefadeout = true;

    //関数を利用して他スクリプトからフェード遷移を実行するためのbool型public変数
    //[SerializeField]
    private bool startscenetransition = false;

    //フェードインフェードアウトの速さ(1 / fadespeed = フェードにかかる秒数)
    [SerializeField]
    private float fadespeed = 0.33f;

    // Start is called before the first frame update
    void Start()
    {
        //instanceの有効化(?)
        if (instance == null)
        {
            instance = this;
        }

        CreateCanvasAndImage();

        //フェードインを使用する場合はフェード用イメージのアルファ値を最大にする
        if(usefadein)
        {
            image.color = new Color(0f, 0f, 0f, 1f);
        }
    }

    /// <summary>
    /// 初期化処理(キャンバスとフェード用のイメージを生成)
    /// </summary>
    private void CreateCanvasAndImage()
    {
        //スクリプトからキャンバスを生成する処理
        GameObject canvasObject = new GameObject("FadeCanvas");
        canvas = canvasObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 100;
        canvasObject.AddComponent<GraphicRaycaster>();

        //スクリプトからイメージを生成する処理
        image = new GameObject("FadeImage").AddComponent<Image>();
        image.transform.SetParent(canvas.transform, false);
        image.rectTransform.anchoredPosition = Vector3.zero;
        Camera camera = Camera.main;
        image.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        image.color = Color.clear;
        image.raycastTarget = false;
    }

    /// <summary>
    /// 外部からアクセスしてUpdate内の処理を実行するための処理
    /// </summary>
    public void GotoNextScene()
    {
        startscenetransition = true;
    }
 
    // Update is called once per frame
    void Update()
    {
        if(usefadein)   //フェードインをする処理
        {
            if(image.color.a > 0f)
            {
                image.color -= new Color(0f, 0f, 0f, fadespeed * Time.deltaTime);
            }
            else
            {
                usefadein = false;
            }
        }
        else if(startscenetransition)   //フェードアウトをする処理
        {
            if (usefadeout)
            {
                if (image.color.a < 1f)
                {
                    image.color += new Color(0f, 0f, 0f, fadespeed * Time.deltaTime);
                }
                else
                {
                    usefadeout = false;
                }
            }
            else
            {
                SceneManager.LoadScene(nextscene);  //シーン遷移をする処理
            }
        }
    }        
}
