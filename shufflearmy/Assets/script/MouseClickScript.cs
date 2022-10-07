using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickScript : MonoBehaviour {

    [SerializeField] private float ofsetilkposx;
    [SerializeField] private MinionSpawner scriptminion;
    [SerializeField] private menuler menusc;
    [SerializeField] private GameObject startpan;

    Vector2 ilkpos;
    bool start;

    void Start()
    {
        
    }

    void Update()
    {
        tiklama();
    }

    public void sag()
    {
        scriptminion.cucespawn();
    }

    public void sol()
    {
        scriptminion.cucesil();
    }

    public void tiklama()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ilkpos = Input.mousePosition;
        }

        if (Input.GetButton("Fire1"))
        {
            if(ilkpos.x < Input.mousePosition.x - ofsetilkposx)
            {
                if (!start)
                {
                    menusc.basla();
                    startpan.SetActive(false);
                    start = true;
                }
                else
                {
                    sag();
                }
            }

            if (ilkpos.x > Input.mousePosition.x + ofsetilkposx)
            {
                if (!start)
                {
                    menusc.basla();
                    startpan.SetActive(false);
                    start = true;
                }
                else
                {
                    sol();
                }
            }
        }
    }
}
