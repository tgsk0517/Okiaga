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
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            PlayerStatus.HP -= 10;
        }
        _healthBar.SetHealth(PlayerStatus.HP);   
    }
}
