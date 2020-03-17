using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    Material material;

    public bool isDissolving = true;
    public float fade = 0f;

    public static Dissolve Instance;

    public void Start()
     {
       // Get a reference to the material
        material = GetComponent<SpriteRenderer>().material;
     }

    public void Update()
    {
        Reappear();
    }

    public void Reappear()
    {
        fade += Time.deltaTime;

        if (fade >= 1f)
        {
            fade = 1f;
            isDissolving = true;
        }
        // Set the property
        material.SetFloat("_Fade", fade);
    }
 }