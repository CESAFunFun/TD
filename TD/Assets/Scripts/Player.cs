﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    [HideInInspector]
    public bool isMove = true;
    [HideInInspector]
    public PlayerGamePad gamepad;

    private Character _character;

	// Use this for initialization
	void Start () {
        // ゲームパッドの取得
        gamepad = GetComponent<PlayerGamePad>();
        // キャラクタースクリプトの取得
        _character = GetComponent<Character>();
	}
	
	// Update is called once per frame
	void Update () {

        if (isMove)
        {
            // ゲームパッドが接続されていれば
            if (gamepad.state != null)
            {
                // ゲームパッドでの操作
                GamePadControll();
            }
            else
            {
                // キーボードでの操作
                KeyboardControll();
            }
        }
    }

    private void GamePadControll() {
        // 移動処理
        var moveAxis = gamepad.state.LeftStickAxis;
        _character.Move(new Vector3(moveAxis.x, 0F, -moveAxis.y), _character.moveSpeed);

        // 回転処理
        if (gamepad.state.LeftShoulder)
        {
            _character.Rotation(Vector3.down, _character.rotaSpeed);
        }
        if (gamepad.state.RightShoulder)
        {
            _character.Rotation(Vector3.up, _character.rotaSpeed);
        }

        // プレハブの弾を発射
        if (gamepad.state.X)
        {
            _character.Shot(_character.shotPower, transform.forward, transform.forward * 2F);
        }
    }

    private void KeyboardControll() {
        // 横移動
        if (Input.GetKey(KeyCode.A))
        {
            _character.Move(Vector3.left, _character.moveSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _character.Move(Vector3.right, _character.moveSpeed);
        }

        // 奥移動
        if (Input.GetKey(KeyCode.W))
        {
            _character.Move(Vector3.forward, _character.moveSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _character.Move(Vector3.back, _character.moveSpeed);
        }

        // 回転処理
        if (Input.GetKey(KeyCode.Q))
        {
            _character.Rotation(Vector3.down, _character.rotaSpeed);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            _character.Rotation(Vector3.up, _character.rotaSpeed);
        }

        // プレハブの弾を発射
        if (Input.GetKey(KeyCode.Space))
        {
            _character.Shot(_character.shotPower, transform.forward, transform.forward * 3F);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            // 衝突したプレイヤーと接続する
            other.gameObject.GetComponent<Player>().isMove = false;
        }
    }
}
