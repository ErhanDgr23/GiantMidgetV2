using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duvar : MonoBehaviour {

    public float kackerekir;

    [SerializeField] private finalbossc bossc;
    [SerializeField] private gamemanager managersc;
    [SerializeField] private float duz, don;

    Animator anim;
    float kirmasayi;
    public bool girdi, girdi2;
    float zmn, cool = 2f;

    private void Start()
    {
        anim = bossc.transform.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(zmn > cool)
        {
            girdi = false;
            Time.timeScale += (1f / 0.3f) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            girdi2 = false;
        }

        if (girdi2)
        {
            zmn += Time.unscaledDeltaTime;
        }

        if (girdi)
        {
            Time.timeScale = 0.3f;
            Time.fixedDeltaTime = Time.timeScale * .02f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "kir")
        {
            if(kackerekir > kirmasayi)
            {
                if (kirmasayi >= kackerekir - 2f)
                {
                    girdi2 = true;
                    girdi = true;
                }

                kirmasayi++;
                anim.Play("finalbosfirlaanim");
                other.GetComponent<MeshRenderer>().enabled = false;
                other.transform.GetChild(0).gameObject.SetActive(true);
                other.transform.GetChild(1).gameObject.SetActive(false);
                StartCoroutine(bekledeaktif(other.transform.GetChild(0).gameObject));
                transform.eulerAngles = new Vector3(-90f, 0f, 0f);
                StartCoroutine(bekledon());
            }
            else
            {
                bossc.enabled = false;
                anim.Play("oldu");
                StartCoroutine(beklebitti());
            }
        }
    }

    IEnumerator bekledon()
    {
        yield return new WaitForSeconds(0.5f);
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }

    IEnumerator bekledeaktif(GameObject obj)
    {
        yield return new WaitForSeconds(1f);
        obj.gameObject.SetActive(false);
    }

    IEnumerator beklebitti()
    {
        yield return new WaitForSeconds(2.5f);
        managersc.winekran(kackerekir);
    }
}
