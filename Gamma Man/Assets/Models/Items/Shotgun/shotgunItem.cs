using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class shotgunItem : rangedWeaponItem {
    new int bulletCapacity = 2;
    new float damage =20;
    new float damageDrop = 3;
    public override void Fire(){  //TODO: Use a cone and random variable instead of raycast, to simulate spread.
            if(bulletsInGun > 0){
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.forward, out hit)){
                    float distance = Vector3.Distance(transform.position,hit.point);
                    float calculatedDamage = Mathf.Clamp(damage - (damageDrop*distance), 0, damage);
                    hit.transform.SendMessage("TakeDamage",calculatedDamage);
                }
            }else{
                Reload();
            }
    }
    public override void Reload(){
        
    }
}