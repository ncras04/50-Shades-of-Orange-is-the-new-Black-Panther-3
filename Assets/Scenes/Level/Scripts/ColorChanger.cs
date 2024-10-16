using System;
using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour, INotifyProperty<Color>
{
    public event Action<Color> PropertyChanged;

    private Material m_skyboxMaterial;

    private PlayerBeha m_player;



    [SerializeField]
    private Color m_beginColor;

    [SerializeField]
    private Color m_endColor;

    [SerializeField]
    private float m_currentPos;
    private void Awake()
    {
        m_skyboxMaterial = RenderSettings.skybox;
    }

    private void OnEnable()
    {
        if (m_player is null)
            m_player = FindObjectOfType<PlayerBeha>();

        m_player.PropertyChanged += OnPlayerPositionChanged;
    }

    private void OnDisable()
    {
        m_player.PropertyChanged -= OnPlayerPositionChanged;
    }

    public void OnPlayerPositionChanged(float _playerPos)
    { 
        StartCoroutine(SetBGColor(_playerPos));
    }

    private IEnumerator SetBGColor(float _playerPos)
    {
        float TIME = 0.0f;
        Vector2 currentVal = new Vector2(m_currentPos, 0);
        Vector2 tgtVal = new Vector2(_playerPos, 0);
        Vector2 vel = Vector2.zero;
        Color resultColor = Color.black;
        float smoothTime = 0.5f;

        while (TIME < 0.7f)
        {
            currentVal = Vector2.SmoothDamp(currentVal, tgtVal, ref vel, smoothTime);

            resultColor = Color.Lerp(m_endColor, m_beginColor, currentVal.x);
            m_skyboxMaterial.SetColor("_ColorMax", resultColor);
            PropertyChanged?.Invoke(resultColor);

            TIME += Time.deltaTime;
            Debug.Log(TIME);
            yield return null;
        }

        m_currentPos = _playerPos;
    }

}


