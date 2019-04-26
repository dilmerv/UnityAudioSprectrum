using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateShapeManager : MonoBehaviour
{
    [SerializeField]
    private float radius = 1.0f;

    [SerializeField]
    private int objectsToBePlaced = 10;

    [SerializeField]
    private float sampleMultipler = 100.0f;

    [SerializeField]
    private PrimitiveType PrimitiveTypeOption = PrimitiveType.Cube;

    private SpectrumManager spectrumManager = null;

    private GameObject[] gameObjectsCreated;

    void Start()
    {
        spectrumManager = SpectrumManager.Instance;
        gameObjectsCreated = new GameObject[objectsToBePlaced];

        PlaceObjects();
    }

    void PlaceObjects()
    {
        for(int i = 0; i < objectsToBePlaced; i++)
        {
            float angle = (i+1) * Mathf.PI * 2.0f / objectsToBePlaced;
            Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
            GameObject go = GameObject.CreatePrimitive(PrimitiveTypeOption);
            go.transform.position = newPos;
            go.name = $"{nameof(PrimitiveType.Cube)}_{i}";
            go.transform.parent = gameObject.transform;
            gameObjectsCreated[i] = go;
        }
    }

    void Update()
    {
        for(int i = 0; i < gameObjectsCreated.Length; i++)
        {
            float value = spectrumManager.Samples[i] * sampleMultipler;   
            GameObject go = gameObjectsCreated[i];
            go.transform.localScale = 
                new Vector3(go.transform.localScale.x, value, go.transform.localScale.z);
        }
    }
}
