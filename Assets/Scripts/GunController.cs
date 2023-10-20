using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public Transform cam;
    public float maxDistance;
    public LayerMask whatIsShootable;
    public float damages;
    public ParticleSystem _particleSystem;
    public Animator animator;

    private bool canShoot;

    private void Start()
    {
        Recharge();
    }

    void Update()
    {
        if (canShoot && Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("bam");
        canShoot = false;
        _particleSystem.Play();
        animator.SetBool("isShooting", true);

        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxDistance, whatIsShootable))
        {
            HealthBar hb = hit.transform.gameObject.GetComponent<HealthBar>();
            if (hb != null)
            {
                hb.GetDamages(20f);
            }
        }
    }

    public void Recharge()
    {
        canShoot = true;
        animator.SetBool("isShooting", false);
    }
}
