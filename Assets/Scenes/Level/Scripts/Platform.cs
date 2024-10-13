using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float Distance
    {
        get => m_distance;
        private set
        {
            m_distance = value;
        }
    }

    [SerializeField]
    private float m_distance;

    [SerializeField]
    private Color m_color;

    public Color Color
    {
        get => m_color;
        private set
        {
            m_color = value;
        }
    }

    private ColorChanger m_colorChanger;

    private void Start()
    {
        Transform startPlatform = GameObject.FindGameObjectWithTag("StartPos").transform;
        Transform endPlatform = GameObject.FindGameObjectWithTag("EndPos").transform;


        if (startPlatform is not null)
            m_distance = Vector3.Distance(transform.position, startPlatform.position) / Vector3.Distance(startPlatform.position, endPlatform.position);

        GetComponent<MeshRenderer>().material.SetColor("_Color", m_color);
    }

    private void OnEnable()
    {
        if (m_colorChanger is null)
            m_colorChanger = FindObjectOfType<ColorChanger>();

        m_colorChanger.PropertyChanged += OnColorChanged;
    }

    private void OnDisable()
    {
        m_colorChanger.PropertyChanged -= OnColorChanged;
    }

    private void OnColorChanged(Color _currentBGColor)
    {
        if (m_color.grayscale <= _currentBGColor.grayscale)
        {
            gameObject.SetActive(false);
        }

    }



}
