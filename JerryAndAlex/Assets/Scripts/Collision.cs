using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public bool instantKill;
    public float damage;
    public bool destroyOnHit;
    float speed = 1;
    
    void Start() {
       gameObject.AddComponent<UnityEngine.BoxCollider2D>();
       gameObject.GetComponent<UnityEngine.BoxCollider2D>().isTrigger = true;
       gameObject.tag = "Damage";
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Debug.Log("oh nooo");
        }
    }
}
