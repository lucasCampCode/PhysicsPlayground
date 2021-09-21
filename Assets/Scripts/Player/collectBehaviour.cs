using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollectBehaviour : MonoBehaviour
{
    public Animator _imageAnim;
    public string SpecialSceneName;
    public int winAmount = 1;
    private int _rewardsCollected = 0;
    public int RewardsCollected { get { return _rewardsCollected; } }
    private void OnCollisionEnter(Collision collision)
    {
        //when the collision hits a collectable
        if (collision.gameObject.CompareTag("Collectable"))
        {
            //add to the reward count
            _rewardsCollected++;
            //destroy the object that you collided with
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Special"))
        {
            //change what scene the animator will go to
            _imageAnim.gameObject.GetComponent<FadeToBlack>().sceneIndex = SpecialSceneName;
            //add to the reward count
            _rewardsCollected++;
            //destroy the object that you collided with
            Destroy(collision.gameObject);
        }
    }
    private void Update()
    {
        //when collected all rewards goes to the next scene
        if(_rewardsCollected >= winAmount)
            _imageAnim.SetBool("FadeToBlack", true);
    }
}
