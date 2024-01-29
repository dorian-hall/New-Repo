using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{   
    Transform Player_Transform;
    GameObject PlanePrefab;
    [SerializeField]
    [Range(0, 100)]
    [Tooltip("The threshold until the new chunk spawns.")]
    float Threshold;
    float maxThreshold;
    float PlayerZ;
    List<GameObject>  Planes = new List<GameObject>();
    float Planesize;
    // Start is called before the first frame update
    void Start()
    {
        Player_Transform = GameObject.FindGameObjectWithTag("Player").transform;
        PlanePrefab = Resources.Load<GameObject>("Prefab/Plane");
        Planesize = (5 * PlanePrefab.transform.lossyScale.z) * 2;
        maxThreshold = Threshold;
        Planes.Add(Instantiate(PlanePrefab, transform.position,Quaternion.identity,transform));
    }

    // Update is called once per frame
    void Update()
    {
        PlayerZ = Player_Transform.position.z;
        SpawnPlane();
    }
    void SpawnPlane()
    {
        if (maxThreshold > PlayerZ) { return; }
        Planes.Add(Instantiate(PlanePrefab,new Vector3(transform.position.x, transform.position.y, Planes[Planes.Count-1].transform.position.z + Planesize),Quaternion.identity,transform));
        maxThreshold += Threshold;
    }

    
}
