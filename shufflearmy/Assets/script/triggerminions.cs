using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerminions : MonoBehaviour {

    public gamemanager managersc;
    public List<GameObject> minionlist = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "kavga")
        {
            minionlist.Clear();
            managersc.oyunudurdu();

            if(transform.parent.transform.Find("minionparents").childCount <= 0)
            {
                managersc.failoldu();
            }

            for (int i = 0; i < transform.parent.transform.Find("minionparents").childCount; i++)
            {
                minionlist.Add(transform.parent.transform.Find("minionparents").GetChild(i).gameObject);
            }

            foreach (GameObject item in minionlist)
            {
                managersc.gucenemy = other.transform.parent.GetComponent<miniongroupsc>().guc;
                item.GetComponent<ingameminion>().saldir(other.gameObject);
            }

            Transform tr = other.transform.parent.transform.Find("cuceler");

            for (int i = 0; i < tr.childCount; i++)
            {
                if(tr.GetChild(i) != null)
                {
                    tr.GetChild(i).GetComponent<dusmanminion>().listedusman = minionlist;
                }
            }
        }
    }

}
