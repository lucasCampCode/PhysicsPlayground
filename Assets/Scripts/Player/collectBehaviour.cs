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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            rewardsCollected++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Special"))
        {
            _imageAnim = _altScene;
            Destroy(collision.gameObject);
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
