using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePositionManager
{
    public static Dictionary<int, Vector3> lastPosition;

    public static Vector3 getLastPosition(int sceneIndex){
        if(lastPosition == null)
            lastPosition = new Dictionary<int, Vector3>();
        if(lastPosition.ContainsKey(sceneIndex))
            return lastPosition[sceneIndex];
        else return Vector3.zero;
    }

    public static void setLastPosition(int sceneIndex, Vector3 lsPos){
        if(lastPosition == null)
            lastPosition = new Dictionary<int, Vector3>();

        lastPosition[sceneIndex] = lsPos;
    }
}
