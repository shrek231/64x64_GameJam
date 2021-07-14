using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class Level : MonoBehaviour{
    public Slider scrollBar;
    public Text level;
    public int textLevel;
    public float scrollbar;
    void Start(){
        if (!File.Exists("Score")){
            File.Create("lastScore").Dispose();
            File.Create("Score").Dispose();
            File.Create("level").Dispose();
            File.WriteAllText("lastScore", "0");
            File.WriteAllText("Score", "0");
            File.WriteAllText("level", "0");
        } float last_score = float.Parse(File.ReadAllLines("lastScore")[0]);
        float current_score = float.Parse(File.ReadAllLines("Score")[0]);
        int levelc = int.Parse(File.ReadAllLines("level")[0]);
        while(true){
            if (current_score + last_score > 1){
                print("cs + ls > 1");
                textLevel = levelc + 1;
                level.text = "Level:" + textLevel.ToString();
                scrollbar = last_score + current_score - 1;
                last_score -= .5f;
                current_score -= .5f;
                scrollBar.value = scrollbar;
                if (scrollbar > 1f){
                    print("loop");
                } else {
                    break;
                }
            } else {
                break;
            }
        }
        File.WriteAllText("lastScore", "0");
        File.WriteAllText("Score", scrollbar.ToString());
        File.WriteAllText("level", textLevel.ToString());
    }
}
