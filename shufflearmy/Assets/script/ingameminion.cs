using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingameminion : MonoBehaviour {

    [SerializeField] GameObject lekemavi, lekekirmizi, minionolanim, enemyminionolanim;

    MinionSpawner minionspsc;
    gamemanager managersc;
    triggerminions miniontri;

    Transform saldirobj, target, tg;
    Rigidbody rb;
    Animator anim;
    Vector3 cukur;

    public Vector3 ilkpos;
    public float dist, enyakin = 1000f, dusmanguc, hiz = 1500f;
    bool saldiriyor, dus, posayarlandi;

    private void Start()
    {
        minionspsc = GameObject.FindGameObjectWithTag("minionspawner").GetComponent<MinionSpawner>();
        managersc = GameObject.FindGameObjectWithTag("manager").GetComponent<gamemanager>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        miniontri = transform.parent.parent.transform.Find("Sphere").GetComponent<triggerminions>();
        rb = GetComponent<Rigidbody>();
        target = transform.parent;
    }

    public void posayarla(Vector3 pos)
    {
        if(!posayarlandi)
            ilkpos = pos;

        posayarlandi = true;
    }

    private void FixedUpdate()
    {
        if (dus)
        {
            rb.AddForce(cukur * hiz * Time.deltaTime);
        }
    }

    private void LateUpdate()
    {
        if (!saldiriyor && !dus && posayarlandi)
        {
            transform.position = Vector3.MoveTowards(transform.position, ilkpos, 5f * Time.deltaTime);
        }

        if (managersc.savas)
            saldirabilir();

        if (!managersc.savas && managersc.oyunbasladi == true)
            savasbitir();

        anim.SetBool("walk", managersc.walk);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy")
        {
            transform.GetComponent<CapsuleCollider>().enabled = false;
            transform.GetChild(0).transform.GetComponent<Animator>().enabled = false;
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            dus = true;
            hiz = 2000f;
            cukur = new Vector3(transform.localPosition.x, transform.localPosition.y - 2f, transform.localPosition.z + 1f);
            minionspsc.cuceyoket(transform.gameObject, false);
            StartCoroutine(beklesil());
        }
    }

    public void saldir(GameObject targetsaldir)
    {
        managersc.savas = true;
        dusmanguc = managersc.gucenemy;
        enyakindusmanbul(targetsaldir.transform);
        tg = targetsaldir.transform;
    }

    public void savasbitir()
    {
        enyakin = 1000f;
        saldiriyor = false;
        saldirobj = null;
        managersc.walk = true;
        tg = null;
    }

    public void enyakindusmanbul(Transform target)
    {
        List<Transform> listenemy = new List<Transform>();

        for (int i = 0; i < target.parent.transform.Find("cuceler").childCount; i++)
        {
            listenemy.Add(target.parent.transform.Find("cuceler").GetChild(i));
        }

        foreach (Transform item in listenemy)
        {
            dist = Vector3.Distance(transform.position, item.transform.position);

            if (dist < enyakin)
            {
                enyakin = dist;
                saldirobj = item;
                saldiriyor = true;
            }
        }
    }

    public void saldirabilir()
    {
        if (saldirobj != null)
        {
            if (minionspsc.minionvalue >= managersc.gucenemy)
            {
               
            }
            else if (minionspsc.minionvalue < managersc.gucenemy)
            {
                managersc.failoldu();
            }

            float dist = Vector3.Distance(transform.position, saldirobj.position);

            if (dist < 0.6f)
            {
                anim.SetBool("walk", false);

                if (managersc.gucenemy > 0f)
                {
                    managersc.gucenemy--;
                    anim.Play("ol");
                    minionspsc.cuceyoket(transform.gameObject, true);
                    GameObject objleke1 = Instantiate(lekemavi, transform.position - new Vector3(0f, 0.25f, 0f), Quaternion.identity);
                    GameObject objleke2 = Instantiate(lekekirmizi, saldirobj.position - new Vector3(0f, 0.25f, 0f), Quaternion.identity);
                    objleke1.transform.SetParent(managersc.yersc.GetComponent<yer>().yerparettr.transform);
                    objleke2.transform.SetParent(managersc.yersc.GetComponent<yer>().yerparettr.transform);
                    saldirobj.transform.GetChild(0).GetComponent<Animator>().Play("ol");
                    saldirobj.GetComponent<dusmanminion>().listedusman.Remove(transform.gameObject);
                    miniontri.minionlist.Remove(saldirobj.gameObject);
                    GameObject olanmi1 = Instantiate(minionolanim, transform.position, Quaternion.identity);
                    GameObject olanmi2 = Instantiate(enemyminionolanim, saldirobj.position, Quaternion.identity);
                    olanmi1.transform.SetParent(managersc.yersc.GetComponent<yer>().yerparettr.transform);
                    olanmi2.transform.SetParent(managersc.yersc.GetComponent<yer>().yerparettr.transform);
                    saldirobj.parent.parent.GetComponent<miniongroupsc>().cucesil(saldirobj.gameObject);
                    minionspsc.cucepossifirla();
                }
                else
                {
                    miniontri.minionlist.Remove(saldirobj.gameObject);
                    saldirobj.parent.parent.GetComponent<miniongroupsc>().cucesil(saldirobj.gameObject);
                }
            }
            else
            {
                Vector3 pos = saldirobj.position - transform.position;
                rb.AddForce(pos * 4000f * Time.deltaTime);
                anim.SetBool("walk", true);
            }
        }
        else
        {
            if (dusmanguc > 0f && tg != null)
                enyakindusmanbul(tg);
        }
    }

    IEnumerator beklesil()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
