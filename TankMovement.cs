using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float steerSpeed = 1f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject shotPos;
    [SerializeField] float bulletSpeed = 5f;
    Vector3 dir;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -1 * steerAmount);
        transform.Translate(0, moveAmount, 0);
        
        Shoot();
        dir = (cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -cam.transform.position.z)) - shotPos.transform.position).normalized;
    }

    void Shoot(){
        if (Input.GetMouseButtonUp(0))
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = shotPos.transform.position;
            bullet.gameObject.GetComponent<Rigidbody2D>().AddForce(dir * bulletSpeed, ForceMode2D.Impulse);
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy_Bullet"){
            Debug.Log("Explode!!");
        }
    }
}
