//================================
//         Wave Queue
//--------------------------------
//@! Takayoshi Ogawa
//@! 2017/04/28
//================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class WaveQueue : MonoBehaviour {

    public bool popQueue = false;
    public int queueLength = 1;

    [HideInInspector]
    public bool ended = false;

    private ObjectPool _objectPool;
    private Queue<GameObject> _queueList;

	// Use this for initialization
	void Start () {
        // オブジェクトプールの取得
        _objectPool = GetComponent<ObjectPool>();
        // キューを作成しプールからオブジェクトを設定
        _queueList = new Queue<GameObject>();
        for (var i = 0; i < queueLength; i++)
        {
            var obj = _objectPool.GetGameObject(transform);
            _queueList.Enqueue(obj);
        }

        // 後でアクティブを変更しないと
        // プールから個別で取得できない
        foreach(var obj in _queueList)
        {
            obj.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        // 排出の許可
        if (popQueue)
        {
            // キューに残っているか
            if (_queueList.Count > 0)
            {
                // キューから排出
                var obj = _queueList.Dequeue();
                obj.SetActive(true);
            }
            else
            {
                // 終了判定を変更
                ended = true;
            }
            popQueue = false;
        }
	}
}
