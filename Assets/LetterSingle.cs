using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSingle : MonoBehaviour
{

    public int line;
    public int pos;

    public Vector3 textStart;

    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = transform.position + (textStart + new Vector3(
            pos*0.35f,
            -line*0.7f,
            0
        ) - transform.position)/10f;
        targetPos += Random.insideUnitSphere * 0.01f;
        targetPos.z = 0;
        transform.position = targetPos;

        Quaternion targetRot = new Quaternion(
            transform.rotation.x + (0 - transform.rotation.x) / 5f,
            transform.rotation.y + (0 - transform.rotation.y) / 5f,
            transform.rotation.z + (0 - transform.rotation.z) / 5f,
            transform.rotation.w + (1 - transform.rotation.w) / 5f
        );

        transform.rotation = targetRot;
        
    }
}
