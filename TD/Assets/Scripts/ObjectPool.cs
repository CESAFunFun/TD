//================================
//         Object Pool
//--------------------------------
//@! Takayoshi Ogawa
//@! 2017/04/28
//================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private GameObject[] _pool;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < _pool.Length; i++)
        {
            _pool[i] = Instantiate(_prefab, transform);
            _pool[i].name = _prefab.name + i;
            _pool[i].SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject GetGameObject(Transform transform) {
        return GetGameObject(transform.position, transform.rotation);
    }

    public GameObject GetGameObject(Vector3 position, Quaternion rotation)
    {
        GameObject result = null;

        for (int i = 0; i < _pool.Length; i++)
        {
            // 使用可能な弾を返す
            if (!_pool[i].activeSelf)
            {
                _pool[i].SetActive(true);
                _pool[i].transform.position = position;
                _pool[i].transform.rotation = rotation;
                result = _pool[i];
                break;
            }
        }

        // ここでは使用できない場合に到達
        return result;
    }
}
