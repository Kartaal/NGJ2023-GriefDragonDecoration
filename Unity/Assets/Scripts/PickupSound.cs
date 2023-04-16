using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PickupSound : MonoBehaviour
{
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioSource s = GetComponent<AudioSource>();
        s.Play();
        rend.enabled = false;
        Destroy(gameObject, s.clip.length);
    }
}
