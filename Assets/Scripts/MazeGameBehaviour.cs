using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGameBehaviour : MonoBehaviour
{
    public GameObject[] showObject;
    public CollectBehaviour collection;
    private void Update()
    {
        //when all arenas have been conqured show door knob
        if (collection.RewardsCollected >= collection.winAmount - 1)
        {
            foreach(GameObject obj in showObject)
                obj.SetActive(true);
        }
        else
            foreach(GameObject obj in showObject)
                obj.SetActive(false);
    }
}
