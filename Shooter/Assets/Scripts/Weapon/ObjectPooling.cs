using UnityEngine;
using System.Collections.Generic;

public class ObjectPooling 
{
    private Queue<GameObject> _bullets = new Queue<GameObject>();

    public ObjectPooling(GameObject bulletPref, int amount)
    {
        for(int i = 0; i < amount; ++i)
        {
            GameObject tempBullet = GameObject.Instantiate(bulletPref);
            tempBullet.SetActive(false);
            _bullets.Enqueue(tempBullet);
        }
    }

    public GameObject SpawnBullet()
    {
        GameObject tempBullet = _bullets.Dequeue();
        tempBullet.SetActive(true);
        _bullets.Enqueue(tempBullet);
        return tempBullet;
    }
}
