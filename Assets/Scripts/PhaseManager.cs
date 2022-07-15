using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhaseManager : MonoBehaviour
{
    public string phase1, phase2, phase3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectPhase1(){
        SceneManager.LoadScene(phase1);
    }

    public void SelectPhase2(){
        SceneManager.LoadScene(phase2);
    }

    public void SelectPhase3(){
        SceneManager.LoadScene(phase3);
    }
}
