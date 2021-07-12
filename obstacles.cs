using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class obstacles : MonoBehaviour {
    public static int randY;
    public float posY;
    void Start() {
        GameObject player = GameObject.Find("player");
        playerController player2 = player.GetComponent<playerController>();
        posY = player2.pos.y;
        randY = UnityEngine.Random.Range(-3, -6);
    }
    void Update() {
        transform.Translate(new Vector3(0,posY,0)* randY * Time.deltaTime);
        //delete when gets out of distance
        if (transform.position.y < -6){
            Destroy(gameObject);
        }
    }
}
