using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {  
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            scoreText.text = "" + float.Parse(scoreText.text) + other.GetComponent<scoreScript>().scoreVal;
        }
    }
}
