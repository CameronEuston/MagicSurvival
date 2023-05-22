using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        //Implement the singleton design
        if (instance != null)
            Destroy(gameObject);

        instance = this;
    }
}
