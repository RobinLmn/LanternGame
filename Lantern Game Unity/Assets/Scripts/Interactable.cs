using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;               // How close do we need to be to interact?
    public Transform interactionTransform;  // The transform from where we interact in case you want to offset it
    public Transform player;
    public int lantern_number;
    public Animator animator;
    public TextMeshProUGUI scoreText;


    public void Awake()
    {
        lantern_number = 0;
        SetScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, interactionTransform.position);

        if ((distance <= radius) && Input.GetKeyDown(KeyCode.E))
        {
            // Interact with the object
            Interact();
        }
    }

    private void Interact()
    {
        IncreaseLantern();
        PickUp();   // Pick it up!
        SetScoreText();
    }

    // Pick up the item
    void PickUp()
    {
        Debug.Log("Picking up Candy");
        bool wasPickedUp = true;

        // If successfully picked up
        if (wasPickedUp)
            Destroy(gameObject);    // Destroy item from scene
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

    private void IncreaseLantern()
    {
        Debug.Log("IncreaseLantern");
        lantern_number += 1;
        animator.SetInteger("lanternlevel", lantern_number);
    }

    private void SetScoreText()
    {
        scoreText.text = lantern_number.ToString();
    }
}
