using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModularTower : MonoBehaviour
{
    //Unity Objects
    public GameObject PlayerCar;
    public GameObject BulletPreFab;
    Transform towerTransform;
    
    //tower fire rate
    public float fireCD = 5.0f; //allow creators to vary tower cd based on tower type
    float fireCDLeft = 1;

    //public defaults
    public float range = 10f;
    public int damage = 10;
    public float rad = 0f;
    public int towerValue;

    void Start()
    { towerTransform = transform.Find("TowerHead"); }

    void Update()
    {
        //can be optimized
        Opponent[] opps = GameObject.FindObjectsOfType<Opponent>();
        Opponent nearest = null;

        float dist = Mathf.Infinity; // tower range for rotation

        foreach (Opponent o in opps)
        {
            float d = Vector3.Distance(this.transform.position, o.transform.position);
            if (nearest == null || d < dist)
            {
                nearest = o;
                dist = d;
            }
        }
        if(nearest == null) { return; } //relook for opponents if none found

        //rotating tower / turret head
        Vector3 direct = nearest.transform.position - this.transform.position;
        Quaternion lookRot = Quaternion.LookRotation(direct);
        towerTransform.rotation = Quaternion.Euler(0, lookRot.eulerAngles.y, 0);

        //fire cooldown on tower
        fireCDLeft -= Time.deltaTime; //only fire after set time
        if (fireCDLeft <= 0 && range >= direct.magnitude)
        {
            fireCDLeft = fireCD; //reset fire cd
            Shoot(nearest);
        }

        void Shoot(Opponent o1)
        {
            GameObject bulletClone = Instantiate(BulletPreFab, this.transform.position, this.transform.rotation);

            Bullet b = bulletClone.GetComponent<Bullet>();  //create bullet obj and turn on script / send info
            b.GetComponent<Bullet>().enabled = true;
            b.target = o1.transform;
            b.dmg = damage;
            b.radius = rad;
        }
    }
}
