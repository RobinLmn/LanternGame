using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CandyManager : MonoBehaviour

{
    private int lantern_number;
    public Animator animator;
    public TextMeshProUGUI scoreText;

    public static CandyManager instance;

    private void Awake()
    {
        if (instance != null)
            Debug.Log("More than one manager");
        instance = this;

        lantern_number = 0;
    }

    private void Start()
    {
        SetScoreText();
    }

    public void Use()
    {
        IncreaseLantern();
        SetScoreText();
    }

    private void SetScoreText()
    {
        scoreText.text = lantern_number.ToString();
    }

    private void IncreaseLantern()
    {
        Debug.Log("IncreaseLantern");
        lantern_number += 1;
        animator.SetInteger("lanternlevel", lantern_number);
    }

}
