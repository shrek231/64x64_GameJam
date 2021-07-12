using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class obstacles : MonoBehaviour {
    public static int randY;
    public Vector3 pos;
    void Start() {
        GameObject player = GameObject.Find("player");
        playerController player2 = player.GetComponent<playerController>();
        pos = player2.pos;
        randY = UnityEngine.Random.Range(-3, -6);
    }
    void Update() {
        transform.Translate(pos* randY * Time.deltaTime);

        //delete when gets out of distance
        if (transform.position.y < -6){
            Destroy(gameObject);
        }
    }
}
