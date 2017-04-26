using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private Transform _respawnPoint;

    private float _respawnCoolTime = 10F;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _respawnCoolTime -= Time.deltaTime;
		if(_respawnCoolTime < 0F)
        {
            var respawnPool = _respawnPoint.gameObject.GetComponent<ObjectPool>();
            respawnPool.GetGameObject(_respawnPoint);
            _respawnCoolTime = 10F;
        }
	}
}
