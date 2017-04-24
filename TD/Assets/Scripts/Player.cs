using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    public float moveSpeed = 1F;
    public float rotaSpeed = 1F;
    public float shotPower = 8F;

    private Vector3 _velocity;
    private Vector3 _direction;
    private Rigidbody _rigidbody;
    private ObjectPool _bulletPool;
    private PlayerGamePad _gamepad;

	// Use this for initialization
	void Start () {
        // 物理演算を取得
        _rigidbody = GetComponent<Rigidbody>();
        // 弾用の貯蔵庫を取得
        _bulletPool = GetComponent<ObjectPool>();
        // ゲームパッドの取得
        _gamepad = GetComponent<PlayerGamePad>();
	}
	
	// Update is called once per frame
	void Update () {

        // 移動量と向きを初期化
        _velocity = Vector3.zero;
        _direction = Vector3.zero;

        if (_gamepad.state != null)
        {
            // 移動処理
            var moveAxis = _gamepad.state.LeftStickAxis;
            Move(new Vector3(-moveAxis.y, 0F, moveAxis.x), moveSpeed);

            // 回転処理
            var rotaAxis = _gamepad.state.rightStickAxis;
            Rotation(Vector3.down * rotaAxis.x, rotaSpeed);

            // プレハブの弾を発射
            if (_gamepad.state.RightShoulder)
            {
                Shot(shotPower);
            }
        }
        else
        {
            // 横移動
            if (Input.GetKey(KeyCode.A))
            {
                Move(Vector3.back, moveSpeed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Move(Vector3.forward, moveSpeed);
            }

            // 奥移動
            if (Input.GetKey(KeyCode.W))
            {
                Move(Vector3.left, moveSpeed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Move(Vector3.right, moveSpeed);
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shot(shotPower);
            }
        }
    }

    private void FixedUpdate() {
        // rigidbodyの移動処理
        _rigidbody.MovePosition(transform.position + _velocity * Time.deltaTime);
        // Transformの回転処理
        _rigidbody.MoveRotation(transform.rotation * Quaternion.Euler(_direction));
    }

    public void Move(Vector3 velocity, float speed) {
        _velocity = velocity * speed;
    }

    public void Rotation(Vector3 direction, float speed) {
        _direction = direction * speed;
    }

    public void Shot(float power) {
        // オブジェクトプールで貯蔵している弾から発射
        var bullet = _bulletPool.GetGameObject();

        // 非アクティブな弾があれば使用
        if (bullet)
        {
            bullet.transform.position = transform.position + transform.forward * 2F;
            bullet.transform.rotation = Quaternion.identity;
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * power;
        }
    }
}
