using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    //initialize variables in unity
    public float speed = 15f;
    public int dmg = 1;
    public float radius = 0f;

    //Bullet starts travel from Parent Game Object //for now
    void Update()
    {
        if(target == null) //the fix for extra bullets from firing after death of target
        {
            //death to enemies
            Destroy(gameObject);
            return;
        }
        //travel 
        Vector3 dir = target.position - this.transform.localPosition;

        float distinFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distinFrame)
        { //target reached
            BulletHit();
        }
       else
        {
            //movement of projectile
            transform.Translate(dir.normalized * distinFrame, Space.World);
            Quaternion targetRot = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRot, Time.deltaTime * 5);
        }
    }

    void BulletHit()
    { 
        if (radius == 0)
        { //not a radius projectile just dps
            target.GetComponent<Opponent>().TakeDamage(dmg);
        } //if opponents don't die in a radius chk Kinematic Rigidbody && collider in range
        else
        {
            Collider[] c = Physics.OverlapSphere(transform.position, radius);
            
            foreach(Collider clld in c)
            {
                Opponent e = clld.GetComponent<Opponent>();
                if(e != null)
                { // falloff dmg is possible here
                    e.GetComponent<Opponent>().TakeDamage(dmg);
                }
                
            }
        }

        //EXPLOSION GOES HERE if its a thing
        Destroy(gameObject);
    }
}
