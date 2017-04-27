using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public bool branch;

    [SerializeField]
    private float _maxHp = 10F;

    [SerializeField]
    private Transform _branchPos;

    private Character _character;


    private enum MoveState
    {
        UP,
        DOWN,
        LEFT,
        RIGTH,
        STOP
    }

    private MoveState _moveState=MoveState.RIGTH;


    // Use this for initialization
    void Start () {
        // キャラクタースクリプトの取得
        _character = GetComponent<Character>();
        // 体力の最大値を設定
        _character.health = _maxHp;
        //分岐点
        branch = true;
    }
	
	// Update is called once per frame
	void Update()
    {
        Vector3 dir = Vector3.zero;

        switch(_moveState)
        {
            case MoveState.UP:
                dir = Vector3.left;
                break;

            case MoveState.DOWN:
                dir = Vector3.right;
                break;

            case MoveState.LEFT:
                dir = Vector3.forward;
                break;

            case MoveState.RIGTH:
                dir = Vector3.back;
                break;

            default:
                if(branch)
                {
                    // キャラクターの発射処理
                    _character.Shot(_character.shotPower, Vector3.right, Vector3.right);
                }
                else
                {
                    // キャラクターの発射処理
                    _character.Shot(_character.shotPower, Vector3.left, Vector3.right);
                }
                break;
        }

        // キャラクターの移動処理
        _character.Move(dir, _character.moveSpeed);
        transform.LookAt(transform.position + dir);

        if(transform.position.z<=_branchPos.position.z)
        {
            //上方向移動
            if (branch)
            {
                if (transform.position.x >= -2.5f)
                    _moveState = MoveState.UP;
                else if (transform.position.z <= -8.5)
                    _moveState = MoveState.STOP;
                else
                    _moveState = MoveState.RIGTH;
            }
            //下に移動
            else
            {
                if (transform.position.x <= 2.5f)
                    _moveState = MoveState.DOWN;
                else if (transform.position.z <= -8.5)
                    _moveState = MoveState.STOP;
                else
                    _moveState = MoveState.RIGTH;
            }
        }
	}

    void TakeDamage(float damage)
    {
        _character.health -= damage;
        if (_character.health <= 0)
        {
            gameObject.SetActive(false);
            _character.health = _maxHp;
        }
    }
}
