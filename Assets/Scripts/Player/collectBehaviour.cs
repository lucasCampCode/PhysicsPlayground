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
        if (collision.gameObject.CompareTag("Collectable"))
        {
            _rewardsCollected++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Special"))
        {
            _imageAnim.gameObject.GetComponent<FadeToBlack>().sceneIndex = SpecialSceneName;
            _rewardsCollected++;
            Destroy(collision.gameObject);
        }
    }
    private void Update()
    {
        if(_rewardsCollected >= winAmount)
            _imageAnim.SetBool("FadeToBlack", true);
    }
}
