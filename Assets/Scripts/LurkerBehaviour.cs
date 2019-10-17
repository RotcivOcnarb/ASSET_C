using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LurkerBehaviour : MonoBehaviour
{

    bool bulletOver;
    float noise = 0;

    public GameObject olhoPrefab;
    public GameObject player;

    float timer = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bulletOver){
            noise += (40 - noise)/10f;
        }
        else{
            noise += (0 - noise)/10f;
        }

        GetComponent<SpriteRenderer>().material.SetFloat("_Threshold", noise);

        timer -= Time.deltaTime;

        if(timer < 0){
            timer = Random.Range(1.5f, 3.5f);
            Vector2 pos = Random.insideUnitCircle;
            GameObject go = Instantiate(olhoPrefab, transform.position, olhoPrefab.transform.rotation);
            go.GetComponentInChildren<PupilaFollow>().player = player;
            go.transform.SetParent(transform, false);

            go.transform.localPosition = pos.normalized * 3;
        }
        
    }

    void OnTriggerEnter2D(Collider2D collider){

        Debug.Log(collider.tag);
        if(collider.tag == "Bullet"){
            bulletOver = true;
        }

    }

    void OnTriggerExit2D(Collider2D collider){
        Debug.Log(collider.tag);

        if(collider.tag == "Bullet"){
            bulletOver = false;
        }

    }
}
