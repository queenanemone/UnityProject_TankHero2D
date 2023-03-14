using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    [SerializeField] ParticleSystem playerParticle;
    [SerializeField] ParticleSystem enemyParticle;
    ParticleSystem particle;

    Quaternion pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = this.gameObject.transform.rotation;
        Debug.Log(pos);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player_Bullet" || other.tag == "Enemy_Bullet"){
            if (other.tag == "Player_Bullet")
            {
                particle = playerParticle;
            }
            else
            {
                particle = enemyParticle;
            }
            particle.transform.position = other.transform.position;
            particle.transform.rotation = pos;
            particle.Play();
            Debug.Log("Boom!");
            Destroy(other.gameObject);
        }
    }
}
