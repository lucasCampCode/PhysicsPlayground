using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaBehaviour : MonoBehaviour
{
    public GameObject obsticle;

    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private float _timer = 10;
    private float currentTime = 0;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.enabled = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player"))
        {
            currentTime += Time.deltaTime;
            if (currentTime > _timer)
                Destroy(gameObject);


        }
    }
}
