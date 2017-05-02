using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private float _damage = 1F;

    private float _lifeTime = 0;


    private void OnTriggerEnter(Collider other) {
       if (other.tag == "Player")
       {
            Destroy(gameObject.GetComponent<FixedJoint>());
            gameObject.SetActive(false);
       }

        if (other.tag == "Enemy")
        {
            transform.gameObject.AddComponent<FixedJoint>().connectedBody = other.GetComponent<Rigidbody>();
            transform.gameObject.GetComponent<FixedJoint>().breakForce = 0;
            transform.gameObject.GetComponent<FixedJoint>().breakTorque = 0;
        }

    }

    private void OnTriggerStay(Collider other)
    {
       if(other.tag == "Enemy")
        {
            transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 0.5f);
            other.GetComponent<Enemy>().moved = false;
        }
    }
    private void Update()
    {
        _lifeTime++;
        
        if (_lifeTime >= 300)
        {
            _lifeTime = 0;
            Destroy(gameObject.GetComponent<FixedJoint>());
            gameObject.SetActive(false);

        }
    }
}
