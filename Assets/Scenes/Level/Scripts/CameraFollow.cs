using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform m_player;
    [SerializeField]
    private float smoothTime;
    private Vector3 currentVelocity;

    private PlayerBeha player;

    private Vector3 offset = new Vector3(0.0f, -2.0f, 0.0f);
    private float offsetMult = 1;

    private void OnEnable()
    {
        if (player is null)
            player = FindObjectOfType<PlayerBeha>();

        player.PropertyChanged += OnPlayerGrounded;
    }

    private void OnDisable()
    {
        player.PropertyChanged -= OnPlayerGrounded;
    }



    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, m_player.position + (offset * offsetMult), ref currentVelocity, smoothTime);
    }

    private void OnPlayerGrounded(float _)
    {
        StartCoroutine(GroundOffset());
    }

    private IEnumerator GroundOffset()
    {
        float t = 1;

        while (t > 0)
        {
            offsetMult = Mathf.Lerp(0.0f, 1.0f, t);
            t -= Time.deltaTime;
            yield return null;
        }

    }
}
