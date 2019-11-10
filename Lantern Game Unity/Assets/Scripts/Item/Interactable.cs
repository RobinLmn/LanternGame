using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    public float radius = 0.1f;               // How close do we need to be to interact?
    public Transform interactionTransform;  // The transform from where we interact in case you want to offset it
    public Transform player;


    // Update is called once per frame
    public void Update()
    {
        float distance = Vector3.Distance(player.position, interactionTransform.position);

        if (distance <= radius)
        {
            // Interact with the object
            Interact();
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interact with" + name);
    }

    // Pick up the item


    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

}
