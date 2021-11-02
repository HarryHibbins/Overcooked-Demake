using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    public PlayerInventory PlayerInventory;
    private GameObject player;
    private bool inBox;
    private PlayerInteractables playerInteractables;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerInventory = player.GetComponent<PlayerInventory>();
        playerInteractables = player.GetComponent<PlayerInteractables>();

    }

    void Update()
    {
        // If player is holding item, then remove it and update the player's hand.
        if (inBox && playerInteractables.canUseBin && Input.GetButtonDown("Interact") && PlayerInventory.holdingItem)
        {
            PlayerInventory.ClearHand();
            PlayerInventory.holdingItem = false;
            FindObjectOfType<AudioManager>().Play("Bin");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform == player.transform)
        {
            inBox = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.transform == player.transform)
        {
            inBox = false;
        }
    }
}
