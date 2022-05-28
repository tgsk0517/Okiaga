using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeScript : MonoBehaviour
{
    //タイマー用変数
    [SerializeField]float LimitTime;                   //タイマーの設定時間
    private bool counting;　　　　　　　　　　//タイマー稼働フラグ

    //デジタル表示
    [SerializeField]private GameObject digetalText;
    private TextMeshProUGUI digetalTextComponent;

    void Start()
    {
        digetalTextComponent = digetalText.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if(counting)
        {
            TimerCount();
        }
    }

    //タイマー機能
    void TimerCount()
    {
        //60秒から経過時間を引く
        LimitTime -= Time.deltaTime;

        DigitalDisplay();

        //タイマーの停止
        if (LimitTime <= 0)
        {
            counting = false;
        }
    }

    //タイマーのデジタル表示
    void DigitalDisplay()
    {
        digetalTextComponent.text = LimitTime.ToString("F2");
    }

    //タイマースタート
    public void PushStart()
    {
        counting = true;
    }
}
