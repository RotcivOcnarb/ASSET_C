using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public AudioClip newMusic;

    void Awake(){
        GameObject go = GameObject.Find("Game Music");
        if(!go) return;
        if(go.GetComponent<AudioSource>().clip != newMusic){
            go.GetComponent<AudioSource>().clip = newMusic;
            go.GetComponent<AudioSource>().Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
