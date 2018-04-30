using UnityEngine;
using System.Collections;

public class TextureAnimatorLightmap : MonoBehaviour 
{
    


    public float     speed;
    public Material[]  material;
    public Texture[] textures;
    
    int numTextures;

    float frameTime;

    void Start()
    {
        numTextures = textures.Length;
        
        if (numTextures == 0)
        {
            Debug.LogError("Missing Texture Sequence");
            return;
        }

    }

	void Update() 
    {        
        int i;
        
        frameTime += Time.deltaTime * speed;
        for(i=0;i<material.Length;i++)
            material[i].SetTexture("_LightMap", textures[(int)Mathf.Abs(frameTime) % numTextures]);
	}
}

