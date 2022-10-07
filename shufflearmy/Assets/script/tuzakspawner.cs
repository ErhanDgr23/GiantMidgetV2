using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuzakspawner : MonoBehaviour {

    [SerializeField] private List<GameObject> prefabs = new List<GameObject>();
    [SerializeField] private List<Transform> poses = new List<Transform>();
    [SerializeField] private Transform parenttr;
    [SerializeField] private int maxvalue, minvalue;
    [SerializeField] private float yvalue;

    int howmany, whichpre, whichpos;

    private void Start()
    {
        howmany = (int)Random.Range(minvalue, maxvalue);

        randomdondur();
        olustur();
    }

    private void Update()
    {
    }

    public void randomdondur()
    {
        whichpre = Random.Range(0, prefabs.Count);

        if (poses.Count > 0)
        {
            whichpos = Random.Range(0, poses.Count);
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
            GameObject obj = Instantiate(prefabs[whichpre], new Vector3(poses[whichpos].position.x, yvalue, poses[whichpos].position.z), poses[whichpos].rotation);
            obj.transform.SetParent(parenttr);
            poses[whichpos].gameObject.SetActive(false);
            poses.Remove(poses[whichpos]);
            randomdondur();
        }
    }
}
