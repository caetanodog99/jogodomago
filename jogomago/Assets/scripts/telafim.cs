using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class telafim : MonoBehaviour
{

    public TextMeshProUGUI textopontos;
    public AudioSource audioDerrota;

    public void Exibir()
    {
        audioDerrota.Play();
        this.gameObject.SetActive(true);
        this.textopontos.text ="Pontos: " + pontuacao.Pontos;
        Time.timeScale = 0;
    }

    public void Esconder()
    {
        this.gameObject.SetActive(false);
    }

    public void TentarNovamente()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("fase1");
        
    }
}
