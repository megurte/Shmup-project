﻿using System.Collections;
using System.Runtime;
using System.Collections.Generic;
using UnityEngine;

public struct FireballCircle
{
    public float Time;
    public bool Change;
    public GameObject Bullet;
    public int Count;
}

public class Kirin_script : MonoBehaviour
{
    //Bullets
    public GameObject fireball;
    public GameObject timedFireball;
    public GameObject fireballSmall;
    public GameObject icicle;

    //Bullet spawn
    private GameObject InstObject;
    public float distance = 2;
    public float angle = 360;

    private void Start()
    {
        StartCoroutine(Test(1, true, timedFireball, 32));
        StartCoroutine(Test(2, true, timedFireball, 32));
        StartCoroutine(Test(3, false, timedFireball, 32));
        StartCoroutine(WaitForCircleFireball(4, false, fireballSmall, 28));
        StartCoroutine(WaitForCircleFireball(5, true, fireball, 24));
        StartCoroutine(WaitForCircleFireball(6, false, fireballSmall, 26));
        StartCoroutine(WaitForCircleFireball(7, true, fireball, 26));
        StartCoroutine(WaitForCircleFireball(8, true, fireball, 15));
        StartCoroutine(WaitForCircleFireball(9, false, fireball, 18));
        StartCoroutine(WaitForCircleFireball(10, true, fireballSmall, 32));
        StartCoroutine(WaitForCircleFireball(11, false, fireball, 40));
        StartCoroutine(WaitForCircleFireball(12, false, fireball, 20));
        StartCoroutine(WaitForCircleFireball(13, true, fireball, 14));
    }

    private void FireballSpiral(bool change, GameObject bullet, float count, float multiplication)
    {
        Vector2 point = transform.position;
        Vector2 direction = new Vector2(-1, 1);

        angle = angle * Mathf.Deg2Rad;
        for (int i = 1; i <= count; i++)
        {
            float y = transform.position.y + Mathf.Cos(angle / count * i) * distance;
            float x = transform.position.x + Mathf.Sin(angle / count * i) * distance;
            point.x = x;
            point.y = y;

            float dirY = Mathf.Cos(angle / count * i);
            float dirX = Mathf.Sin(angle / count * i);
            direction.x = dirX;
            direction.y = dirY;
            Test(point, direction, change, bullet);
        }
        angle = 360;      
    }
    
    private void FireballSpellLeftToRight(bool change, GameObject bullet, int count)
    {

        Vector2 point = transform.position;
        Vector2 direction = new Vector2(-1, 1);

        angle = angle * Mathf.Deg2Rad;
        for (int i = 1; i <= count; i++)
        {
            var y = point.y + Mathf.Cos(angle / count * i) * distance;
            var x = point.x + Mathf.Sin(angle / count * i) * distance;
            point.x = x;
            point.y = y;

            var dirY = direction.y + Mathf.Cos(angle / count * i);
            var dirX = direction.x + Mathf.Sin(angle / count * i);
            direction.x = dirX;
            direction.y = dirY;
            BulletSpawn(point, direction, change, bullet);
        }
        angle = 360;
    }

    private void FireballSpellCircle(bool change, GameObject bullet, int count)
    {

        Vector2 point = transform.position;
        Vector2 direction = new Vector2(-1, 1);

        angle = angle * Mathf.Deg2Rad;
        for (int i = 1; i <= count; i++)
        {
            float y = transform.position.y + Mathf.Cos(angle / count * i) * distance;
            float x = transform.position.x + Mathf.Sin(angle / count * i) * distance;
            point.x = x;
            point.y = y;

            float dirY = Mathf.Cos(angle / count * i);
            float dirX = Mathf.Sin(angle / count * i);
            direction.x = dirX;
            direction.y = dirY;
            if(change)
                BulletSpawn(point, direction, true, bullet);
            else
                BulletSpawn(point, direction, false, bullet);
        }
        angle = 360;          
    }

    private void IcicleSpellCircle(bool change, GameObject bullet, int count)
    {
        Vector2 point = transform.position;
        Vector2 direction = new Vector2(-1, 1);
        Vector3 rotation = new Vector3(0, 0, 0);

        angle = angle * Mathf.Deg2Rad;
        for (int i = 1; i <= count; i++)
        {
            float _y = transform.position.y + Mathf.Cos(angle / count * i) * distance;
            float _x = transform.position.x + Mathf.Sin(angle / count * i) * distance;
            point.x = _x;
            point.y = _y;

            float dir_y = Mathf.Cos(angle / count * i);
            float dir_x = Mathf.Sin(angle / count * i);
            direction.x = dir_x;
            direction.y = dir_y;

            rotation.z = angle / count * i * Mathf.Rad2Deg;
            //rotation.z = ((Mathf.Atan2(direction.y - point.y, direction.x - point.x) + 2 * Mathf.PI) * 180 / Mathf.PI) % 360;
            //float degree = Angle * Mathf.Rad2Deg;
            //rotation.z = Mathf.Cos((direction.y * point.y + direction.x * point.x) / (Mathf.Sqrt(Mathf.Pow(direction.y + direction.x, 2) * Mathf.Pow( point.y * point.x, 2)))) *Mathf.Rad2Deg;


            if (change)
                BulletSpawnTest(point, direction, rotation, true, bullet);
            else
                BulletSpawnTest(point, direction, rotation, false, bullet);
        }
        angle = 360;
    }

    //TEST
    private void BulletSpawnTest(Vector2 pos, Vector2 dir, Vector3 rot, bool leftToRight, GameObject bullet)
    {
        InstObject = Instantiate(bullet, pos, Quaternion.identity);
        if (leftToRight)
        {
            InstObject.GetComponent<Fireball>().rotation = rot;
            InstObject.GetComponent<Fireball>().direction = dir;
        }
        else
        {
            InstObject.GetComponent<Fireball>().rotation = rot;
            InstObject.GetComponent<Fireball>().direction = -dir;
        }
            
    }

    private void Test(Vector2 pos, Vector2 dir, bool leftToRight, GameObject bullet)
    {
        InstObject = Instantiate(bullet, pos, Quaternion.identity);
        if(leftToRight)
            InstObject.GetComponent<TimedFireball>().direction = dir;
        else
            InstObject.GetComponent<TimedFireball>().direction = -dir;
    }
    
    private void BulletSpawn(Vector2 pos, Vector2 dir, bool leftToRight, GameObject bullet)
    {
        InstObject = Instantiate(bullet, pos, Quaternion.identity);
        if(leftToRight)
            InstObject.GetComponent<Fireball>().direction = dir;
        else
            InstObject.GetComponent<Fireball>().direction = -dir;
    }

    /*private IEnumerator Test(FireballCircle settings)
    {
        yield return new WaitForSeconds(settings.Time);
        IcicleSpellCircle(settings.Change, settings.Bullet, settings.Count);
    }*/
    
    private IEnumerator Test(float waitTime, bool change, GameObject bullet, int count)
    {
        yield return new WaitForSeconds(waitTime);
        FireballSpiral(change, bullet, count, 4);
    }
    
    private IEnumerator WaitForCircleIcicle(float waitTime, bool change, GameObject bullet, int count)
    {
        yield return new WaitForSeconds(waitTime);
        IcicleSpellCircle(change, bullet, count);
    }

    private IEnumerator WaitForCircleFireball(float waitTime, bool change, GameObject bullet, int count)
    {
        yield return new WaitForSeconds(waitTime);
        FireballSpellCircle(change, bullet, count);
    }

    private IEnumerator WaitForLeftFireball(float waitTime, bool change, GameObject bullet, int count)
    {
        yield return new WaitForSeconds(waitTime);
        FireballSpellLeftToRight(change, bullet, count);
    }
}
