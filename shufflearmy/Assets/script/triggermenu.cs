using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggermenu : MonoBehaviour {

    public bool b;
    
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "kavga")
        {
            if(b == true)
            {
                Destroy(other.transform.parent.gameObject);
            }
        }

        if(other.tag == "tuzak")
        {
            if (b == true)
            {
                Destroy(other.transform.parent.gameObject);
            }
        }
 
        if (other.tag == "bosenemy")
        {
            if (b == true)
            {
                Destroy(other.transform.parent.gameObject);
            }
        }
    }
}
