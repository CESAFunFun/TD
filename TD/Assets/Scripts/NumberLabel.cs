//_____________________________________________________________________________//
//@file   NumberLabel
//@brief  プレイヤーの頭上に何Pかを表示
//@date   2017/4/25
//@author 安藤祥大
//_____________________________________________________________________________//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberLabel : MonoBehaviour {

    //頭上に表示するためにオブジェクトを指定
    public GameObject target;
    public Text Label;
    public float LabelPosy;
    private Vector3 Pos;

    // Use this for initialization
    void Start ()
    {
        target = transform.parent.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        //プレイヤーの頭上？にプレイヤー数を表示
        Pos= Camera.main.WorldToScreenPoint(target.transform.   position);
        Label.transform.position = new Vector3(Pos.x+70, Pos.y+LabelPosy, Pos.z);

    }
}
