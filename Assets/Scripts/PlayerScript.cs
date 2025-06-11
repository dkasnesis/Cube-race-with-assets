using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    int forwardForce = 2000;
    int sideForce = 1000;
    bool onGround = true;
    int jumpForce = 1000;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0,0,-forwardForce * Time.deltaTime); // askw dinami sto koutaki gia na kinithei anapoda ston aksona Z

        if (Input.GetKey(KeyCode.A) ||  Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(sideForce * Time.deltaTime,0,0, ForceMode.Force); // ForceMode.Force einai gia smooth kinisi
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.Force); // ForceMode.Force einai gia smooth kinisi
        }

        // if patisw space -> JUMP
        if (Input.GetKeyDown(KeyCode.Space) && onGround == true)
        {
            rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.Impulse);
        }


        if (transform.position.y < -4f)
        {
            StartCoroutine(reloadScene());
        }

        IEnumerator reloadScene()
        {
            yield return new WaitForSeconds(2); // to wait
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // restart scene
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            forwardForce = 0;
            sideForce = 0;
        }

        if (collision.gameObject.name == "Finish")
        {
            SceneManager.LoadScene("EndScene");
        }

        // if eimai patwma -> onGround = true
        if (collision.gameObject.name == "Ground")
        {
            onGround = true;
        }

    }

    private void OnCollisionExit(Collision collision) // DEN AKOUMPAEI TIPOTA
    {
        // onGround = false; diladi eimai ston aera
        onGround = false;
    }
   
}
