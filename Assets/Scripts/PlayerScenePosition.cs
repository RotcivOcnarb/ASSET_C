using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScenePosition : MonoBehaviour
{

    public GameObject player;
    public int scene;

    // Start is called before the first frame update
    void Start()
    {
        if(ScenePositionManager.getLastPosition(scene) != Vector3.zero){
            player.transform.position = ScenePositionManager.getLastPosition(scene);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
