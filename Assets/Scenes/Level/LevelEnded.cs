using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnded : MonoBehaviour
{
    public GameManager manager;
    public int nextScene;
    private void OnCollisionEnter(Collision collision)
    {
        manager.LoadScene(nextScene);
    }


}
