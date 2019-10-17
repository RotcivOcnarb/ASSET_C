using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject player;
    public GameObject bulletPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0)){
            GameObject go = Instantiate(bulletPrefab, player.transform.position, bulletPrefab.transform.rotation);
            Vector3 worldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            go.GetComponent<Bullet>().velocity = worldSpace - player.transform.position;
            go.GetComponent<Bullet>().velocity.Normalize();
            go.GetComponent<Bullet>().velocity *= 0.3f;

        }   
    }
}
