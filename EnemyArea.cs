using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArea : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemyBulletPrefab;
    [SerializeField] GameObject enemyShotPos;
    [SerializeField] float bulletSpeed = 1f;
    [SerializeField] GameObject player;
    Vector3 playerPos;
    bool isAttacking = false;
    Vector3 dir;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player"){
            playerPos = other.transform.position;
            StartCoroutine("BeforeAttack");
        }
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player_Bullet"){
            Debug.Log("You win!!");
        }
    }

    IEnumerator BeforeAttack(){
        if(isAttacking == false){
            Debug.Log("Detected...");
            isAttacking = true;
            yield return new WaitForSeconds(1f);
            StartCoroutine("Attack");
        }
    }
    IEnumerator Attack(){
        Debug.Log("Shoot!!");
        GameObject enemyBullet = Instantiate(enemyBulletPrefab);
        enemyBullet.transform.position = enemyShotPos.transform.position;
        dir = player.transform.position - enemyBullet.transform.position;
        enemyBullet.gameObject.GetComponent<Rigidbody2D>().AddForce(dir * bulletSpeed, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        Debug.Log("Charging...");
        isAttacking = false;
    }
}
