using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimRight : MonoBehaviour
{
    public void PlayAnimFlame(bool start)
    {
        if (start)
        {
            Debug.Log("nice");
            gameObject.GetComponent<Animator>().SetBool("FlamethrowerAktive", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("FlamethrowerAktive", false);
        }
    }

    public void PlayAnimFeuerball(bool start)
    {
        if (start)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Feuerball");
        }
    }
}
