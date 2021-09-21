using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaBehaviour : MonoBehaviour
{
    public float scaleArea = 0;
    public GameObject rewardObject = null;
    public GameObject obsticle = null;
    public Material activeMaterial = null;
    [SerializeField]
    private Animator _animator = null;

    public float minHeightSpawn = 2;
    public float maxHieghtSpawn = 10;
    [SerializeField]
    private float _timerBySeconds = 10;
    [SerializeField, Tooltip("second per drop")]
    private float _spawnTimer = 1;
    public bool squareArena = false;
    public bool killOnExit = false;
    private MeshRenderer _renderer = null;
    private float currentTime = 0;
    private float currentTime2 = 0;
    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //if the player leaves the arena while kill is enabled
            if (killOnExit)
            {
                //kill the player
                other.GetComponent<PlayerMovementBehaviour>().Dead = true;
                _animator.enabled = false;
            }
            else//if not destroy the arena
                Destroy(gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        //if object inside trigger is player
        if (other.CompareTag("Player"))
        {
            //start timers
            currentTime += Time.deltaTime;
            currentTime2 += Time.deltaTime;
            //if timer1 is greater than time for arena
            if (currentTime > _timerBySeconds)
            {
                //if kill on exit is enabled 
                if (killOnExit)//spawn reward in front of player
                    Instantiate(rewardObject, _animator.gameObject.transform.forward * 5, new Quaternion());
                Destroy(gameObject);//destroy arena
            }
            //if timer2 greater than spawn timer 
            if(currentTime2 > _spawnTimer)
            {
                //get a random position 
                float randomX = Random.Range(-scaleArea, scaleArea);
                float randomY = Random.Range(minHeightSpawn, maxHieghtSpawn);
                float randomZ = Random.Range(-scaleArea, scaleArea);

                Vector3 randomXYZ = new Vector3(randomX,randomY, randomZ);
                //get the spawn position
                Vector3 spawnPosition = other.transform.position + randomXYZ;
                //spawn hazard on spawn position
                GameObject obj = Instantiate(obsticle, spawnPosition,new Quaternion());
                //destroy after 5 seconds;
                Destroy(obj, 5);
                //decrese timer so it doesn't infinately spawns;
                currentTime2 -= _spawnTimer;
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if a player enters arena flip the arenas normals and change active material
        if (other.CompareTag("Player"))
        {
            //change active material
            _renderer.material = activeMaterial;
            //grab mesh from the mesh filter
            Mesh mesh = GetComponent<MeshFilter>().mesh;
            //grab the normals from the mesh
            Vector3[] normals = mesh.normals;
            //flip the normals
            for (int i = 0; i < normals.Length; i++)
                normals[i] = -normals[i];
            mesh.normals = normals;
            //rearange trinagles
            for (int m = 0; m < mesh.subMeshCount; m++)
            {
                int[] triangles = mesh.GetTriangles(m);
                for (int i = 0; i < triangles.Length; i += 3)
                {
                    int temp = triangles[i + 0];
                    triangles[i + 0] = triangles[i + 1];
                    triangles[i + 1] = temp;
                }
                mesh.SetTriangles(triangles, m);
            }
        }
    }
}
