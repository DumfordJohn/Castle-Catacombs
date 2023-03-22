using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class playerShooting : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootPoint;
    public GameObject gun;
    public Animator reloadAnim;
    public float magSize;

    void Start()
    {
        reloadAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            magSize -= 1;
            if (magSize > 0)
            {
                Instantiate(prefab, shootPoint.transform.position, shootPoint.transform.rotation);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            reloadAnim.Play("reload");
            magSize = 5;
        }
    }
}
