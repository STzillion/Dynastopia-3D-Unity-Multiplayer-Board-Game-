using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleEmissionTest : MonoBehaviour
{
    public Material material; // Drag and drop your material in the inspector

    void Start()
    {
        // Ensure that a material is assigned
        if (material == null)
        {
            Debug.LogError("Material not assigned!");
            return;
        }
    }

    void Update()
    {
        // Toggle emission on key press (you can change this condition)
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleEmissionOn();
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            ToggleEmissionOff();
        }
    }

    void ToggleEmissionOn()
    {
        // Toggle between emission on and off
        material.EnableKeyword("_EMISSION");
        material.globalIlluminationFlags ^= MaterialGlobalIlluminationFlags.RealtimeEmissive;
        material.SetColor("_EmissionColor", Color.grey); // You can change this color if needed
    }
    void ToggleEmissionOff()
    {
        // Toggle between emission on and off
        material.EnableKeyword("_EMISSION");
        material.globalIlluminationFlags ^= MaterialGlobalIlluminationFlags.RealtimeEmissive;
        material.SetColor("_EmissionColor", Color.yellow); // You can change this color if needed
    }
}
