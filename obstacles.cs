using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour {
    public static int randY;
    public GameObject camera;
    public GameObject car;
    public static GameObject spawned_car;
    void Start() {
        SpawnCar();
    }
    void SpawnCar(){
        randY = UnityEngine.Random.Range(-3, -6);
        spawned_car = Instantiate(car, new Vector3(UnityEngine.Random.Range(-8, 8), 7, 0), Quaternion.identity);
    }
    void Update() {
        if (spawned_car != null) {
            spawned_car.transform.Translate(camera.transform.up* randY * Time.deltaTime);
        }
    }
}
