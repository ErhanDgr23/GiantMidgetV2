using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour {

    [SerializeField] float olzaman;

    private void Start()
    {
        Destroy(this.gameObject, olzaman);
    }

}
