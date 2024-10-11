using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeFade : MonoBehaviour
{
    private new MeshRenderer renderer;
    private Color color = new(1f, 0.518f, 0f, 0f);
    [SerializeField] private float fadeSpeed;
    private float alphaVal;

    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.material.SetColor("_Color", color);
    }

    // Update is called once per frame
    void Update()
    {
        alphaVal += Time.deltaTime * fadeSpeed;
        renderer.material.SetFloat("_Alpha", alphaVal);

        Debug.Log(renderer.material.GetFloat("_Alpha"));
    }
}
