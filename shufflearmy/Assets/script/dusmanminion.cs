using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusmanminion : MonoBehaviour {

    public List<GameObject> listedusman = new List<GameObject>();

    gamemanager managersc;

    Transform target;
    float enyakin = 1000f, objdist;

    private void Start()
    {
        managersc = GameObject.FindGameObjectWithTag("manager").GetComponent<gamemanager>();
    }

    public void Update()
    {
        if (managersc.savas == true)
        {
            if(target != null)
            {
                Vector3 dire = transform.position - target.position;
                transform.Translate(dire * 4f * Time.deltaTime);
            }
            else
            {
                yakinobjbul();
            }
        }
    }

    public void yakinobjbul()
    {
        foreach (GameObject item in listedusman)
        {
            if(item != null)
            {
                float dist = Vector3.Distance(transform.position, item.transform.position);

                if (dist < enyakin)
                {
                    enyakin = dist;
                    target = item.transform;
                }
            }
        }
    }
}
