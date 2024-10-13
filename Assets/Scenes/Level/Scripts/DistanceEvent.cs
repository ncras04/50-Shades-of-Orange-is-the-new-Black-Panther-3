using System;
using UnityEngine;

public class DistanceEvent : MonoBehaviour, INotifyProperty<float>
{
    public event Action<float> PropertyChanged
    {
        add
        {
            m_distanceChanged -= value;
            m_distanceChanged += value;
        }
        remove
        {
            m_distanceChanged -= value;
        }
    }

    private event Action<float> m_distanceChanged;

    private float m_distance;
    private float m_maxDistance;

    public float DistanceFromStart
    {
        get => m_distance;
        set
        {
            if(m_distance != value)
            {
                m_distance = value;
                float currentDistance = m_distance / m_maxDistance;
                if (currentDistance > 1)
                    currentDistance = 1;
                m_distanceChanged.Invoke(currentDistance);
            }
        }
    }

    private Transform m_playerPos;
    private Transform m_startPos;
    private Transform m_endPos;

    private void Start()
    {
        m_playerPos = FindObjectOfType<PlayerBeha>().transform;
        m_startPos = GameObject.FindGameObjectWithTag("Start").transform;
        m_endPos = GameObject.FindGameObjectWithTag("End").transform;

        m_maxDistance = Vector3.Distance(m_startPos.position, m_endPos.position);

    }

    private void OnPlayerPosChanged()
    {

    }

}
