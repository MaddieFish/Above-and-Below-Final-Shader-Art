using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateDetection : MonoBehaviour
{
    public Animator flyingFishAnimController;
    public bool underwater = true;
    // Start is called before the first frame update
    void Start()
    {
        print("Script Initiated");
        flyingFishAnimController = gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Water"))
        {
            print("Underwater");
            underwater = true;
            flyingFishAnimController.SetBool("Underwater", true);
        }

    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Water"))
        {
            print("Sky");
            underwater = false;
            flyingFishAnimController.SetBool("Underwater", false);
        }

    }
}

