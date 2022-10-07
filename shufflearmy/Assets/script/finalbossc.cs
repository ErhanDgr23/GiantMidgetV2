using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalbossc : MonoBehaviour {

    [SerializeField] GameObject animliobj, animsiz;
    [SerializeField] Transform campos;
    [SerializeField] Vector3 direction, ofset;
    [SerializeField] float hiz;

    public bool vuruldu;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        idlegec();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "duvar")
        {
            carpti();
        }
    }

    public void carpti()
    {
        anim.Play("hit");
    }

    public void idlegec()
    {
        anim.Play("idle");
    }

    private void Update()
    {
        if (vuruldu)
        {
            transform.Translate(direction * hiz * Time.deltaTime);
        }
    }

    public void vurdu()
    {
        vuruldu = true;
    }

}
