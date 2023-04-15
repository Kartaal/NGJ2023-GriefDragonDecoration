using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FogOfWarVision : MonoBehaviour
{
    public KidCharacterController player;
    public MeshRenderer meshRenderer;
    private Texture2D fogTexture;

    private float fogYLevel;

    private void Awake()
    {
        fogYLevel = meshRenderer.gameObject.transform.position.y;
        
        fogTexture = Texture2D.blackTexture;
        meshRenderer.material.mainTexture = fogTexture;

        Color[] cols = fogTexture.GetPixels(0);
        for (int i = 0; i < cols.Length; i++)
        {
            Color c = cols[i];
            c.a = 1f;

            cols[i] = c;
        }
        
        fogTexture.SetPixels(cols);
        fogTexture.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        var toWorld = player.transform.localToWorldMatrix;
        
        var vision = player.GetComponent<CapsuleCollider>();
        var bounds = vision.bounds;
        var minWorld = toWorld * bounds.min;
        var maxWorld = toWorld * bounds.max;

        var texPixels = fogTexture.GetPixels();

        var texWidth = fogTexture.width;
        var texHeight = fogTexture.height;

        for (int x = 0; x < texWidth; x++)
        {
            for (int y = 0; y < texHeight; y++)
            {
                if (TestInsideBounds(x, y, minWorld, maxWorld))
                {
                    var col = texPixels[x + y * texWidth];
                    col.a = 0.2f;
                    texPixels[x + y * texWidth] = col;
                }
            }
        }
        
        fogTexture.SetPixels(texPixels);
        fogTexture.Apply();
    }


    private bool TestInsideBounds(int x, int y, Vector4 minBounds, Vector4 maxBounds)
    {
        return (x >= minBounds.x && x <= maxBounds.x &&
                y >= minBounds.y && y <= maxBounds.y);
    }
}
