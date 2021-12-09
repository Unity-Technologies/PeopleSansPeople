using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOutfit : MonoBehaviour
{
    public Material clothingColour;
    public Texture2D sampleTexture;
    public Texture2D sampleMask;
    public Texture2D sampleNormal;
    public float hueTop = 0.0f;
    public float hueBottom = 0.0f;

    void Start()
    {
        //characterMaterial.Sample().SetTexture("Texture2D_D27E6D66", albedoTexture.Sample());
        //characterMaterial.Sample().SetTexture("Texture2D_A2664602", normalTexture.Sample());
        //characterMaterial.Sample().SetTexture("Texture2D_A8936B7E", maskTexture.Sample());
        //characterMaterial.Sample().SetFloat("Vector1_46FBBF67", m_FloatParameter.Sample());
        //characterMaterial.Sample().SetFloat("Vector1_4EA3F53", m_FloatParameter.Sample());

        clothingColour.SetTexture("Texture2D_D27E6D66", sampleTexture);
        clothingColour.SetTexture("Texture2D_A2664602", sampleMask);
        clothingColour.SetTexture("Texture2D_A8936B7E", sampleNormal);
        clothingColour.SetFloat("Vector1_46FBBF67", hueTop);
        clothingColour.SetFloat("Vector1_4EA3F53", hueBottom);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            clothingColour.SetTexture("Texture2D_D27E6D66", sampleTexture);
            clothingColour.SetTexture("Texture2D_A2664602", sampleMask);
            clothingColour.SetTexture("Texture2D_A8936B7E", sampleNormal);
            hueTop += 10.0f;
            hueBottom -= 10.0f;
            clothingColour.SetFloat("Vector1_46FBBF67", hueTop);
            clothingColour.SetFloat("Vector1_4EA3F53", hueBottom);

        }
    }
}
