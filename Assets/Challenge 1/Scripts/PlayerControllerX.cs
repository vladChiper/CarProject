using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed = 20f;
    public float rollSpeed = 100f;  // Viteza de înclinare (A/D)
    public float pitchSpeed = 80f; // Viteza de urcare/coborâre (W/S)
    
    private float verticalInput;
    private float horizontalInput;

    void FixedUpdate()
    {
        // Preluăm input-ul (W/S pentru Vertical, A/D pentru Horizontal)
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // 1. Mișcare constantă înainte (avionul nu stă pe loc)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // 2. Pitch (W/S): Înclinăm botul avionului sus/jos
        
        // Dacă preferi invers, șterge minusul.
        transform.Rotate(Vector3.right * pitchSpeed * Time.deltaTime * verticalInput);

        // 3. Roll (A/D): Înclinăm avionul pe lateral
        // Vector3.forward rotit cu minus face ca D să încline spre dreapta
        transform.Rotate(Vector3.forward * rollSpeed * Time.deltaTime * -horizontalInput);

        // 4. Virajul automat (Banked Turn):
        // Verificăm cât de mult este înclinat avionul pe axa Z (Z-axis rotation)
        // Dacă avionul e înclinat, aplicăm o rotație pe axa Y (Yaw)
        float tiltAngle = transform.localEulerAngles.z;

        // Convertim unghiul de la 0-360 la -180 la 180 pentru calcule mai ușoare
        if (tiltAngle > 180) tiltAngle -= 360;

        // Cu cât e mai mare înclinarea (tiltAngle), cu atât virează mai strâns
        
        float turnStrength = -tiltAngle ; 
        transform.Rotate(Vector3.up * turnStrength * Time.deltaTime);
    }
}