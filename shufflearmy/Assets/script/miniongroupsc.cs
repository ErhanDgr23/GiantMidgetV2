using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class miniongroupsc : MonoBehaviour {

    public float guc;

    [SerializeField] private List<GameObject> enemyminionlist = new List<GameObject>();
    [SerializeField] private TextMeshProUGUI textguc;

    gamemanager managersc;

    public void Start()
    {
        managersc = GameObject.FindGameObjectWithTag("manager").GetComponent<gamemanager>();

        foreach (GameObject item in enemyminionlist)
        {
            Animator anim = item.transform.GetChild(0).GetComponent<Animator>();

            anim.SetBool("walk", false);
        }
    }

    private void Update()
    {
        textguc.text = guc.ToString();

        if (guc <= 0f)
        {
            textguc.transform.parent.parent.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            managersc.savas = false;
            managersc.oyunudeavm();
        }
        else
        {
            if (managersc.savas == true)
            {
                managersc.savas = true;
            }
        }
    }

    public void cucesil(GameObject obj)
    {
        Destroy(obj);
        enemyminionlist.Remove(obj);
        guc--;
    }

    public void OnTriggerEnter(Collider other)
    {
        
    }
}
