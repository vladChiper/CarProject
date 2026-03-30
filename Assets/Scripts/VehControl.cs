using UnityEngine;

public class VehControl : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 50f;
    private float inputHorizontal;
    private float inputForward;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string inputID;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal" + inputID);
        inputForward = Input.GetAxis("Vertical" + inputID);


        transform.Translate(Vector3.forward * speed * Time.deltaTime * inputForward);
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * inputHorizontal);
    }
}
