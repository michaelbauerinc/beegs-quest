using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    private GameData gameData;

    // Start is called before the first frame update
    void Start () {
        LoadGameData ();
        SetAllGameOutput (gameData.all_game_data[0]);
    }

    // Update is called once per frame
    void Update () {

    }

    void SetTitle (string new_title) {
        GameObject game_object = GameObject.Find ("Title");
        game_object.GetComponent<Text> ().text = new_title;
    }

    void SetOutput (string new_output) {
        GameObject game_object = GameObject.Find ("Output");
        game_object.GetComponent<Text> ().text = new_output;
    }

    void SetChoices (string new_one, string new_two) {
        GameObject game_object = GameObject.Find ("ChoiceOne");
        game_object.GetComponent<Text> ().text = "<color=\"yellow\">1)</color> " + new_one;

        game_object = GameObject.Find ("ChoiceTwo");
        game_object.GetComponent<Text> ().text = "<color=\"yellow\">2)</color> " + new_two;

    }

    void SetAllGameOutput (GameArea new_game_area) {
        SetTitle (new_game_area.title);
        SetOutput (new_game_area.output);
        SetChoices (new_game_area.choice_one, new_game_area.choice_two);
    }

    void LoadGameData () {
        using (StreamReader stream = new StreamReader ("./data.json")) {
            string json = stream.ReadToEnd ();
            gameData = JsonUtility.FromJson<GameData> (json);
            Debug.Log (gameData.all_game_data[0].title);
            // var output = JsonUtility.ToJson (gameData.all_game_data);
            // foreach (var x in gameData.all_game_data) {
            //     // Debug.Log (x.title.ToString ());
            // }
            // Debug.Log (output);
        }

    }

    [System.Serializable]
    public class GameArea {
        public string title;
        public string output;
        public string choice_one;
        public string choice_two;
    }

    [System.Serializable]
    public class GameData {
        public List<GameArea> all_game_data;
    }

}