using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playRecoilAnim : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;

    //private void OnTriggerEnter(shootGun)
    //{
        //if (other.CompareTag("player"))
        //{
            //myAnimationController.SetBool("playRecoil", true);
        //}
    //}
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            myAnimationController.SetBool("playRecoil", false);
        }
    }
}
