using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ExitDestroyer : MonoBehaviour
{
    [SerializeField] string[] TagsToDestroy;
    private void OnTriggerExit(Collider other)
    {
        foreach (string TagToDestroy in TagsToDestroy)
        {
            if (other.gameObject.tag == TagToDestroy)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
