using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class menuinicial : MonoBehaviour
{
    [SerializeField] private string fase1;
    public TextMeshProUGUI textoInstrucoes;
    public TextMeshProUGUI textoInicial;
    public TextMeshProUGUI textoTitulo;

    void Update()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            StartCoroutine(TrocarCena());
        }
    }

    IEnumerator TrocarCena()
    {
        this.textoInicial.text = "";
        this.textoTitulo.text = "";
        this.textoInstrucoes.text = "Você deve derrotar todos os inimigos\n\nArraste o mago para movê-lo\n\nToque duas vezes na tela para proteger o mago";
        yield return new WaitForSeconds(6f);

        if (!string.IsNullOrEmpty(fase1))
        {
            SceneManager.LoadScene(fase1);
        }

    }
}