using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybosssc : MonoBehaviour {

    public float guc;
    public Transform target;
    public GameObject canvas;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        if (target != null)
        {
            anim.SetBool("walk", true);
            Vector3 pos = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.position = Vector3.MoveTowards(transform.position, pos, 10f * Time.deltaTime);
        }
        else
        {

        }
    }

    public void yumrukat()
    {
        anim.Play("punch");
    }

    public void ol()
    {
        canvas.gameObject.SetActive(false);
        transform.Find("ragdoll").gameObject.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
