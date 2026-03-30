using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offsetThirdPerson;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 offsetFirstPerson = new Vector3(0, 4.7f, 0f);

    public bool isFirstPerson = false;

    void Start()
    {
        offsetThirdPerson = transform.position - player.transform.position;
    }

    // Update is called once per frame
   void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            isFirstPerson = !isFirstPerson;
        }
    
        if (isFirstPerson)
        {
            // Poziția camerei exact la "ochii" avionului
            transform.position = player.transform.position + offsetFirstPerson;
            // Camera se uită în direcția în care avionul se mișcă
            transform.rotation = player.transform.rotation;
        }
        else
        {
            // Logica ta actuală de Third Person
            transform.position = player.transform.position + offsetThirdPerson;
            transform.rotation = Quaternion.Euler(12.5f, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
