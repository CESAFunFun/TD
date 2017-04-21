using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    public float moveSpeed = 1F;
    public float rotaSpeed = 1F;
    public float shotPower = 8F;

    [SerializeField]
    private GameObject _bullet;

    private Rigidbody _rigidbody;
    private Vector3 _velocity;
    private Vector3 _direction;

	// Use this for initialization
	void Start () {
        // 物理演算の取得
        _rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        // フレーム毎に入力の初期化
        _velocity = Vector3.zero;
        _direction = Vector3.zero;

        // 横移動
        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.back, moveSpeed);
            //_velocity = Vector3.back * moveSpeed;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            Move(Vector3.forward, moveSpeed);
            _velocity = Vector3.forward * moveSpeed;
        }

        // 奥移動
        if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.left, moveSpeed);
            //_velocity = Vector3.left * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.right, moveSpeed);
            //_velocity = Vector3.right * moveSpeed;
        }

        // 回転処理
        if (Input.GetKey(KeyCode.Q))
        {
            Rotation(Vector3.down, rotaSpeed);
            //_direction = Vector3.up;
        }
        else if(Input.GetKey(KeyCode.E))
        {
            Rotation(Vector3.up, rotaSpeed);
            //_direction = Vector3.down;
        }

        // プレハブの弾を発射
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(_bullet, transform.position + transform.forward * 2F, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * shotPower;
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
}
