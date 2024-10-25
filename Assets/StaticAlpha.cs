using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticAlpha : MonoBehaviour
{
    // Start is called before the first frame update
    public Material Static;

    [Range(0f,1f)] 
    public float Scale = 1f;
    Color myColor;
    void Start()
    {
        myColor = Static.color;
    }

    // Update is called once per frame
    void Update()
    {
        myColor.a = Scale;
        Static.color = new Color(Static.color.r, Static.color.g, Static.color.b, Scale);
    }
}
