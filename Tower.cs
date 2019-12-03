using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    Transform turretTransform;
    float fireCD = 0.5f;
    float fireCDLeft = 0;
    public GameObject BulletObject;

    //public defaults set in unity for differing tower prefabs
    public float range = 10f;
    public int cost = 100;
    public int damage = 10;
    public float rad = 0f;


    void Start()
    {
        turretTransform = transform.Find("TowerHead"); //only rotate the "head"
    }

    // Update is called once per frame
    void Update()
    { //Optimize if possible down the line
        Opponent[] enemies = GameObject.FindObjectsOfType<Opponent>();

        Opponent nearest = null;
        float dist = Mathf.Infinity; //tower range value

        foreach(Opponent e in enemies) //iterate through enemies
        {
            float d = Vector3.Distance(this.transform.position, e.transform.position);
            if(nearest == null || d < dist)
            {
                nearest = e;
                dist = d;
            }
        }

        if(nearest == null) //if no opponents gtfo
        {
            Debug.Log("No Enemies...");
            return; 
        }

        //rotation of towerhead
        Vector3 dir = nearest.transform.position - this.transform.position;
        Quaternion lookRot = Quaternion.LookRotation(dir);

        turretTransform.rotation = Quaternion.Euler(0, lookRot.eulerAngles.y, 0);

        fireCDLeft -= Time.deltaTime;
        if(fireCDLeft <= 0 && dir.magnitude <= range)
        {
            fireCDLeft = fireCD;
            Shoot(nearest);
        }

        void Shoot(Opponent e1) //this was changed from enemies e to Opponent e//
        { //TODO: Fix to Fire out tip of tower instead of object head
            GameObject BullGo = (GameObject)Instantiate(BulletObject, this.transform.position, this.transform.rotation);

            Bullet b = BullGo.GetComponent<Bullet>();
            b.target = e1.transform;
            b.dmg = damage;
            b.radius = rad;
        }
    }
}
