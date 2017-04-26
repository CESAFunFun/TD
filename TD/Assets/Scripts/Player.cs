using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    private Character _character;
    private PlayerGamePad _gamepad;

	// Use this for initialization
	void Start () {
        // キャラクタースクリプトの取得
        _character = GetComponent<Character>();
        // ゲームパッドの取得
        _gamepad = GetComponent<PlayerGamePad>();
	}
	
	// Update is called once per frame
	void Update () {

        // ゲームパッドが接続されていれば
        if (_gamepad.state != null)
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

    private void GamePadControll() {
        // 移動処理
        var moveAxis = _gamepad.state.LeftStickAxis;
        _character.Move(new Vector3(-moveAxis.y, 0F, moveAxis.x), _character.moveSpeed);

        // 回転処理
        var rotaAxis = _gamepad.state.rightStickAxis;
        _character.Rotation(Vector3.down * rotaAxis.x, _character.rotaSpeed);

        // プレハブの弾を発射
        if (_gamepad.state.RightShoulder)
        {
            _character.Shot(_character.shotPower, transform.forward, transform.forward * 2F);
        }
    }

    private void KeyboardControll() {
        // 横移動
        if (Input.GetKey(KeyCode.A))
        {
            _character.Move(Vector3.back, _character.moveSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _character.Move(Vector3.forward, _character.moveSpeed);
        }

        // 奥移動
        if (Input.GetKey(KeyCode.W))
        {
            _character.Move(Vector3.left, _character.moveSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _character.Move(Vector3.right, _character.moveSpeed);
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
            _character.Shot(_character.shotPower, transform.forward, transform.forward * 2F);
        }
    }
}
