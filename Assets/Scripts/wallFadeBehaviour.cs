using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// wall Fade for the Maze
/// </summary>
public class WallFadeBehaviour : MonoBehaviour
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
        //when player is close to a wall
        if (Vector3.Distance(transform.position, player.transform.position) <= radius)
        {//lerp through the walls colors based on distance to the wall
            _renderer.material.color = Color.Lerp(_mat.color, _transparentMat.color, Vector3.Distance(transform.position, player.transform.position) / radius);
        }
        else//if not even close set it to the clear state
            _renderer.material.color = _transparentMat.color;
    }
}
