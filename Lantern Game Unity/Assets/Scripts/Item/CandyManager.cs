using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyManager : MonoBehaviour

{
    private int lantern_number;
    public Animator animator;

    public static CandyManager instance;

    private void Awake()
    {
        if (instance != null)
            Debug.Log("More than one manager");
        instance = this;

        lantern_number = 0;
    }

    public void Use()
    {
        IncreaseLantern();
    }

    private void IncreaseLantern()
    {
        Debug.Log("IncreaseLantern");
        lantern_number += 1;
        animator.SetInteger("lanternlevel", lantern_number);
    }

}
