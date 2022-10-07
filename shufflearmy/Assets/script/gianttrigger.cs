using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gianttrigger : MonoBehaviour {

    public int giantsayi;

    gamemanager managersc;
    MinionSpawner minionspsc;

    Transform targetbos;
    Animator anim;

    float artir, fark, timee, cooldown, mesafe;
    bool yenildi, calisti;

    private void Start()
    {
        mesafe = 4f;
        managersc = GameObject.FindGameObjectWithTag("manager").GetComponent<gamemanager>();
        minionspsc = GameObject.FindGameObjectWithTag("minionspawner").GetComponent<MinionSpawner>();
        giantdegisti();
    }

    public void giantdegisti()
    {
        anim = minionspsc.giants[giantsayi].GetComponent<Animator>();

        if (managersc.finishb)
        {
            managersc.finish(anim);
        }
    }

    private void Update()
    {
        if(targetbos != null)
        {
            float dist = Vector3.Distance(transform.position, targetbos.position);

            if(dist < mesafe)
            {
                print("mesafe" + mesafe);
                targetbos.GetComponent<enemybosssc>().target = null;

                if (!yenildi)
                {
                    if (!calisti)
                    {
                        anim.Play("punch");
                        StartCoroutine(bekleoldur());
                        calisti = true;
                    }
                }
                else
                {
                    if (!calisti)
                    {
                        targetbos.GetComponent<enemybosssc>().yumrukat();
                        StartCoroutine(bekleol());
                        calisti = true;
                    }
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetbos.position, 5f * Time.deltaTime);
            }
        }
    }

    IEnumerator bekleoldur()
    {
        yield return new WaitForSeconds(0.60f);
        targetbos.GetComponent<enemybosssc>().ol();
        artir = targetbos.GetComponent<enemybosssc>().guc;
        fark = minionspsc.giantvalue - artir;
        fark = Mathf.Clamp(fark, 0f, 5f);
        targetbos = null;

        minionspsc.giantpuananim.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        float sonuc = artir + fark;
        minionspsc.giantpuananim.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "+" + sonuc;
        minionspsc.giantpuananim.gameObject.SetActive(true);
        minionspsc.giantpuananim.GetComponent<Animator>().Play("devekstraanim2");

        yield return new WaitForSeconds(1f);
        managersc.oyunudeavm();
        minionspsc.giantvalue += artir + fark;
        artir = 0f;
        fark = 0f;
        calisti = false;
    }

    IEnumerator bekleol()
    {
        yield return new WaitForSeconds(0.60f);
        anim.SetLayerWeight(1, 1f);
        anim.SetLayerWeight(2, 1f);
        anim.SetBool("die", true);
        minionspsc.giants[0].transform.parent.parent.transform.position -= new Vector3(0f, 2f, 0f);
        managersc.failoldu();
    }

    public void contine()
    {
        yenildi = false;
        calisti = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "bosenemy")
        {
            hesapla(other.transform.parent.gameObject);
        }

        if(other.tag == "Finish")
        {
            managersc.finish(anim);
            managersc.oyunudurdu();
            managersc.walk = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Finish")
        {
            cooldown = 0.15f;

            managersc.oyunudurdu();
            if (minionspsc.minionvalue <= 1)
            {
                managersc.walk = true;
                minionspsc.giants[0].GetComponent<Animator>().enabled = true;
                minionspsc.giants[1].GetComponent<Animator>().enabled = true;
                minionspsc.giants[2].GetComponent<Animator>().enabled = true;
                minionspsc.giants[3].GetComponent<Animator>().enabled = true;
            }
            else
            {
                timee += Time.deltaTime;
                managersc.walk = false;
                if(timee > cooldown)
                {
                    minionspsc.giants[0].GetComponent<Animator>().enabled = false;
                    minionspsc.giants[1].GetComponent<Animator>().enabled = false;
                    minionspsc.giants[2].GetComponent<Animator>().enabled = false;
                    minionspsc.giants[3].GetComponent<Animator>().enabled = false;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Finish")
        {
            managersc.walk = true;
        }
    }

    public void hesapla(GameObject obj)
    {
        enemybosssc enemybos = obj.GetComponent<enemybosssc>();

        if (minionspsc.giantvalue >= enemybos.guc)
        {
            mesafe = 4.5f;
            yenildi = false;
            enemybos.target = transform;
            targetbos = obj.transform;
        }
        else
        {
            minionspsc.giants[0].GetComponent<Animator>().applyRootMotion = false;
            minionspsc.giants[1].GetComponent<Animator>().applyRootMotion = false;
            minionspsc.giants[2].GetComponent<Animator>().applyRootMotion = false;
            minionspsc.giants[3].GetComponent<Animator>().applyRootMotion = false;
            mesafe = 0.1f;
            yenildi = true;
            managersc.oyunudurdu();
            enemybos.target = transform;
            targetbos = obj.transform;
        }
    }

}
