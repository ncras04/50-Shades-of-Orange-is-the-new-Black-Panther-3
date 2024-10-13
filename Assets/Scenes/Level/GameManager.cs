using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Renderer renderer;



    float t = 1;
    public void LoadScene(int _sceneNumber)
    {
        StartCoroutine(FadeWithLoad(_sceneNumber));
    }

    private void Start()
    {
        StartCoroutine(Fade());
    }

    public IEnumerator FadeWithLoad(int _sceneNumber)
    {
        while (t < 1.0)
        {
            renderer.material.SetFloat("_t", Mathf.Lerp(0, 1, t));
            t += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(_sceneNumber);
    }

    public IEnumerator Fade()
    {
        if (t == 1.0f)
        {
            while (t > 0)
            {
                renderer.material.SetFloat("_t", Mathf.Lerp(0, 1, t));
                t -= Time.deltaTime;
                yield return null;
            }
        }
        else
        {
            while (t < 1.0)
            {
                renderer.material.SetFloat("_t", Mathf.Lerp(0, 1, t));
                t += Time.deltaTime;
                yield return null;
            }
        }

    }

}
