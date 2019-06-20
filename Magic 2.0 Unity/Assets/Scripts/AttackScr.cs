using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScr : MonoBehaviour
{
    public GameObject Spell1;
    public Transform Spawn1;
    public Transform ParentRotationY;
    public Transform ParentRotationX;
    public float requiredLoadingTime;
    public float Speed1;

    private GameObject Spell1Instance;
    private float LoadingTime = 0;
    private bool Spell1aktive = false;

    void Awake()
    {
        
    }

    
    void Update()
    {
        //Spell1

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Spell1Instance = Instantiate(Spell1, Spawn1.position, ParentRotationY.rotation);            
            Spell1Instance.transform.SetParent(ParentRotationX);

            Spell1aktive = true;
        }

        if (Spell1aktive)
            LoadingTime += 1;

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if(LoadingTime>= requiredLoadingTime)
            {
                Spell1Instance.transform.parent = null;
                Spell1Instance.GetComponent<Rigidbody>().AddForce(transform.forward * Speed1);
            }
            else
                Destroy(Spell1Instance);

            Spell1aktive = false;
            LoadingTime = 0;
        }

    }
}
