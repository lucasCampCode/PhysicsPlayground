using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class collectBehaviour : MonoBehaviour
{
    public Animator _imageAnim;
    public Animator _altScene;
    public int winAmount = 1;
    private int rewardsCollected = 0;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Collectable"))
        {
            rewardsCollected++;
            Destroy(hit.gameObject);
        }
        if (hit.gameObject.CompareTag("Special"))
        {
            _imageAnim = _altScene;
            Destroy(hit.gameObject);
        }
    }
    private void Update()
    {
        if(rewardsCollected >= winAmount)
        {
            _imageAnim.SetBool("FadeToBlack", true);
        }
    }
}
