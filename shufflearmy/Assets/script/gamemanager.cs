using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour {

    public bool walk, savas, failolb;

    [Header("finish")] 
    [SerializeField] private Transform campos;
    [SerializeField] private Transform boscampos;
    [SerializeField] private Transform karakterpos;
    [SerializeField] private Transform sonbosspos;
    [SerializeField] private GameObject finalbosobj;
    [SerializeField] private GameObject finalbosobjanimli;
    [SerializeField] private GameObject bizimbos;
    [SerializeField] private duvar bosduvar;

    [Header("ingame")]
    public yer yersc;

    [SerializeField] private Slider levelslid;
    [SerializeField] private Transform cuceparent, baslapos;
    [SerializeField] private MinionSpawner minionspawnersc;
    [SerializeField] private menuler menusc;
    [SerializeField] private MouseClickScript mouse;
    [SerializeField] private Animator[] giantanimator;
    [SerializeField] private Transform enemygroups;
    [SerializeField] private GameObject ektuzak;

    [HideInInspector] public float gucenemy;
    [HideInInspector] public bool finishb, bittibekle, basla, oyunbasladi, devamet, failhizkes;

    bool birkere;
    GameObject kamera;
    float hizeski;
    Animator animmy, animenemy;
    float zmn, zmn2, cool = 1.75f, cool2 = 0.5f;

    public float zmn3, cool3 = 1f, zmn4, cool4 = 1f;

    private void Start()
    {
        Time.timeScale = 1f;
        walk = false;
        oyunbasladi = false;
        animenemy = finalbosobj.GetComponent<Animator>();
        kamera = Camera.main.gameObject;

        hizeski = 6f;
    }

    public void failoldu()
    {
        failolb = true;
        failhizkes = true;
    }

    private void Update()
    {
        kontrolet();
        zmn += Time.deltaTime;
        zmn2 += Time.deltaTime;

        if(failhizkes == true)
        {
            yersc.hiz = 0f;
            oyunudurdu();
        }

        if (!finishb)
        {
            float distlevelf = Vector3.Distance(baslapos.position, kamera.transform.position);
            distlevelf = Mathf.Clamp(distlevelf, 0f, 200f);
            levelslid.value = distlevelf;
        }
        else
        {
            levelslid.value = 200f;
        }

        if(zmn2 > cool2)
        {
            if (minionspawnersc.minionvalue + minionspawnersc.giantvalue <= 0)
            {
                failoldu();
                zmn2 = 0f;
            }
        }

        if (finishb)
        {
            yersc.hiz = 0f;

            if (minionspawnersc.minionvalue > 0)
            {
                walk = false;
                minionspawnersc.cucesil();
            }
            else
            {
                if(birkere && !basla)
                    walk = true;

                zmn3 += Time.deltaTime;
                minionspawnersc.enabled = false;     
                
                if(zmn3 > cool3)
                    bizimbos.transform.position = Vector3.MoveTowards(bizimbos.transform.position, new Vector3(karakterpos.position.x, bizimbos.transform.position.y, karakterpos.position.z), 4.5f * Time.deltaTime);
                else
                    bizimbos.transform.position = Vector3.MoveTowards(bizimbos.transform.position, new Vector3(bizimbos.transform.position.x, bizimbos.transform.position.y, bizimbos.transform.position.z + 10f), 4.5f * Time.deltaTime);

                if (!basla)
                {
                    zmn4 += Time.deltaTime;

                    if (zmn4 > cool4)
                    {
                        Vector3 pos = new Vector3(boscampos.transform.position.x, 6f, boscampos.transform.position.z - 3f);
                        kamera.transform.position = Vector3.Lerp(kamera.transform.position, pos, 4f * Time.deltaTime);

                        kamera.transform.LookAt(finalbosobjanimli.transform);
                    }
                }

                if (!bittibekle)
                {
                    StartCoroutine(beklevur());
                    bittibekle = true;
                }
            }

            if (basla)
            {
                if(finalbosobjanimli == true)
                {
                    Vector3 pos = new Vector3(boscampos.transform.position.x - 1f, 6f, boscampos.transform.position.z + 1.75f);
                    kamera.transform.position = Vector3.Lerp(kamera.transform.position, pos, 4f * Time.deltaTime);

                    kamera.transform.LookAt(finalbosobjanimli.transform);
                }

                if (!birkere)
                {
                    zmn = 0f;
                    walk = false;
                    animmy.SetBool("walk", false);
                    animmy.Play("punch");
                    StartCoroutine(bekleucur());
                    birkere = true;
                }
                else
                {
                    if(zmn > cool)
                    {
                        animmy.Play("idle");
                        zmn = 0f;
                    }
                }
            }
        }
    }

    public void winekran(float puan)
    {
        menusc.win(puan);
    }

    IEnumerator bekleucur()
    {
        yield return new WaitForSeconds(0.8f);
        bosduvar.kackerekir = (int)minionspawnersc.giantvalue / 10f;
        finalbosobjanimli.SetActive(true);
        finalbosobj.SetActive(false);
        finalbosobjanimli.GetComponent<finalbossc>().vurdu();
    }

    IEnumerator beklevur()
    {
        yield return new WaitForSeconds(3.25f);       
        basla = true;
    }

    public void animdegisti(Animator anim)
    {
        animmy = anim;
    }

    public void finish(Animator animmybos)
    {
        walk = false;
        mouse.enabled = false;
        animmy = animmybos;
        devamet = false;
        finishb = true;
    }

    public void kontrolet()
    {
        if (enemygroups.GetChild(1).GetChild(1).childCount < 1)
            enemygroups.GetChild(0).GetChild(2).gameObject.SetActive(false);

        if (enemygroups.GetChild(0).GetChild(1).childCount <= 1)
        {
            ektuzak.gameObject.SetActive(true);
        }
    }

    public void savasbasla(float gucsavas)
    {
        gucenemy = gucsavas;
    }

    public void oyunudurdu()
    {
        yersc.hiz = 0;
        walk = false;
        mouse.enabled = false;
    }

    public void oyundurdurstart()
    {
        yersc.hiz = 0;
        walk = false;
    }

    public void oyunudeavm()
    {
        yersc.hiz = hizeski;
        walk = true;
        mouse.enabled = true;
    }
}
