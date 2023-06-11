using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string levelJogo;
    [SerializeField] private float tempScene;
    [SerializeField] private GameObject painelMenu;
    [SerializeField] private GameObject painelControles;

    public Animator transitionAmin;
    public void Iniciar()
    {
        StartCoroutine(LoadScene());
    }

    public void AbrirControles()
    {
        painelMenu.SetActive(false);
        painelControles.SetActive(true);
    }

    public void FecharControles()
    {
        painelMenu.SetActive(true);
        painelControles.SetActive(false);
    }

    public void SairJogo()
    {
        Application.Quit();
    }

    IEnumerator LoadScene()
    {
        transitionAmin.SetTrigger("end");
        yield return new WaitForSeconds(tempScene);
        SceneManager.LoadScene(levelJogo);
    }


  
}
