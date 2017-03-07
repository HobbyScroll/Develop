using UnityEngine;
using System.Collections;

public class Savor_MoveThis : MonoBehaviour {


    public float Translation_Speed_X = 0.0f;
    public float Translation_Speed_Y = 0.0f;
    public float Translation_Speed_Z = 0.0f;

    public bool local = true;

    public float limitX = 0.0f;

    private Vector3 initTrans; 

    // Use this for initialization
    void Start () {
        //Vector3 initTrans = new Vector3(0,0,0);
        initTrans = this.transform.position;
        initTrans.x = -1 * limitX; 
	}
	
	// Update is called once per frame
	void Update () {
        if (local == true)
        {
            transform.Translate(new Vector3(Translation_Speed_X, Translation_Speed_Y, Translation_Speed_Z) * Time.deltaTime);
        }

        if (local == false)
        {
            transform.Translate(new Vector3(Translation_Speed_X, Translation_Speed_Y, Translation_Speed_Z) * Time.deltaTime, Space.World);

          
        }

        if (transform.position.x > limitX)
            transform.position = initTrans; 
    }
}
