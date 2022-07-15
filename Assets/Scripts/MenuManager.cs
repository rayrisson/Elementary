using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        SceneManager.LoadScene(scene);
    }

    public void QuitGame(){
        //Editor Unity
        // UnityEditor.EditorApplication.isPlaying = false;
        //Jogo compilado
        Application.Quit();
    }
}
