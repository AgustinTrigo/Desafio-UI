using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private bool death = false;
    [SerializeField] private Vector3 resetPosition = (new Vector3 (0, 0, 0));
    [SerializeField] private GameObject coins;
    [SerializeField] private Animator animplayer;
    [SerializeField] private int difficulty;
    [SerializeField] LayerMask groundLayer;
    private Rigidbody rb;
    private ItemManager mgItem;
    //private GameManager gm;
    
    //private int jewels = 0;
    private int boxes = 0;



    [SerializeField] protected PlayerData myData;

    public static event Action onDeath;
    public static event Action<bool> onEnemyChange;

    //public static event Action onTutorial;

    void Start()
    {
       
      //SelectDificult();
        rb = GetComponent<Rigidbody>();
        mgItem = GetComponent<ItemManager>();
        //gm = GetComponent<GameManager>();

        //StartCoroutine(TutorialBehaviour());
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(gm.IsGameRunning())
        //{
            Run(Vector3.forward);
        //}
        
        Move();
        PlayerJump();

    }

    /*
    IEnumerator TutorialBehaviour()
    {
        yield return new WaitForSeconds(6f);
        gm.ChangeStateOfGame();
    }*/

    
    private void Run(Vector3 direction)
    {
        transform.position =  transform.position += direction * myData.SpeedPlayer * Time.deltaTime;
    }



    public virtual void Move()
    {
        if (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.LeftArrow))
        {

            transform.position = transform.position += (new Vector3(-0.38f, 0f, 0) * myData.SideSpeedPlayer);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {

           transform.position = transform.position += (new Vector3(0.38f, 0f, 0) * myData.SideSpeedPlayer);

        }

    }


    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animplayer.SetBool("IsRun", false);  
            animplayer.SetBool("IsJump", true);

            if (IsGrounded())
            {
                rb.AddForce(0, 1 * myData.PlayerJumpForce, 0);
            }
            
        }
        else
        {
            animplayer.SetBool("IsRun", true);
            animplayer.SetBool("IsJump", false);
            
        }
       
    }

    private bool IsGrounded()
    {
        if(Physics.Raycast(transform.position, Vector3.down, 0.5f, groundLayer))
        {
            return true;
        }
        else return false;
         
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            GameObject coin = other.gameObject;
            coin.SetActive(false);
            mgItem.AddinventoryOne(coin);
            mgItem.GetInventoryOne();
            mgItem.countRewards(coin);

        }

        if (other.gameObject.CompareTag("buff"))
        {
            GameObject buff = other.gameObject;
            buff.SetActive(false);
            
        }

        if (other.gameObject.CompareTag("box"))
        {
            GameObject box = other.gameObject;
            box.SetActive(false);
            boxes++;
            Debug.Log("Numero de cajas" + "" + boxes);
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            //onDeath?.Invoke();
            onEnemyChange?.Invoke(true);
        }

    }



    /*
    private void SelectDificult()
    {
        switch (difficulty)
        {
            case 1:
                Debug.Log("Easy Mode");
                myData.SpeedPlayer + 3.0f;
                break;
            case 2:
                Debug.Log("Normal Mode");
                speedPlayer = 3.5f;
                break;
            case 3:
                Debug.Log("Hard Mode");
                speedPlayer = 4.0f;
                break;

            default:
                speedPlayer = 3.0f;
                break;
        }
    }*/

    
    public float GetSpeedPlayer()
    {
        return myData.SpeedPlayer;
    }
    public Vector3 GetPlayerPosition()
    {
        return resetPosition;
    }

    public bool GetPlayerEstate()
    {
        return death;
    }


}
