using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
public class playerController : MonoBehaviour {
    private sound soundControll;
    public bool collect_points = true;
    public GameObject player;
    public Vector3 pos;
    public GameObject map;
    public int map_speed = -2;
    public int score;
    public bool dead = false;
    public Text scoreT;
    public ParticleSystem deathP;
    public GameObject CAR;
    public Transform map_transform;
    public Vector3 car_spawn_pos;
    public bool car_rot = false;
    void Start(){
        GameObject soundOB = GameObject.Find("sound");
        soundControll = soundOB.GetComponent<sound>();

        car_spawn_pos = new Vector3(0, 1, 0);
        pos = new Vector3(0, 1, 0);
        Thread CountScore = new Thread(CS);
        CountScore.Start();
    }
    void CS(){
        while(true){
            if (dead != true && collect_points == true) {
                Thread.Sleep(1000);
                score++;
                scoreT.text = score.ToString();
            }
        }
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            print("left");
            pos = transform.right * -1;
            collect_points = false; 
        }if (Input.GetKeyDown(KeyCode.RightArrow)) {
            print("right");
            pos = transform.right;
            collect_points = false;
        } if (Input.GetKeyDown(KeyCode.UpArrow)) {
            print("up");
            pos = transform.up;
            collect_points = true;
        } if (dead != true){
            map.transform.Translate(pos * map_speed * Time.deltaTime, Space.Self);
        }
    }
    void OnTriggerExit(Collider other){
        print("exited");
        if(other.tag == "rotate_90" || other.tag =="rotate_90_neg"){
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
            print("unrotate");
            car_spawn_pos = new Vector3(0, 1, 0);
            car_rot = false;
        }
    }
    void OnTriggerEnter(Collider other){
        print("enterd");
        if (other.tag == "rotate_90"){
            print("rotated");
            player.transform.rotation = Quaternion.Euler(0, 0, 90);
            car_spawn_pos = new Vector3(1,0,0);
            car_rot = true;
        } if (other.tag == "rotate_90_neg"){
            player.transform.rotation = Quaternion.Euler(0, 0, -90);
            print("rotated negitivly");
            car_spawn_pos = new Vector3(-1, 0, 0);
            car_rot = true;
        } if (other.tag == "death" || other.tag == "car") {
            end();
        } if (other.tag == "car_spawner"){
            GameObject spCa = Instantiate(CAR, car_spawn_pos * 7, transform.rotation);
            spCa.transform.parent = map_transform;
            spCa.transform.localScale += new Vector3((float)0.08, (float)0.13, (float)0);
        }
    }
    void end(){
        //Destroy(gameObject);
        dead = true;
        deathP.Play();
        soundControll.death = true;
    }
}
