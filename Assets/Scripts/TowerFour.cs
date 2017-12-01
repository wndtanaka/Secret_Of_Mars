using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFour : Tower {

    AudioSource fireBallSound;

    private void Awake()
    {
        fireBallSound = GameObject.Find("FireBallSound").GetComponent<AudioSource>(); 
    }

    protected override void Start()
    {
        attackTimer = 3f;
        base.Start();
    }
    // Use this for initialization
    protected override void Attack()
    {
        GameObject fireball = Instantiate(bulletPrefab, target.position + new Vector3(0,20f,0), firePoint.rotation) as GameObject;
        WeaponFireBall projectile = fireball.GetComponent<WeaponFireBall>();
        //projectile.direction = target.position - transform.position;
        if (projectile != null)
        {
            fireBallSound.Play();
            projectile.Fire(target);
        }
    }
}
