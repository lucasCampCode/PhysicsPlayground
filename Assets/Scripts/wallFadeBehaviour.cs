using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallFadeBehaviour : MonoBehaviour
{

    public GameObject player;
    public float radius = 10;

    public Material _mat;
    public Material _transparentMat;
    private MeshRenderer _renderer;
    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= radius)
        {
            _renderer.material.color = Color.Lerp(_mat.color, _transparentMat.color, Vector3.Distance(transform.position, player.transform.position) / radius);
        }
        else
            _renderer.material.color = _transparentMat.color;
    }
}
