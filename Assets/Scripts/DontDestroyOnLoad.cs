using UnityEngine;
using System.Collections;

public class DontDestroyOnLoad : MonoBehaviour {
    static bool oneExists = false;

    void Awake()
    {
        if (!oneExists)
        {
            oneExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
