using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlat : MonoBehaviour
{

    public GameObject diamond;
    //public GameObject plat;
    void Start()
    {
        int randDiamond = Random.Range(0,5);
        Vector3 diamondPos = transform.position;
        diamondPos.y += 1f;

        if (randDiamond < 1)
        {
            
            GameObject diamondInstance = Instantiate(diamond, diamondPos, diamond.transform.rotation);
            diamondInstance.transform.SetParent(gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    //private void OnCollisionExit(Collision other) {
    //    if(other.gameObject.tag == "Player")
    //    {
    //        Invoke("Fall", 0.2f);
    //    }
    //}

    //void Fall()
    //{
    //    GetComponent<Rigidbody>().isKinematic = false;
    //    Destroy(plat,1f);
    //}
    
}
