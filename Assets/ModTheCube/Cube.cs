using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    
    public float duration = 5.0f; // Time taken for each color transition

    private int colorIndex = 0;
    private float startTime;

  

    public Color[] colors = new Color[]
{
    new Color(1.0f, 0.0f, 0.0f, 0.05f), // Red
    new Color(0.0f, 1.0f, 0.0f, 0.05f), // Green
    new Color(0.0f, 0.0f, 1.0f, 0.05f), // Blue
    new Color(1.0f, 1.0f, 0.0f, 0.05f), // Yellow
    // Add more colors as needed
};


    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        Material material = Renderer.material;

        material.color = colors[0];
        startTime = Time.time;
    }

    void Update()
    {
        // Calculate the lerp value based on time
        float t = (Time.time - startTime) / duration;
        // Set the color using Lerp
        Renderer.material.color = Color.Lerp(colors[colorIndex], colors[(colorIndex + 1) % colors.Length], t);

        if (t >= 1.0f)
        {
            // Reset the start time for the next color transition
            startTime = Time.time;
            // Move to the next color in the array
            colorIndex = (colorIndex + 1) % colors.Length;
        }

        transform.Rotate(10.0f * Time.deltaTime, 0.15f, 0.0f);

        
    }
}

