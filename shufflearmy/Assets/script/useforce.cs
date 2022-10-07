using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;

public class useforce : MonoBehaviour {

    [SerializeField] float cool, hiz;
    [SerializeField] Rigidbody rb;
    [SerializeField] Vector3 dire;

    float zmn;

    void Start()
    {
        Destroy(this.gameObject, 5f);
        hiz = 2000f;
    }

    void Update()
    {
        if(zmn < cool)
        {
            rb.velocity = new Vector3(dire.x * hiz * Time.deltaTime, dire.y * hiz * Time.deltaTime, dire.z * hiz * Time.deltaTime);
            zmn += Time.deltaTime;
        }
    }
}
