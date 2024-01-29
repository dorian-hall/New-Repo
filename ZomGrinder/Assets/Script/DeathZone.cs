using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField]
    [Range(0, 100)]
    float size = 1;
    [SerializeField]
    [Range(0, 5)]
    [Tooltip("The rate at which the Death Zone expands.")]
    float expansionrat;
    Vector3 offset; 
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        offset = new Vector3(0, 0, offset.z += expansionrat * Time.deltaTime);
        rb.position += (Vector3.forward * expansionrat) * Time.deltaTime;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position + offset, size);
       
    }
}
