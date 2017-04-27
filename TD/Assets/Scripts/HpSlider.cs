using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpSlider : MonoBehaviour {
    

    public Slider sliderBar;

    private float _value;

    // Use this for initialization
    void Start() {
        if (GetComponent<Base>())
        {
            sliderBar.GetComponent<Slider>().maxValue = GetComponent<Base>().health;
        }
        else if (GetComponent<Enemy>())
        {
            sliderBar.GetComponent<Slider>().maxValue = GetComponent<Enemy>().GetComponent<Character>().health;
        }
    }
    // Update is called once per frame
    void Update () {

        // XXX : 強制的に型チェックして値を取得
        if (GetComponent<Base>())
        {
            _value = GetComponent<Base>().health;
        }
        else if (GetComponent<Enemy>())
        {
            _value = GetComponent<Enemy>().GetComponent<Character>().health;
        }

        //Vector3 pos = transform.position;
        //pos.x += 0.5f;
        //sliderBar.transform.position = pos;

        // 表示するスライダーの値を変更
        sliderBar.value = _value;
	}
}
