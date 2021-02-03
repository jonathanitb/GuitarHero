using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Activator : MonoBehaviour
{
    public KeyCode key;
    bool active = false;
    GameObject note;
    SpriteRenderer sr;
    Color old;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        old = sr.color;
    }
    private void Update()
    {
        if (Input.GetKeyDown(key) )
        {
            StartCoroutine(Pressed());
        }
            if (Input.GetKeyDown(key) && active)
        {
            Destroy(note);
            addScore();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        active = true;
        if (collision.gameObject.tag == "Note")
        {
            note = collision.gameObject;
           
        }
    }

    void addScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score")+100);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        active = false;
    }
  private IEnumerator Pressed(){
        Color old = sr.color;
        sr.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.05f);
        sr.color=old;
         }
}
