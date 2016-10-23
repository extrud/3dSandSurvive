using UnityEngine;
using System.Collections;

public class ChankCenter : MonoBehaviour {

    int chunksize;
    int curchunkx;
    int curchunky;
	// Use this for initialization
	void Start () {
        chunksize = ChankManager.chunksize;
        curchunkx = (int)(transform.position.x / chunksize + 0.5f);
        curchunky = (int)(transform.position.z / chunksize + 0.5f);
        ChankManager.ChengeCenterPos((int)(transform.position.x / chunksize + 0.5f), (int)(transform.position.z / chunksize + 0.5f));
    }

    // Update is called once per frame
    void Update () {
        if(((int)(transform.position.x / chunksize + 0.5f))!= curchunkx || ((int)(transform.position.z / chunksize + 0.5f)) != curchunky)
            {
            ChankManager.ChengeCenterPos((int)(transform.position.x / chunksize + 0.5f), (int)(transform.position.z / chunksize + 0.5f));
        }
	}
}
