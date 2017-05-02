//================================
//         Character
//--------------------------------
//@! Takayoshi Ogawa
//@! 2017/04/28
//================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
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

    [HideInInspector]
    public float health;
    [HideInInspector]
    public float recastTime;

    [SerializeField]
    private float _maxHp = 10F;

    private Vector3 _velocity;
    private Vector3 _direction;
    private Rigidbody _rigidbody;
    private ObjectPool _bulletPool;

    // Use this for initialization
    protected virtual void Start () {
        // 体力の最大値を設定
        health = _maxHp;
        // 待ち時間の最大値を保存
        recastTime = shotCoolTime;
        // 物理演算を取得
        _rigidbody = GetComponent<Rigidbody>();
        // 弾用の貯蔵庫を取得
        _bulletPool = GetComponent<ObjectPool>();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        // 移動量と向きを初期化
        _velocity = Vector3.zero;
        _direction = Vector3.zero;
        // 発射の待ち時間を減らす
        recastTime -= Time.deltaTime;
    }

    protected virtual void FixedUpdate() {
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
        if (recastTime <= 0F)
        {
            // オブジェクトプールで貯蔵している弾から発射
            var bullet = _bulletPool.GetGameObject(transform.position + ShotPos, Quaternion.identity);

            // 非アクティブな弾があれば使用
            if (bullet)
            {
                bullet.GetComponent<Rigidbody>().velocity = direction * power;
                recastTime = shotCoolTime;
            }
        }
    }

    public void TakeDamage(int damage) {
        // ダメージ計算
        health -= damage;

        //if (health <= 0)
        //{
        //    gameObject.SetActive(false);
        //    health = _maxHp;
        //}
    }
}
