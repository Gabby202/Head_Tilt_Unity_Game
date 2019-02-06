using UnityEngine;
using System.Collections;


public class CameraFollow : MonoBehaviour
{

    private GameObject followTarget;
    private Vector3 targetPos;
    public float moveSpeed;
    private static bool cameraExists;

    // Use this for initialization
    void Start()
    {

        //stops duplication of camera 
        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }





    // Update is called once per frame
    void FixedUpdate()
    {
        //follows any target tagged player and has a smooth follow 
        followTarget = GameObject.FindGameObjectWithTag("Player");
        
        Debug.Log(followTarget.ToString());
        targetPos = new Vector3(transform.position.x, transform.position.y, followTarget.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);



    }


}
