using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleVR;

public class Player : MonoBehaviour
{

    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward, out hit))
        {
            if (hit.transform.GetComponent<Mole>() != null)
            {
                Mole mole = hit.transform.GetComponent<Mole>();
                mole.OnHit();
                score++;
            }
        }
    }
}
