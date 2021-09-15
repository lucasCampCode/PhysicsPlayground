using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaBehaviour : MonoBehaviour
{
    public GameObject rewardObject = null;
    public GameObject obsticle = null;
    public Material activeMaterial = null;
    [SerializeField]
    private Animator _animator = null;

    public float minHeightSpawn = 2;
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
            if (killOnExit)
            {
                other.GetComponent<PlayerMovementBehaviour>().Dead = true;
                _animator.enabled = false;
            }
            else
                Destroy(gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentTime += Time.deltaTime;
            currentTime2 += Time.deltaTime;
            if (currentTime > _timerBySeconds)
            {
                if (killOnExit)
                    Instantiate(rewardObject, transform.position, new Quaternion());
                Destroy(gameObject);
            }
            if(currentTime2 > _spawnTimer)
            {
                float randomX = Random.Range(-transform.localScale.x/2, transform.localScale.x/2);
                float randomY = Random.Range(minHeightSpawn, transform.localScale.y / 2);
                float randomZ = Random.Range(-transform.localScale.z/2, transform.localScale.z/2);

                Vector3 randomXYZ = new Vector3(randomX,randomY, randomZ);

                if (randomXYZ.magnitude > transform.localScale.x / 2 && !squareArena)
                    randomXYZ = randomXYZ.normalized * (transform.localScale.x - 5)/ 2;
                
                Vector3 spawnPosition = transform.position + randomXYZ;

                GameObject obj = Instantiate(obsticle, spawnPosition,new Quaternion());
                Destroy(obj, 5);

                currentTime2 -= _spawnTimer;
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _renderer.material = activeMaterial;

            Mesh mesh = GetComponent<MeshFilter>().mesh;
            Vector3[] normals = mesh.normals;
            for (int i = 0; i < normals.Length; i++)
                normals[i] = -normals[i];
            mesh.normals = normals;

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
