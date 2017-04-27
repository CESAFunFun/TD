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
    public float health;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {

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
        health -= dmg;
    }
}
