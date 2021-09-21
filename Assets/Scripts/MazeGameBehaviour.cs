using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGameBehaviour : MonoBehaviour
{
    public GameObject showObject;
    public CollectBehaviour collection;
    private void Update()
    {
        if (collection.RewardsCollected >= collection.winAmount - 1)
        {
            showObject.SetActive(true);
        }
        else
            showObject.SetActive(false);
    }
}
