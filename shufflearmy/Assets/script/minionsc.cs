using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minionsc : MonoBehaviour {

    [SerializeField] private float zaman;

    private void Start()
    {
        Destroy(this.gameObject, zaman);
    }
}
