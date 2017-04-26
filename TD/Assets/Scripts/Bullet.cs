using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private float _damage = 1F;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        gameObject.SetActive(false);

        if(other.tag == "Enemy")
        {
            other.SendMessage("TakeDamage", _damage);
        }
    }
}
