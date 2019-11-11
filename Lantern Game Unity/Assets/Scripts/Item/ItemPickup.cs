using UnityEngine;
using TMPro;

public class ItemPickup : Interactable
{
    public AudioClip chime;
    public override void Interact()
    {
        base.Interact();
        PickUp();   // Pick it up!
    }

    private void PickUp()
    {
        Debug.Log("Picking up ");
        bool wasPickedUp = true;   // Add to inventory
        AudioSource.PlayClipAtPoint(chime, transform.position);
        CandyManager.instance.Use();

        // If successfully picked up
        if (wasPickedUp)
            Destroy(gameObject);    // Destroy item from scene
    }

}
