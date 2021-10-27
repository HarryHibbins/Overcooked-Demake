using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractables : MonoBehaviour
{

    public GameObject RaycastObject;
    private float rayLength = 0.5f;
    public LayerMask Interactables;

    public bool canUseCB;
    public bool canUseWT;
    public bool canUseBin;



    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(RaycastObject.transform.position,
            RaycastObject.transform.TransformDirection(Vector3.up),
            rayLength, Interactables);

        if (hit.collider != null)
        {
            
            
            if (hit.collider.tag == "ChoppingBoard")
            {
                canUseCB = true;
            }
            else if (hit.collider.tag == "Worktop")
            {
                canUseWT = true;
            }
            else if (hit.collider.tag == "Bin")
            {
                canUseBin = true;
            }

        }
        else
        {
            canUseCB = false;
            canUseWT = false;
            canUseBin = false;
        }


        
    }
    
    
}
