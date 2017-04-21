using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpSlider : MonoBehaviour {

    public Slider sliderBar;

    private float _value;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        // XXX : 強制的に型チェックして値を取得
        if (GetComponent<Base>())
        {
            _value = GetComponent<Base>().hp;
        }
        else if (GetComponent<Enemy>())
        {
            //_value = GetComponent<Enemy>().hp;
        }

        // 表示するスライダーの値を変更
        sliderBar.value = _value;
	}
}
