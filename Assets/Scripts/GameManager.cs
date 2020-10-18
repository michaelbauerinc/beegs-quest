using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    private GameData gameData;
    private int currentNode = 0;
    private int input = 0;
    public bool gameEnded = false;

    // Start is called before the first frame update
    void Start () {
        LoadGameData ();
    }

    // Update is called once per frame
    void Update () {
        GetPlayerInput ();
        CalculateNextNode (currentNode, input);
        PlayGame (currentNode);
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
            // Debug.Log (gameData.all_game_data[0].title);
            // var output = JsonUtility.ToJson (gameData.all_game_data);
            // foreach (var x in gameData.all_game_data) {
            //     // Debug.Log (x.title.ToString ());
            // }
            // Debug.Log (output);
        }

    }

    void GetPlayerInput () {
        input = 0;
        if (Input.GetKeyUp (KeyCode.Alpha1)) {
            input = 1;

        } else if (Input.GetKeyUp (KeyCode.Alpha2)) {
            input = 2;
        }

    }

    void CalculateNextNode (int node, int input) {
        if (input == 0) {
            return;
        }
        switch (node) {
            case 0:
                if (input == 1) {
                    currentNode = 1;
                } else if (input == 2) {
                    currentNode = 2;
                }
                break;
            case 1:
                if (input == 1) {
                    currentNode = 3;
                } else if (input == 2) {
                    currentNode = 4;
                }
                break;
            case 2:
                if (input == 1) {
                    currentNode = 5;
                } else if (input == 2) {
                    currentNode = 6;
                }
                break;
            case 3:
                if (input == 1) {
                    currentNode = 7;
                } else if (input == 2) {
                    currentNode = 4;
                }
                break;
            case 4:
                if (input == 1) {
                    currentNode = 7;
                } else if (input == 2) {
                    currentNode = 8;
                }
                break;
            case 5:
                if (input == 1) {
                    currentNode = 8;
                } else if (input == 2) {
                    currentNode = 9;
                }
                break;
            case 6:
                if (input == 1) {
                    currentNode = 5;
                } else if (input == 2) {
                    currentNode = 9;
                }
                break;
            case 7:
                if (input == 1) {
                    currentNode = 10;
                } else if (input == 2) {
                    currentNode = 8;
                }
                break;
            case 8:
                if (input == 1) {
                    currentNode = 10;
                } else if (input == 2) {
                    currentNode = 10;
                }
                break;
            case 9:
                if (input == 1) {
                    currentNode = 8;
                } else if (input == 2) {
                    currentNode = 10;
                }
                break;
            case 10:
                gameEnded = true;
                break;

            default:
                break;
        }
    }

    void PlayGame (int currentNode) {
        SetAllGameOutput (gameData.all_game_data[currentNode]);
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