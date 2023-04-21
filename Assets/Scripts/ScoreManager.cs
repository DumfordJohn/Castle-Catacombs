using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int amount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            print("Duplicated ScoreManager, ignoring this one");
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
