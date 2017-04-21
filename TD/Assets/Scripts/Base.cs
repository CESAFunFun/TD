//================================
//         Base Script
//--------------------------------
//@! Irfan Fahmi Ramadhan
//@! 2017/04/21
//================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{

    private HP _hpBar;

    public float hp;

	// Use this for initialization
	void Start ()
    {
        //HP Barを取得する
        _hpBar = transform.GetChild(0).GetChild(0).GetComponent<HP>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //HPを表示
        _hpBar.currentHp = hp;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            //ダメージを受ける
            TakeDamage(10);
        }
    }

    //---------------------------
    //@! 概要　：ダメージを受ける
    //@! 引数　：ダメージ
    //---------------------------
    public void TakeDamage(float dmg)
    {
        hp -= dmg;
    }
}
