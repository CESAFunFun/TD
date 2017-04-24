using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision) {
        // XXX: 現状では敵と弾を消している
        //Destroy(collision.gameObject);
        //Destroy(this.gameObject);
    }
}
