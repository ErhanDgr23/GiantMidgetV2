using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distancetext : MonoBehaviour {

    CanvasGroup cvgroup;

    Transform kam;

    private void Start()
    {
        kam = Camera.main.transform;
        cvgroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, kam.position);
        
        cvgroup.alpha = 1f / dist * 10f;
    }
}
