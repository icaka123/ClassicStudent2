using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {
    Animator anim;
    public GameObject TrueA;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!TrueA.activeSelf)
        { this.gameObject.SetActive(true);
            anim.SetBool("Explode", true);
        }
	}
    private void Expl()
    { this.gameObject.SetActive(false);
        anim.SetBool("Explode", false);
    }
}
