using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;

    Quaternion pos;
    // Start is called before the first frame update
    void Start()
    {

        pos = this.gameObject.transform.rotation;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Bullet"){
            particle.transform.position = other.transform.position;
            particle.transform.rotation = pos;
            particle.Play();
            Debug.Log("asdf");
            Destroy(other.gameObject);
        }
    }
}
