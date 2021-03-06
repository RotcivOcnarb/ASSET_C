﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableActionsList : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterScene(int scene){
        ScenePositionManager.setLastPosition(SceneManager.GetActiveScene().buildIndex , GameObject.Find("Player").transform.position);
        SceneManager.LoadScene(scene);
    }

    public void EnterYerYouti(){
        ScenePositionManager.setLastPosition(0, GameObject.Find("Player").transform.position);
        SceneManager.LoadScene(1);
    }

    public void ExitYerYouti(){
        ScenePositionManager.setLastPosition(1, GameObject.Find("Player").transform.position);
        SceneManager.LoadScene(0);
    }

    public void EnterBattle(){
        ScenePositionManager.setLastPosition(1, GameObject.Find("Player").transform.position);
        SceneManager.LoadScene(2);
    }
}
