using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class obstacles : MonoBehaviour {
    private int randY;
    void Start() {
        GameObject player = GameObject.Find("player");
        playerController player2 = player.GetComponent<playerController>();
        bool pos = player2.car_rot;
        if (pos == true){
            randY = UnityEngine.Random.Range(3, 6);
        } else {
            randY = UnityEngine.Random.Range(-3, -6);
        }
    } void Update() {
        transform.Translate(new Vector3(0,1,0) * randY * Time.deltaTime);
        //delete when gets out of distance
        if (transform.position.y < -6){
            Destroy(gameObject);
        }
    }
}
