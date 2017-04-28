//================================
//         Game Manager
//--------------------------------
//@! Takayoshi Ogawa
//@! 2017/04/28
//================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private Transform _respawnPoint;

    [SerializeField]
    private float _respawnMaxTime = 10F;

    private float _respawnCoolTime;

	// Use this for initialization
	void Start () {
        // リスポーンの経過時間を初期化
        _respawnCoolTime = _respawnMaxTime;
    }

    // Update is called once per frame
    void Update () {
        // リスポーンの待機
        _respawnCoolTime -= Time.deltaTime;

        if (_respawnCoolTime < 0F)
        {
            // ウェーブから敵を排出する
            _respawnPoint.gameObject.GetComponent<WaveQueue>().popQueue = true;
            _respawnCoolTime = _respawnMaxTime;
        }
	}
}
