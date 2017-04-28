using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : Character {

    public bool branch;

    [SerializeField]
    private Transform[] _movePoint;

    private int _pointNum = 0;

    private enum MoveState
    {
        UP,
        DOWN,
        LEFT,
        RIGTH,
        STOP
    }

    private MoveState _moveState = MoveState.RIGTH;


    // Use this for initialization
    void Start() {

        // キャラクターの初期化
        base.Start();

        //分岐点
        branch = true;

        var enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in enemys)
        {
            //自身とのあたり判定を切る
            Physics.IgnoreCollision(obj.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
	// Update is called once per frame
	void Update() {

        // キャラクターの更新処理
        base.Update();

        //ポイントを選択する
        ChengePoint();

        if (_pointNum < _movePoint.Length)
            //方向を決める
            _moveState = ChengeMoveState(_movePoint[_pointNum].position);
        else
            _moveState = MoveState.STOP;

        Vector3 dir = Vector3.zero;

        switch(_moveState)
        {
            case MoveState.UP:
                dir = Vector3.forward;
                break;

            case MoveState.DOWN:
                dir = Vector3.back;
                break;

            case MoveState.LEFT:
                dir = Vector3.left;
                break;

            case MoveState.RIGTH:
                dir = Vector3.right;
                break;

            default:
                if(branch)
                {
                    // キャラクターの発射処理
                    Shot(shotPower, Vector3.back, Vector3.back);
                }
                else
                {
                    // キャラクターの発射処理
                    Shot(shotPower, Vector3.forward, Vector3.forward);
                }
                break;
        }

        // キャラクターの移動処理
        Move(dir, moveSpeed);

        //向き方向を決める
        transform.LookAt(transform.position + dir);

    }

    private void FixedUpdate() {
        // キャラクターの位置回転計算
        base.FixedUpdate();
    }

    //ステートを変更する
    //
    //引数　移動先
    //
    //戻り値　ステート
    MoveState ChengeMoveState(Vector3 pos)
    {
        Vector3 direction;
        //差を計算
        direction = transform.position - pos;

        //XかZの大きい方をとる
        if (Mathf.Abs(direction.x) <= Mathf.Abs(direction.z))
        {
            //正か負かを確認
            if (direction.z < 0) 
                return MoveState.UP;
            else
                return MoveState.DOWN;
        }
        else
        {
            if (direction.x > 0)
                return MoveState.LEFT;
            else
                return MoveState.RIGTH;
        }
    }

    //ポイントを変更する
    //
    //引数　なし
    //
    //戻り値　なし
    void ChengePoint()
    {
        if (_pointNum < _movePoint.Length)
        {
            //差分計算
            Vector3 heuristic = transform.position - _movePoint[_pointNum].position;
            //一定の位置まで近づけばポイントを変更
            if (Mathf.Abs(heuristic.x) < 0.5f)
            {
                if (Mathf.Abs(heuristic.z) < 0.5f)
                {
                    _pointNum++;
                }
            }
        }
    }
}
