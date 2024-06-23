using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCube : Interactable
{
    public GameObject colectible;
    protected override void Interact()
    {
       Destroy(gameObject);
        Instantiate(colectible, transform.position, Quaternion.identity);
    }
}
