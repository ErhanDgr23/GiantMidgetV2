using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yer : MonoBehaviour {

    public float hiz;

    public Transform yerparettr;

    private void Update()
    {
        yerparettr.transform.Translate(Vector3.back * hiz * Time.deltaTime);    
    }
}
