using UnityEngine;

public class planoDeFundo : MonoBehaviour
{
    public Renderer renderer;
    public float velocidade;

    private Material material;
    private Vector2 offsetMaterial;

    void Start()
    {
        this.material = this.renderer.material;
        this.offsetMaterial = this.material.GetTextureOffset("_MainTex");
    }

   
    void Update()
    {
        this.offsetMaterial.y -= this.velocidade * Time.deltaTime;
        this.material.SetTextureOffset("_MainTex", this.offsetMaterial);
    }
}
