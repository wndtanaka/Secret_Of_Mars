using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOnly : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Tower")
        {
            Debug.Log("in");
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Tower")
        {
            Debug.Log("out");
        }
    }
}
