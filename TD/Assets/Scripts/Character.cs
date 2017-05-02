using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public enum ELEMENT
    {
        NONE,
        FIRE,
        WATER,
        WIND,
        EARTH
    }

    public ELEMENT element = ELEMENT.NONE;
    public float moveSpeed = 1F;
    public float rotaSpeed = 1F;
    public float shotPower = 8F;
    public float shotCoolTime = 1F;
    public float health = 100F;

    [HideInInspector]
    public float _recastTime;
    private Vector3 _velocity;
    private Vector3 _direction;
    private Rigidbody _rigidbody;
    private ObjectPool _bulletPool;

    // Use this for initialization
    void Start () {
        // 待ち時間の最大値を保存
        _recastTime = shotCoolTime;
        // 物理演算を取得
        _rigidbody = GetComponent<Rigidbody>();
        // 弾用の貯蔵庫を取得
        _bulletPool = GetComponent<ObjectPool>();
	}
	
	// Update is called once per frame
	void Update () {
        // 移動量と向きを初期化
        _velocity = Vector3.zero;
        _direction = Vector3.zero;
        // 発射の待ち時間を減らす
        _recastTime -= Time.deltaTime;
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

    public void Shot(float power, Vector3 direction, Vector3 ShotPos) {
        if (_recastTime <= 0F)
        {
            // オブジェクトプールで貯蔵している弾から発射
            var bullet = _bulletPool.GetGameObject(transform.position + ShotPos, transform.rotation);            
            // 非アクティブな弾があれば使用
            if (bullet)
            {
                bullet.GetComponent<Rigidbody>().velocity = direction * power;
                _recastTime = shotCoolTime;
            }
        }
    }
}
