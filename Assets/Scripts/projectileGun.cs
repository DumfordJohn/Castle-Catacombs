using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class projectileGun : MonoBehaviour
{
    //bullet
    public GameObject playerBullet;

    //bullet force
    public float shootForce, upwardsForce;

    //Gun stats
    public float timeBetweenShooting, spread, reloadTime, emptyReloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;

    //bools
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;

    //Graphics
    public GameObject MuzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

    //Animator
    public Animator animator;

    //bug fixing
    public bool allowInvoke = true;

    private void Awake()
    {
        //make sure magazin is full
        bulletsLeft = magazineSize;
        readyToShoot = true;

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MyInput();

        //Set ammo display, if it exists
        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);
    }
    private void MyInput()
    {
        //check if allowed to hold down button and take corresponding input
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Reloading
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading && bulletsLeft > 0)
        {
            Reload();
            animator.SetTrigger("reload");
        }
        //Reloading with 0 bullets
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft == 0 && !reloading)
        {
            EmptyReload();
            animator.SetTrigger("emptyReload");
        }
        //Reload automatically when trying to shoot without ammo
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0)
        {
            EmptyReload();
            animator.SetTrigger("emptyReload");
        }

        //Shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //set bullets shot to 0
            bulletsShot = 0;

            Shoot();
            animator.SetTrigger("recoil");
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        //Find the exact hit position using a raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        //check if ray hnits something
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); //Just a point far away from the player

        //Calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //Calcuate spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calcuate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //Just add spread to last direction

        //Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(playerBullet, attackPoint.position, Quaternion.identity); //store instant

        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardsForce, ForceMode.Impulse);

        //Instantiate muzzle flash, if you have one
        if (MuzzleFlash !=null)
            Instantiate(MuzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot++;

        //Invoke resetShot function (if not already invoked
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        //if more than one bulletsPerTap make sure to repeat shoot function
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        //Allow shooting and invoking again
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void EmptyReload()
    {
        reloading = true;
        Invoke("ReloadFinished", emptyReloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
