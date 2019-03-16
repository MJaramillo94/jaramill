using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    /*
       Variables for setting text values 
    */
    private int count;
    private int lives;
    public Text lifeText;
    public Text countText;
    public Text winText;


    // audio source to play for pickups
    AudioSource audioData;
    public AudioSource audioClip;

    // CharacterController controller;
    public  Camera GetCamera;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;

    
    private void Start()
    {

        //variables for score and lives
        count = 0;
        lives = 3;

        //Set WinText to null
        winText.text = "";
        
        //update score and lives.
        SetCountText();
        SetLivesText();

        //get audiosource to play
        audioClip = GetComponent<AudioSource>();
        audioData = audioClip;

        //player movement
        agent.updateRotation = false;
    }

    private void Awake()
    {
        // Get main Camera on awake
        GetCamera = Camera.main;
    }

    // Destroy everything that enters the trigger
    void OnTriggerEnter(Collider other)
    {

        //For pickups
        if(other.gameObject.CompareTag("PickUps"))
        {
            other.gameObject.SetActive(false);
            count++;
            Debug.Log("Picked up: " + count);
            SetCountText();

            audioData.Play(0);
            Debug.Log("Played audio.");

        }

        //For when enemies collide
        if(other.gameObject.CompareTag("Enemy"))
        {
            lives--;
            Debug.Log("You lost a life.");
            SetLivesText();
            Debug.Log(lives + " remaining.");
            
        }
    }


    //Progress Update Lives
    void SetLivesText()
    {
        lifeText.text = "Lives: " + lives.ToString();
        if(lives == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
   
    //Progress update Score
    void SetCountText ()
    {
        countText.text = "Score: " + count.ToString();
        if(count >= 16)
        {
            winText.text = "You Win!";
        }
    }
  
    //Player movement
    void Update()
    {
       
        
        if (Input.GetMouseButtonDown(button: 0))
        {
           Ray ray = GetCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point); //MOVE OUR AGENT
            }
        }


        if(agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);

        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
        


    }


}
