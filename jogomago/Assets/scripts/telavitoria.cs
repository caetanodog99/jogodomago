using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class telavitoria : MonoBehaviour
{
    [SerializeField] private string fase1;


    void Update()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            SceneManager.LoadScene(fase1);
        }
    }
}