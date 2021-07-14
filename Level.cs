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
    public int score_to_level = 2; //for example if this is 2 then after score gets to 1 it will add 1 to score
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
        level.text = "Level:" + levelc.ToString();
        scrollbar = last_score + current_score;
        scrollBar.value = scrollbar;
        while (true){
            if (current_score + last_score > score_to_level){
                print("cs + ls > 1");
                levelc += 1;
                textLevel = levelc;
                level.text = "Level:" + textLevel.ToString();
                scrollbar = last_score + current_score - score_to_level;
                last_score -= (float)score_to_level/2;
                current_score -= (float)score_to_level/2;
                scrollBar.value = scrollbar;
                File.WriteAllText("Score", scrollbar.ToString());
                File.WriteAllText("level", textLevel.ToString());
                if (scrollbar > score_to_level){
                    print("loop");
                } else {
                    break;
                }
            } else {
                break;
            }
        }
        File.WriteAllText("lastScore", "0");
    }
}
