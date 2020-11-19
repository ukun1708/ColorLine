using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotator : MonoBehaviour
{

    public float speedRotation = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation *= Quaternion.Euler(Vector3.up * speedRotation * Time.deltaTime);
    }
}
