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
    private GameObject target;

    //緑バー
    private Image greenBar;

    //現在HP
    private float currentHp;

    // Use this for initialization
    void Start ()
    {
        target = transform.parent.parent.gameObject;
        greenBar = transform.GetChild(1).GetComponent<Image>();
    	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //HPバーをターゲットの下に配置する
        Vector3 wantedPos = Camera.main.WorldToScreenPoint(target.transform.position);
        transform.position = new Vector3(wantedPos.x, wantedPos.y - 20, wantedPos.z);

        currentHp = target.GetComponent<Base>().hp/100;
        //バーの表示
        greenBar.fillAmount = currentHp;


		
	}
}
