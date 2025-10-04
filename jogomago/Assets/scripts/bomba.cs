using UnityEngine;

public class bomba : MonoBehaviour
{
    [SerializeField] private GameObject prefabDaBomba;
    [SerializeField] private Transform pontoDeDisparo;
    [SerializeField] private float tempoParaExplodir = 2f;

    private float ultimoToque = 0f;
    private float intervaloToqueDuplo = 0.3f;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            DetectarToqueDuplo();
        }

    }

    void DetectarToqueDuplo()
    {
        float tempoAtual = Time.time;

        if (tempoAtual - ultimoToque < intervaloToqueDuplo)
        {
            LançarBomba();
        }

        ultimoToque = tempoAtual;
    }

    void LançarBomba()
    {
        Vector3 posicao = pontoDeDisparo.position;
        posicao.y -= 1.5f;
        GameObject bomba = Instantiate(prefabDaBomba, posicao, Quaternion.identity);
        Destroy(bomba, tempoParaExplodir);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("inimigo"))
        {
            scriptmalvado inimigo = collider.GetComponent<scriptmalvado>();
            inimigo.ReceberDano();
            Destroy(this.gameObject);
        }
    }
}