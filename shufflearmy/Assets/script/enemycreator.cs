using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycreator : MonoBehaviour {

    [SerializeField] private List<GameObject> prefabs = new List<GameObject>();
    [SerializeField] private List<Transform> poses = new List<Transform>();
    [SerializeField] private Transform parenttr;
    [SerializeField] private Transform ekstratuzak;
    [SerializeField] private int maxvalue, minvalue, baslamiktar;
    [SerializeField] private float yvalue;
    [SerializeField] private bool baslamiktarb, minionsc, tuzaksc, ektuzak;

    int howmany, whichpre, whichpos, ofsetz;

    private void Start()
    {
        howmany = (int)Random.Range(minvalue, maxvalue);

        randomdondur();
        olustur();
    }

    public void randomdondur()
    {
        whichpre = Random.Range(0, prefabs.Count);
        ofsetz = Random.Range(-7, 7);

        if (poses.Count > 0)
        {
            if (baslamiktarb)
            {
                whichpos = 0;
                whichpre = Random.Range(0, 2);
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
            if (ektuzak)
            {
                ofsetz = 0;
            }

            GameObject obj = Instantiate(prefabs[whichpre], new Vector3(poses[whichpos].position.x, yvalue, poses[whichpos].position.z + ofsetz), poses[whichpos].rotation);
            obj.transform.SetParent(poses[whichpos].transform);
            poses.Remove(poses[whichpos]);
            randomdondur();
        }
    }

    public void olusturyeniden(int nerde)
    {
        if (ektuzak)
        {
            ofsetz = 0;
        }

        GameObject obj = Instantiate(prefabs[whichpre], new Vector3(poses[nerde].position.x, yvalue, poses[nerde].position.z + ofsetz), poses[nerde].rotation);
        obj.transform.SetParent(poses[nerde].transform);
        poses.Remove(poses[nerde]);
        randomdondur();
    }
}
