//================================
//         Player
//--------------------------------
//@! Takayoshi Ogawa
//@! 2017/04/28
//================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Player : Character {

    //private Character _character;
    private PlayerGamePad _gamepad;

	// Use this for initialization
	void Start () {
        // キャラクターの初期化処理
        base.Start();

        // ゲームパッドの取得
        _gamepad = GetComponent<PlayerGamePad>();
	}
	
	// Update is called once per frame
	void Update () {

        // キャラクターの更新処理
        base.Update();

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

    private void FixedUpdate() {
        // キャラクターの位置回転計算
        base.FixedUpdate();
    }

    private void GamePadControll() {
        // 移動処理
        var moveAxis = _gamepad.state.LeftStickAxis;
<<<<<<< HEAD
        _character.Move(new Vector3(moveAxis.x, 0F, moveAxis.y), _character.moveSpeed);
=======
        Move(new Vector3(moveAxis.x, 0F, moveAxis.y), moveSpeed);
>>>>>>> b2c9bcb1d3592d646f4a7086b675fb72bb0521e6

        // 回転処理
        if (_gamepad.state.LeftShoulder)
        {
            Rotation(Vector3.down, rotaSpeed);
        }
        if (_gamepad.state.RightShoulder)
        {
            Rotation(Vector3.up, rotaSpeed);
        }

        // プレハブの弾を発射
        if (_gamepad.state.X)
        {
            Shot(shotPower, transform.forward, transform.forward * 2F);
        }
    }

    private void KeyboardControll() {
        // 横移動
        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left, moveSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right, moveSpeed);
        }

        // 奥移動
        if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.forward, moveSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.back, moveSpeed);
        }

        // 回転処理
        if (Input.GetKey(KeyCode.Q))
        {
            Rotation(Vector3.down, rotaSpeed);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            Rotation(Vector3.up, rotaSpeed);
        }

        // プレハブの弾を発射
        if (Input.GetKey(KeyCode.Space))
        {
            Shot(shotPower, transform.forward, transform.forward * 2F);
        }
    }
}
