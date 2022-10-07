using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class menuler : MonoBehaviour {

    [SerializeField] private GameObject clickmanager, yer, respan, winpan;
    [SerializeField] private TextMeshProUGUI textescore, textlevel, textmoney, textscorewin;
    [SerializeField] private gamemanager managersc;
    [SerializeField] private MinionSpawner minionsp;
    [SerializeField] private triggermenu tri;

    [SerializeField] GameObject[] giantsc;

    [HideInInspector] public bool die;

    bool birkere;

    private void Awake()
    {
        managersc.oyundurdurstart();
        managersc.walk = false;
        managersc.oyunbasladi = false;
    }

    private void Start()
    {
        currentlevel();
    }

    private void Update()
    {
        textescore.text = minionsp.giantvalue + minionsp.minionvalue + "";

        if (managersc.failolb && !birkere)
        {
            StartCoroutine(beklefail());
            die = true;
            birkere = true;
        }
    }

    public void currentlevel()
    {
        textlevel.text = "Level " + PlayerPrefs.GetFloat("level");
    }


    IEnumerator beklefail()
    {
        yield return new WaitForSeconds(1f);
        failol();
        tri.b = true;
    }

    public void win(float puan)
    {
        winpan.gameObject.SetActive(true);
        textmoney.text = puan * 100f + "";
        textscorewin.text = minionsp.giantvalue + minionsp.minionvalue + "";
    }

    public void nextlevel()
    {
        PlayerPrefs.SetFloat("level", PlayerPrefs.GetFloat("level") + 1f);
        restartgame();
    }

    public void basla()
    {
        clickmanager.gameObject.SetActive(true);
        yer.gameObject.SetActive(true);
        managersc.oyunbasladi = true;
        managersc.walk = true;
        managersc.oyunudeavm();
    }

    public void restartgame()
    {
        Application.LoadLevel(0);
    }

    public void failol()
    {
        
        managersc.failolb = false;
        managersc.oyunudurdu();
        respan.SetActive(true);
    }

    public void contine()
    {
        foreach (GameObject item in giantsc)
        {         
            item.GetComponent<Animator>().Play("idle");
        }

        tri.b = false;
        managersc.devamet = false;
        birkere = false;
        minionsp.giantvalue += 10f;
        minionsp.cucebaslaolustur(10);
        respan.SetActive(false);
        managersc.oyunudeavm();
    }
}
