using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MoreMountains.NiceVibrations;

public class MinionSpawner : MonoBehaviour {

    public List<GameObject> objectlist = new List<GameObject>();
    public float giantvalue, minionvalue;
    [Range(0f, 1f)] public float radius, distance;

    [HideInInspector] public int hangigiant;
    [HideInInspector] public GameObject[] giants;
    [HideInInspector] public GameObject giantpuananim;

    [SerializeField] private GameObject prefab, prefabanim, prefabanim2, giantobj, minionbubble;
    [SerializeField] private Transform parenttr, giantpos;
    [SerializeField] private TextMeshProUGUI tgiant, tminion;
    [SerializeField] private float rdmvaluesx, rdmvaluesy;
    [SerializeField] private gianttrigger triggergiant;
    [SerializeField] private Animator animcanvas, animcanvascuce;
    [SerializeField] private ParticleSystem smoke;

    gamemanager managersc;
    float zmn, zmn2, cool = 0.15f, calismasayi, katsayi = 0.25f;
    GameObject minionanim;
    bool animminionkapa, hapticver;

    bool devv1 = true, devv2 = true, devv3 = true, devv4 = true;

    private void Start()
    {
        managersc = GameObject.FindObjectOfType<gamemanager>();
        cucebaslaolustur(10);
    }

    private void Update()
    {
        tgiant.text = giantvalue.ToString();
        tminion.text = minionvalue.ToString();

        giantscaler();

        zmn += Time.deltaTime;
        zmn2 += Time.deltaTime;

        if(minionvalue <= 0f)
        {
            minionbubble.SetActive(false);
        }
        else
        {
            minionbubble.SetActive(true);
        }

        if (managersc.devamet)
        {
            giants[hangigiant].GetComponent<Animator>().Play("idle");
            managersc.devamet = false;
        }

        if (giantvalue < 11)
        {
            devv2 = true;
            devv3 = true;
            devv4 = true;

            if (devv1)
            {
                smoke.Play();
                MMVibrationManager.Haptic(HapticTypes.Success, true);
                devv1 = false;
            }

            hangigiant = 0;
            triggergiant.giantsayi = 0;
            triggergiant.giantdegisti();
            giants[0].transform.parent.parent.transform.localPosition = new Vector3(0.75f, 0f, 5.75f);
            giants[0].transform.localPosition = new Vector3(0f, -0.06f, 0f);
            giants[1].transform.localPosition = new Vector3(0f, -5f, -20f);
            giants[2].transform.localPosition = new Vector3(0f, -5f, -20f);
            giants[3].transform.localPosition = new Vector3(0f, -5f, -20f);
        }
        else if (giantvalue >= 11 && giantvalue < 20)
        {
            devv1 = true;
            devv3 = true;
            devv4 = true;

            if (devv2)
            {
                smoke.Play();
                MMVibrationManager.Haptic(HapticTypes.Success, true);
                devv2 = false;
            }

            hangigiant = 1;
            triggergiant.giantsayi = 1;
            triggergiant.giantdegisti();
            giants[0].transform.parent.parent.transform.localPosition = new Vector3(0.75f, 0f, 5.75f);
            giants[0].transform.localPosition = new Vector3(0f, -5f, -20f);
            giants[1].transform.localPosition = new Vector3(0f, -0.06f, 0f);
            giants[2].transform.localPosition = new Vector3(0f, -5f, -20f);
            giants[3].transform.localPosition = new Vector3(0f, -5f, -20f);
        }
        else if (giantvalue >= 20 && giantvalue < 31)
        {
            devv2 = true;
            devv1 = true;
            devv4 = true;

            if (devv3)
            {
                smoke.Play();
                MMVibrationManager.Haptic(HapticTypes.Success, true);
                devv3 = false;
            }

            hangigiant = 2;
            triggergiant.giantsayi = 2;
            triggergiant.giantdegisti();
            giants[0].transform.parent.parent.transform.localPosition = new Vector3(0.75f, 0f, 5.75f);
            giants[0].transform.localPosition = new Vector3(0f, -5f, -20f);
            giants[1].transform.localPosition = new Vector3(0f, -5f, -20f);
            giants[2].transform.localPosition = new Vector3(0f, -0.06f, 0f);
            giants[3].transform.localPosition = new Vector3(0f, -5f, -20f);
        }
        else if (giantvalue >= 31)
        {
            devv2 = true;
            devv3 = true;
            devv1 = true;

            if (devv4)
            {
                smoke.Play();
                MMVibrationManager.Haptic(HapticTypes.Success, true);
                devv4 = false;
            }

            hangigiant = 3;
            triggergiant.giantsayi = 3;
            triggergiant.giantdegisti();
            giants[0].transform.parent.parent.transform.localPosition = new Vector3(0.75f, 0f, 5.75f);
            giants[0].transform.localPosition = new Vector3(0f, -5f, -20f);
            giants[1].transform.localPosition = new Vector3(0f, -5f, -20f);
            giants[2].transform.localPosition = new Vector3(0f, -5f, -20f);
            giants[3].transform.localPosition = new Vector3(0f, -0.06f, 0f);
        }
    }

    public void giantscaler()
    {
        Vector3 scale = new Vector3(giantvalue / 50f, giantvalue / 50f, giantvalue / 50f);

        float x = Mathf.Clamp(scale.x + 0.75f, 0f, 1.3f);
        float y = Mathf.Clamp(scale.y + 0.75f, 0f, 1.3f);
        float z = Mathf.Clamp(scale.z + 0.75f, 0f, 1.3f);

        giantobj.transform.localScale = new Vector3(x, y, z);
        giantobj.transform.localPosition = new Vector3(-0.2f, scale.y, giantobj.transform.localPosition.z);
    }

    public void cucebaslaolustur(float sayi)
    {
        for (int i = 0; i < sayi; i++)
        {
            float x = Random.Range(objectlist[0].transform.position.x, objectlist[0].transform.position.x);
            float y = Random.Range(objectlist[0].transform.position.z, objectlist[0].transform.position.z);

            var xpos = distance * Mathf.Sqrt(minionvalue) * Mathf.Cos(minionvalue * radius);
            var zpos = distance * Mathf.Sqrt(minionvalue) * Mathf.Sin(minionvalue * radius);

            Vector3 pos = new Vector3(x + xpos, objectlist[0].transform.position.y, y + zpos);

            GameObject minion = Instantiate(prefab, pos, Quaternion.identity);
            minion.GetComponent<ingameminion>().posayarla(pos);
            objectlist.Add(minion);
            minion.transform.SetParent(parenttr);

            minionvalue++;
            zmn = 0f;
        }
    }

    public void cucepossifirla()
    {
        for (int i = 1; i < minionvalue;)
        {
            float x = Random.Range(objectlist[0].transform.position.x, objectlist[0].transform.position.x);
            float y = Random.Range(objectlist[0].transform.position.z, objectlist[0].transform.position.z);

            var xpos = distance * Mathf.Sqrt(i) * Mathf.Cos(i * radius);
            var zpos = distance * Mathf.Sqrt(i) * Mathf.Sin(i * radius);

            Vector3 pos = new Vector3(x + xpos, objectlist[0].transform.position.y, y + zpos);
            
            objectlist[i].GetComponent<ingameminion>().ilkpos = pos;
            print(objectlist[i].name + i);
            i++;
        }
    }

    public void cucespawn()
    {
        if (giantvalue > 0 && !animminionkapa) 
        {
            minionanim = Instantiate(prefabanim, giantobj.transform.GetChild(0).transform.position, Quaternion.identity);
            minionanim.transform.SetParent(giantobj.transform);
            animminionkapa = true;
        }

        if (zmn > cool)
        {
            animminionkapa = false;

            if (giantvalue > 0)
            {
                StartCoroutine(beklecucespawn());
                giantvalue--;
                minionvalue++;
                zmn = 0f;
            }
        }
    }

    IEnumerator beklecucespawn()
    {
        yield return new WaitForSeconds(0.1f);

        float x = Random.Range(objectlist[0].transform.position.x, objectlist[0].transform.position.x);
        float y = Random.Range(objectlist[0].transform.position.z, objectlist[0].transform.position.z);

        var xpos = distance * Mathf.Sqrt(minionvalue) * Mathf.Cos(minionvalue * radius);
        var zpos = distance * Mathf.Sqrt(minionvalue) * Mathf.Sin(minionvalue * radius);

        Vector3 pos = new Vector3(x + xpos, objectlist[0].transform.position.y, y + zpos);

        animcanvascuce.Play("bounce");
        MMVibrationManager.Haptic(HapticTypes.Success, true);
        GameObject minion = Instantiate(prefab, pos, Quaternion.identity);
        minion.GetComponent<ingameminion>().posayarla(pos);
        objectlist.Add(minion);
        minion.transform.SetParent(parenttr);
    }

    public void cuceyoket(GameObject yoketobj ,bool sil)
    {
        if (sil)
            Destroy(yoketobj);
        else
            StartCoroutine(beklesilcuce(yoketobj));

        objectlist.Remove(yoketobj);
        minionvalue--;
    }

    IEnumerator beklesilcuce(GameObject yoketobj)
    {
        yield return new WaitForSeconds(0.75f);

        MMVibrationManager.Haptic(HapticTypes.Failure, true);
        if (yoketobj != null)
        {
            Destroy(yoketobj);
            cucepossifirla();
        }
    }

    public void cucesil()
    {
        if (zmn2 > cool)
        {
            if(objectlist.Count > 1f)
            {
                if(managersc.finishb == true)
                {
                    if (minionvalue > 0)
                    {
                        GameObject silcuce = Instantiate(prefabanim2, objectlist[objectlist.Count - 1].transform.position, Quaternion.identity);
                        Destroy(objectlist[objectlist.Count - 1]);
                        objectlist.Remove(objectlist[objectlist.Count - 1]);
                        MMVibrationManager.Haptic(HapticTypes.Failure, true);
                        giantpuananim.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                        giantpuananim.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "+1";
                        giantpuananim.gameObject.SetActive(true);
                        giantpuananim.GetComponent<Animator>().Play("devekstraanim");
                        animcanvas.Play("bounce");
                        giantvalue++;
                        minionvalue--;
                        triggergiant.giantsayi = 0;
                        triggergiant.giantdegisti();
                        managersc.animdegisti(giants[hangigiant].GetComponent<Animator>());
                        zmn2 = 0f;
                    }
                }
                else
                {
                    if (minionvalue > 1f)
                    {
                        GameObject silcuce = Instantiate(prefabanim2, objectlist[objectlist.Count - 1].transform.position, Quaternion.identity);
                        Destroy(objectlist[objectlist.Count - 1]);
                        objectlist.Remove(objectlist[objectlist.Count - 1]);
                        MMVibrationManager.Haptic(HapticTypes.Failure, true);
                        giantpuananim.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                        giantpuananim.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "+1";
                        giantpuananim.gameObject.SetActive(true);
                        giantpuananim.GetComponent<Animator>().Play("devekstraanim");
                        animcanvas.Play("bounce");
                        giantvalue++;
                        minionvalue--;
                        triggergiant.giantsayi = 0;
                        triggergiant.giantdegisti();
                        managersc.animdegisti(giants[hangigiant].GetComponent<Animator>());
                        zmn2 = 0f;
                    }
                }              
            }
        }
    }
}
