using UnityEngine;

public class RotateSprite : MonoBehaviour
{
    public float rotationSpeed = 100f; // Dönme hýzý

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
