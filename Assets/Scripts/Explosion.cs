using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float cubeSize = 0.2f;
    public int cubesInRow = 5;

    float cubesPivotDistance;
    Vector3 cubesPivot;
    public float explosionForce = 50f;
    public float explosionRadius = 50f;
    public float explosionUpward = 50f;

    public GameObject deadBackground;
    public GameObject restartButton;

    void Start()
    {
        cubesPivotDistance = cubeSize * cubesInRow / 2;

        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);

        deadBackground.SetActive(false);
        restartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Blade")
        {
            Explode();            
        }

        if (other.gameObject.name == "Finish")
        {
            deadBackground.SetActive(true);
            restartButton.SetActive(true);

        }
    }

    public void Explode()
    {
        //gameObject.SetActive(false);

        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;       

        PathMover.Singleton.play = false;

        StartCoroutine(RestartMenu()); // включение окна проигрыша

        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    CreatePiece(x, y, z);
                }
            }
        }

        Vector3 explosionPos = transform.position;

        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
    }

    void CreatePiece(int x, int y, int z)
    {
        GameObject piece;

        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        piece.GetComponent<MeshRenderer>().material = gameObject.GetComponent<MeshRenderer>().material;

        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
    }

    IEnumerator RestartMenu()
    {
        yield return new WaitForSeconds(2);

        deadBackground.SetActive(true);
        restartButton.SetActive(true);

        yield return null;
    }
}
