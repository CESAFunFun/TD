//================================
//           HP Script
//--------------------------------
//@! Irfan Fahmi Ramadhan
//@! 2017/04/21
//================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{

    //ターゲット
    private Transform target;

    //緑バー
    private Image greenBar;

    //現在HP
    public float currentHp = 100;

    // Use this for initialization
    void Start ()
    {
        currentHp /= 100;
        target = transform.parent.parent;
        greenBar = transform.GetChild(1).GetComponent<Image>();
    	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //HPバーをターゲットの下に配置する
        Vector3 wantedPos = Camera.main.WorldToScreenPoint(target.position);
        transform.position = new Vector3(wantedPos.x, wantedPos.y - 20, wantedPos.z);

        //バーの表示
        greenBar.fillAmount = currentHp;


		
	}
}
