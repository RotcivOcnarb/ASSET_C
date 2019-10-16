using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    public Rect bounds;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Segue o game Object
        Vector3 nextPos = 
            transform.position +
            (player.transform.position - transform.position)/10.0f;
        nextPos.z = -100;
        transform.position = nextPos;
    
        //Clampa baseado no Bounds
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        //Clampa -X
        if(transform.position.x - width/2f < bounds.x){
            transform.position = new Vector3(
                bounds.x + width/2f,
                transform.position.y,
                -100
            );
        }
        //Clampa +X
        if(transform.position.x + width/2f > bounds.x + bounds.size.x){
            transform.position = new Vector3(
                bounds.x + bounds.size.x - width/2f,
                transform.position.y,
                -100
            );
        }
        //Clampa -Y
        if(transform.position.y - height/2f < bounds.y){
            transform.position = new Vector3(
                transform.position.x,
                bounds.y + height/2f,
                -100
            );
        }
        //Clampa +Y
        if(transform.position.y + height/2f > bounds.y + bounds.size.y){
            transform.position = new Vector3(
                transform.position.x,
                bounds.y + bounds.size.y - height/2f,
                -100
            );
        }

    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawLine(bounds.position, bounds.position + bounds.size * new Vector2(1, 0));
        Gizmos.DrawLine(bounds.position + bounds.size * new Vector2(1, 0), bounds.position + bounds.size);
        Gizmos.DrawLine(bounds.position + bounds.size, bounds.position + bounds.size * new Vector2(0, 1));
        Gizmos.DrawLine(bounds.position + bounds.size * new Vector2(0, 1), bounds.position);
    }
}
