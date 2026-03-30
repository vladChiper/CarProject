using UnityEngine;

public class VehControl : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 50f;
    private float inputHorizontal;
    private float inputForward;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputForward = Input.GetAxis("Vertical");


        transform.Translate(Vector3.forward * speed * Time.deltaTime * inputForward);
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * inputHorizontal);
    }
}
