using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class obstacles : MonoBehaviour {
    private bool pos;
    private int randY;
    private bool rotated = false;
    private bool crashed = false;
    public ParticleSystem smoke;
    void Start() {
        GameObject player = GameObject.Find("player");
        playerController player2 = player.GetComponent<playerController>();
        pos = player2.car_rot;
        if (pos == true){
            randY = UnityEngine.Random.Range(3, 6);
        } else {
            randY = UnityEngine.Random.Range(-3, -6);
        }
    } void Update() {
        if (!crashed) {
            transform.Translate(new Vector3(0, 1, 0) * randY * Time.deltaTime);
        }
        //delete when gets out of distance
        if (transform.position.y < -6){
            Destroy(gameObject);
        }
    } void OnTriggerEnter(Collider other){
        print("hit");
        if (other.tag == "car"){
            crashed = true;
            smoke.Play();
        }
        if (other.tag == "death"){
            print("hit/w tag");
            if (rotated == false){
                //pos = true;
                randY = UnityEngine.Random.Range(3, 6);
                rotated = true;
                transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            } else {
                rotated = false;
                //pos = false;
                randY = UnityEngine.Random.Range(-3, -6);
            }
        }
    }
}
