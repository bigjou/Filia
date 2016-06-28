using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
    public GameObject player;
    public Vector3 offset;


    // Use this for initialization
    void Start()
    {


        offset = transform.position - player.transform.position;

    }

        // Update is called once per frame

        void LateUpdate () {

         //   float moveX = Input.GetAxis("Horizontal");
          //  float moveZ = Input.GetAxis("Vertical");

          //  offset = new Vector3(20, moveZ, moveX);
       
            transform.position = player.transform.position + offset;
	
	}
}
