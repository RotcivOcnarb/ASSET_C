using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PupilaFollow : MonoBehaviour
{

    public GameObject player;

    float timer = 0;

    Color damageColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 tp = (player.transform.position - transform.position);
        tp.Normalize();
        transform.localPosition = tp * 0.1f;

        timer += Time.deltaTime;

        if(timer > 3){
            Destroy(gameObject.transform.parent.gameObject);
        }

        damageColor = new Color(
            damageColor.r + (1 - damageColor.r)/10f,
            damageColor.g + (1 - damageColor.g)/10f,
            damageColor.b + (1 - damageColor.b)/10f,
            1
        );

        transform.parent.GetComponent<SpriteRenderer>().color = damageColor;

    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Bullet"){
            Destroy(collider.gameObject);
            damageColor = Color.red;
        }
    }
}
