using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    // Start is called before the first frame update

    void Start(){
        Resume();
    }
    void Update(){
        if(Input.GetButtonDown("Cancel")){
            Pause();
        }
    }
    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home(int sceneID){
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
}
