using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatforms : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        col.transform.parent = this.transform;
    }

    void OnTriggerExit(Collider col)
    {
        col.transform.parent = null;
    }
}
