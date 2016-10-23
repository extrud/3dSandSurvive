using UnityEngine;
using System.Collections;

public class MovingScript : MonoBehaviour {
    public float speed;
    public bool inmoov;
    public bool randommove;
    IEnumerator Moving(Vector3 movevector)
    {
        inmoov = true;
        Vector3 startpoint = transform.position;
        transform.LookAt(transform.position+movevector);
        bool freeway = true;
        if (Physics.Raycast(new Ray(transform.position,movevector),1f))
        {
            Debug.Log("sdd");
            freeway = false;
        }
        if (!Physics.Raycast(new Ray(transform.position+ movevector, Vector3.down), 1f))
        {
            Debug.Log("sdd");
            freeway = false;
        }

        if (freeway)
        while (transform.position != startpoint+movevector)
        {
         
           
           
                transform.Translate(movevector * Time.deltaTime * speed,Space.World);
                    if ((transform.position - startpoint).magnitude > movevector.magnitude)
                    {
                        transform.position = startpoint + movevector;
                        break;
                    }
                    yield return new WaitForEndOfFrame();
            
        }
        inmoov = false;

    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(randommove && !inmoov)
        {
            Vector3 move_v = new Vector3();

            switch (Random.Range(0, 4))
            {
                case 0: move_v = Vector3.forward;
                    break;

                case 1:
                    move_v = Vector3.right;
                    break;

                case 2:
                    move_v = Vector3.back;
                    break;
                case 3:
                    move_v = Vector3.left;
                    break;
            }
            StartCoroutine(Moving(move_v));
        }
        if (Input.anyKey && !inmoov && !randommove)
        {
            Vector3 move_v = new Vector3();

            if (Input.GetKey(KeyCode.D))
            {
                move_v = Vector3.forward;
            }
            if (Input.GetKey(KeyCode.A))
            {
                move_v = Vector3.back;
            }
            if (Input.GetKey(KeyCode.S))
            {
                move_v = Vector3.right;
            }
            if (Input.GetKey(KeyCode.W))
            {
                move_v = Vector3.left;
            }
            StartCoroutine(Moving(move_v));
        }
    }
}
