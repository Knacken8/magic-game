using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenHand : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Panel;
    public float timeRemaining = 10;

    void start() 
    {
        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        Animator animator = Panel.GetComponent<Animator>();
        if (animator != null)
        {
            bool toggle = animator.GetBool("toggle");

            animator.SetBool("toggle", !toggle);
        }
    }

    public void OpenPanel()
    {
        Animator animator = Panel.GetComponent<Animator>();
        if (animator != null)
        {
            bool toggle = animator.GetBool("toggle");

            animator.SetBool("toggle", !toggle);
        }
    }
}
