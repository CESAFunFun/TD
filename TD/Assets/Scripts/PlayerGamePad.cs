using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class PlayerGamePad : MonoBehaviour {

    [HideInInspector]
    public GamepadState state;

    [SerializeField]
    private GamePad.Index _playerIndex;
	
	// Update is called once per frame
	void Update () {
        // ゲームパッドの状態を取得
        state = GetGamePad(_playerIndex);
	}

    private GamepadState GetGamePad(GamePad.Index index)
    {
        // AnyならNullを返し、
        // それ以外はゲームパッド状態を返す
        if(index != GamePad.Index.Any)
        {
            return GamePad.GetState(index);
        }
        return null;
    }
}
