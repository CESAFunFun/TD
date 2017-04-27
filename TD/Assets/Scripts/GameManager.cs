using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private Transform _respawnPoint;

    [SerializeField]
    private float _respawnMaxTime = 10F;

    private float _respawnCoolTime;

	// Use this for initialization
	void Start () {
        _respawnCoolTime = _respawnMaxTime;
    }

    // Update is called once per frame
    void Update () {
        _respawnCoolTime -= Time.deltaTime;
		if(_respawnCoolTime < 0F)
        {
            var respawnPool = _respawnPoint.gameObject.GetComponent<ObjectPool>();
            respawnPool.GetGameObject(_respawnPoint);
            _respawnCoolTime = _respawnMaxTime;
        }
	}
}
