using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public static EnemiesManager instance;
    public List<Enemy> enemies;
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
            print("Duplicated EnemiesManager, ignoring this one");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
