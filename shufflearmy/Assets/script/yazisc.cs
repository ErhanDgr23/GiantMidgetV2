using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yazisc : MonoBehaviour {

    Transform kamerapos;

    private void Start()
    {
        kamerapos = Camera.main.transform;
    }

    void Update()
    {
        Vector3 pos = new Vector3(kamerapos.position.x, kamerapos.position.y, kamerapos.position.z);
        transform.LookAt(pos);
    }
}
