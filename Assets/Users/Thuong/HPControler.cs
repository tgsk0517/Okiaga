using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPControler : MonoBehaviour
{
    public HealthBar _healthBar;
    // Start is called before the first frame update
    void Start()
    {
        PlayerStatus.HP = PlayerStatus.maxHP;
        _healthBar.SetMaxHealth(PlayerStatus.maxHP);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown("space"))
    //    {
    //        TakeDamage();
    //    }
    //    _healthBar.SetHealth(PlayerStatus.HP);   
    //}
    public void TakeDamage()// hp減らす関数
    {
        PlayerStatus.HP -= 5;
        _healthBar.SetHealth(PlayerStatus.HP);

    }
}
