using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;               // How close do we need to be to interact?
    public Transform interactionTransform;  // The transform from where we interact in case you want to offset it
    public Transform player;

    public virtual void Interact()
    {
        // This method is meant to be overwritten
        Debug.Log("Interacting with " + transform.name);
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }


}
