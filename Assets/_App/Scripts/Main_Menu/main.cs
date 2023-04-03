using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button loadButton;
    [SerializeField] private Button editButton;
    [SerializeField] private Button quitButton;
    // Start is called before the first frame update
    void Start()
    {
        GameHandler.LoadBaseSaveData("Assets/_App/saves/empty.json");
        startButton.onClick.AddListener(GameStart);
        loadButton.onClick.AddListener(LoadGame);
        editButton.onClick.AddListener(EditMap);
        quitButton.onClick.AddListener(QuitGame);
    }

    void GameStart(){
        Debug.Log("Game Start");
        SceneManager.LoadScene(1);
    }

    void LoadGame(){
        SceneManager.LoadScene(2);
    }

    void EditMap(){
        SceneManager.LoadScene(3);
    }

    void QuitGame(){
        Application.Quit();
    }
}
