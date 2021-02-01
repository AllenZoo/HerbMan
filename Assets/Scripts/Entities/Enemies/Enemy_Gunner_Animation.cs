using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Gunner_Animation : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

}
