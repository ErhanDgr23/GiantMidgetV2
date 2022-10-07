using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giantingame : MonoBehaviour {

    [HideInInspector] public Animator anim;
    [HideInInspector] public AvatarMask mask;

    gamemanager managersc;

    void Start()
    {
        managersc = GameObject.FindGameObjectWithTag("manager").GetComponent<gamemanager>();
        anim = transform.GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("walk", managersc.walk);
    }
}
