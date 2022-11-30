using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        // Finds ButtonManager gameobject from scene.
        GameObject[] objs = GameObject.FindGameObjectsWithTag("ButtonManager");

        // Removes all other gameobjects with same name.
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        // Keeps gameobject alive
        DontDestroyOnLoad(this.gameObject);
    }
}
