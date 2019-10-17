using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class BaloonFollow : MonoBehaviour
{

    public GameObject big, sub1, sub2, sub3;
    public GameObject refbig, ref1, ref2, ref3; 

    float alpha = 1;
    public bool over = true;
    public UnityEvent action;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        big.transform.position = big.transform.position + 
            (refbig.transform.position - big.transform.position)/10f;

        sub1.transform.position = sub1.transform.position + 
            (ref1.transform.position - sub1.transform.position)/7f;

        sub2.transform.position = sub2.transform.position + 
            (ref2.transform.position - sub2.transform.position)/5f;

        sub3.transform.position = sub3.transform.position + 
            (ref3.transform.position - sub3.transform.position)/2f;


        if(over)
            alpha += (1 - alpha)/5f;
        else
            alpha += (0 - alpha)/5f;

        big.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
        sub1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
        sub2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
        sub3.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);

        if(Input.GetKeyDown(KeyCode.E) && over && !GlobalVars.inputBlocked){
            action.Invoke();
        }

    }
}
