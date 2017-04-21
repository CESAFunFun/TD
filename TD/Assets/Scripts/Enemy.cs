using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public bool _branch = true;

    [SerializeField]
    private float _speed=1.0f;

    [SerializeField]
    private Transform _branchPos;



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

        _branch = true;
}
	
	// Update is called once per frame
	void Update()
    {
        switch(_moveState)
        {
            case MoveState.UP:
                Move(new Vector3(-_speed, 0, 0));
                break;

            case MoveState.DOWN:
                Move(new Vector3(_speed, 0, 0));
                break;

            case MoveState.LEFT:
                Move(new Vector3(0, 0, _speed));
                break;

            case MoveState.RIGTH:
                Move(new Vector3(0, 0, -_speed));
                break;
            case MoveState.STOP:
                Move(Vector3.zero);
                break;
        }

        if(transform.position.z<=_branchPos.position.z)
        {
            //上方向移動
            if (_branch)
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

    //
    //移動
    //
    //引数　スピード
    //
    //戻り値　なし
    void Move(Vector3 speed)
    {
        transform.Translate(speed * Time.deltaTime);
    }
}
