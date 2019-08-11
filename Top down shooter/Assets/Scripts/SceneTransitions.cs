using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{

    private Animator transitionAnim;


    void Start()
    {
        transitionAnim = GetComponent<Animator>();
        
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(Transition(sceneName));
    }

    IEnumerator Transition(string sceneName)
    {
        transitionAnim.SetTrigger("end");
        Debug.Log("Klicky klicky");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }


    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("MainMenu");
            Debug.Log("Esacpe?");
        }
    }
}
