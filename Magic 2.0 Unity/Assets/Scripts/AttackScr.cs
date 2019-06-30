using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScr : MonoBehaviour
{
    public GameObject Spell1;
    public GameObject Spell2;
    public GameObject feuerball;

    public GameObject ArmRight;
    public Transform Spawn1;
    public Transform Spawn2;
    public Transform Spawn3;

    public Camera fpsCam;
    
    public float requiredLoadingTime;
    public float Speed1;
    public float Speed3;
    public float fireDelay;
    public float Delay;
   
        
    

    private GameObject Spell1Instance;
    private GameObject feuerballInstance;
    private float LoadingTime = 0;
    private bool Spell1aktive = false;
    private bool Spell2aktive = false;


    void Awake()
    {
        
    }


    void Update()
    {
    
        //Spell1

        if (Input.GetKeyDown(KeyCode.Mouse0)&& !Spell2aktive)
        {
            Spell1Instance = Instantiate(Spell1, Spawn1.position, fpsCam.transform.rotation);
            Spell1Instance.transform.SetParent(fpsCam.transform);


             Spell1aktive = true;
        }

        if (Spell1aktive)
            LoadingTime += 1;

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (LoadingTime >= requiredLoadingTime)
            {
                Spell1Instance.transform.parent = null;
                Spell1Instance.GetComponent<Rigidbody>().AddForce(fpsCam.transform.forward * Speed1);
            }
            else
                Destroy(Spell1Instance);

            Spell1aktive = false;
            LoadingTime = 0;
        }

        //Spell2
        

        if (Input.GetKeyDown(KeyCode.Mouse1)&& !Spell1aktive)
        {
            StartCoroutine(playFire());
            Spell2aktive = true;
            bool start;
            ArmRight.SendMessageUpwards("PlayAnimFlame", start = true);        
            
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Spell2.GetComponent<ParticleSystem>().Stop();
            Spell2aktive = false;
            
            bool start;
            ArmRight.SendMessageUpwards("PlayAnimFlame", start = false);
        }

        //Spell3

        if(Input.GetKeyDown("e"))
        {
            bool start;
            ArmRight.SendMessageUpwards("PlayAnimFeuerball", start = true);
            StartCoroutine(FeuerBallDelay());
        }

        
    }
   IEnumerator playFire()
    {
        yield return new WaitForSeconds(fireDelay);
        Spell2.GetComponent<ParticleSystem>().Play();
    }

    IEnumerator FeuerBallDelay()
    {
        yield return new WaitForSeconds(Delay);
        FeuerBall();
    }

    void FeuerBall()
    {
        feuerballInstance = Instantiate(feuerball, Spawn3.position, fpsCam.transform.rotation);

        feuerballInstance.GetComponent<Rigidbody>().AddForce(fpsCam.transform.forward * Speed3);
    }
}
