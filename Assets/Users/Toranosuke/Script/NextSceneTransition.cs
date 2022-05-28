using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextSceneTransition : MonoBehaviour
{
    private static Canvas canvas;

    private static Image image;

    private static NextSceneTransition instance;

    [SerializeField]
    private bool UseFadeIn = false;

    [SerializeField]
    private bool UseFadeOut = false;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        CreateCanvasAndImage();
    }
    private void CreateCanvasAndImage()
    {
        //カメラの定義をする
        Camera targetCamera = GameObject.Find ("MainCamera").GetComponent<Camera> ();


        //スクリプトからキャンバスを生成する処理
        GameObject canvasObject = new GameObject("FadeCanvas");
        canvas = canvasObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = targetCamera;
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

    // Update is called once per frame
    void Update()
    {
        if(UseFadeIn)
        {

        }
    }
}
