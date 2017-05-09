﻿//================================
//         Connect Point
//--------------------------------
//@! Takayoshi Ogawa
//@! 2017/05/02
//================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// !@ 空のオブジェクトにアタッチしたうえで
// !@ Inspector上にPlayerを設定してください
public class ConnectPoint : MonoBehaviour {

    [SerializeField]
    private Player _player1;
    [SerializeField]
    private Player _player2;

    private bool _isConnect = false;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        // Player側で衝突判定が発生した際に
        // こちらで両プレイヤーを子供に設定
        if (!_player1.isMove && !_player2.isMove)
        {
            if (!_isConnect)
            {
                // 位置と親子の設定を行う
                transform.position = _player1.transform.position - (_player1.transform.position - _player2.transform.position);
                _player1.transform.SetParent(transform);
                _player2.transform.SetParent(transform);
            }
            // 接続された一度っきりの処理
            _isConnect = true;
        }

        // 接続中
        if (_isConnect)
        {
            // 回転処理
            if (_player1.gamepad.state.LeftShoulder || _player2.gamepad.state.LeftShoulder)
            {
                transform.Rotate(Vector3.down * 3F);
            }
            if (_player1.gamepad.state.RightShoulder || _player2.gamepad.state.RightShoulder)
            {
                transform.Rotate(Vector3.up * 3F);
            }

            // 発射処理
            if(_player1.gamepad.state.X || _player2.gamepad.state.X)
            {
                Debug.Log("Shot");
            }

            // 両プレイヤーの左右回転ボタンが全て入力されていたら接続解除
            if ((_player1.gamepad.state.LeftShoulder && _player1.gamepad.state.RightShoulder))
//                && (_player2.gamepad.state.LeftShoulder && _player2.gamepad.state.RightShoulder))
            {
                if (_isConnect)
                {
                    // 接続を切って個別で移動可能に
                    _player1.isMove = true;
                    _player2.isMove = true;

                    // 親から取り除く
                    _player1.transform.SetParent(null);
                    _player2.transform.SetParent(null);
                }

                // 解除された一度っきりの処理
                _isConnect = false;
            }
        }
    }
}
