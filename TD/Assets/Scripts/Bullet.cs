using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private float _damage = 1F;

    private void OnTriggerEnter(Collider other) {
        gameObject.SetActive(false);

        if(other.tag == "Player" || other.tag == "Enemy")
        {
            other.SendMessage("TakeDamage", _damage);
        }
    }
}
