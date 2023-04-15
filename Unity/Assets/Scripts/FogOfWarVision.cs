using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWarVision : MonoBehaviour
{
    public KidCharacterController player;
    private Texture2D fogTexture;

    private void Awake()
    {
        fogTexture = new Texture2D(1024,1024);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
