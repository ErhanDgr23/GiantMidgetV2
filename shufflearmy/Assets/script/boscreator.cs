using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boscreator : MonoBehaviour {

    public int howmany;

    [SerializeField] private List<GameObject> prefabs = new List<GameObject>();
    [SerializeField] private List<Transform> poses = new List<Transform>();
    [SerializeField] private Transform parenttr;
    [SerializeField] private int maxvalue, minvalue, baslamiktar;
    [SerializeField] private float yvalue;
    [SerializeField] private bool baslamiktarb, minionsc;
    [SerializeField] private GameObject aktifet;

    int whichpre, whichpos, ofsetz;

    private void Start()
    {
        howmany = (int)Random.Range(minvalue, maxvalue);

        randomdondur();
        olustur();
        kontrolet();
        aktifet.gameObject.SetActive(true);
    }

    public void randomdondur()
    {
        whichpre = Random.Range(0, prefabs.Count);
        ofsetz = Random.Range(-15, 15);

        if (poses.Count > 0)
        {
            if (baslamiktarb)
            {
                whichpos = 0;
                whichpre = Random.Range(0, 3);
                baslamiktarb = false;
            }
            else
            {
                whichpos = Random.Range(0, poses.Count);
            }
        }
        else
        {
            whichpos = 0;
        }
    }

    public void olustur()
    {
        for (int i = 0; i < howmany; i++)
        {
            GameObject obj = Instantiate(prefabs[whichpre], new Vector3(poses[whichpos].position.x, yvalue, poses[whichpos].position.z + ofsetz), poses[whichpos].rotation);
            obj.transform.SetParent(poses[whichpos].transform);
            poses.Remove(poses[whichpos]);
            randomdondur();
        }
    }

    public void olusturyeniden(int nerde)
    {
        GameObject obj = Instantiate(prefabs[whichpre], new Vector3(poses[nerde].position.x, yvalue, poses[nerde].position.z + ofsetz), poses[nerde].rotation);
        obj.transform.SetParent(poses[nerde].transform);
        poses.Remove(poses[nerde]);
        randomdondur();
    }

    public void kontrolet()
    {
        if (minionsc)
        {
            if (poses[0].childCount <= 0)
            {
                olusturyeniden(0);
            }

            if (poses[1].childCount <= 0)
            {

            }
        }
    }
}
