using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public GameObject fartVFX, pauseMenu;
    public Transform player;
    public SpriteRenderer sprite;
    public Animator animator;
    public LayerMask groundMask;
    public Rigidbody2D rb;
    public ScreenPoopScript screen;
    public GameDataController gm;
    public float speed = 7.0f, fuel = 0.0f;
    private bool grounded = false;
    public bool timetopluge; 
    public float plugtime;
    public bool isPause = false;
    public bool timeslow;
    public float timetoslow;
    public GameObject plug;
    public AudioSource[] audio;
    public AudioClip[] audioclip;
    
    
    /*
    1 -- Pedo impulso
    2 -- Kaka
    3 -- ouch
    4 -- Pedo menu
    5 -- Closing Door
    */


    void Start(){
        timeslow = false;
        timetoslow = 550.0f;
        plug.SetActive(false);
        timetopluge = false;
        plugtime = 300;
    }


    void Update() {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !isPause) {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
            sprite.flipX = true;
        }

        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && !isPause) {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
            sprite.flipX = false;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) {
            animator.SetBool("Running", true);
        }else{
            animator.SetBool("Running", false);
        }

        if(timeslow){
            timetoslow--;
            if(timetoslow <= 0){
                timeslow = false;
                timetoslow = 500;
                speed = 7.0f;
            }
        }

        if (timetopluge)
        {
            plugtime--;
            if (plugtime <= 0)
            {

                timetopluge = false;
                plugtime = 300;
                plug.SetActive(false);
            }

        }

        Vector3 position = player.transform.position;
        position.y = Mathf.Clamp(position.y, -2.0f, 10.0f);
        transform.position = position;

        grounded = Physics2D.Raycast(this.transform.position, Vector2.down, 2.0f, groundMask.value);
        animator.SetBool("Flying", !grounded);

        if (Input.GetKeyDown(KeyCode.Space) && fuel > 0.0f) {
            rb.velocity = new Vector2(rb.velocity.x, 8.0f);
            fuel -= 5.0f;
            Instantiate(fartVFX, this.transform.position, Quaternion.identity);
            audio[0].PlayOneShot(audioclip[0]);
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            Time.timeScale = 0.0f;
            isPause = true;
            pauseMenu.SetActive(true);
        }
    }

    public IEnumerator ChangeScenes()
    {
      yield return new WaitForSeconds(1.0f);
      audio[0].PlayOneShot(audioclip[1]);
      yield return new WaitForSeconds(2.5f);
      SceneManager.LoadScene(2);
    }

    public void OnCollisionEnter2D(Collision2D coll) {

        if(coll.gameObject.CompareTag("SodaPerk")){
          Destroy(coll.gameObject);
          if (fuel < 100.0f) {
              fuel += 100.0f - fuel;
          }
        }

        if (coll.gameObject.CompareTag("PoopEnemy")) {
            screen.isDirty = true;
        }

        if (coll.gameObject.CompareTag("PaperPerk")) {
            Destroy(coll.gameObject);
            screen.isPaper = true;
        }
        if (coll.gameObject.CompareTag("CorkPerk")) {
          Destroy(coll.gameObject);
          TimeScript.instance.levelOneCountdown += 5.0f;
          plug.SetActive(true);
          timetopluge = true;
        }
    }
      IEnumerator poopsound()
        {
            yield return new WaitForSeconds(1.0f);
            audio[1].Play();
          }
       public void OnTriggerEnter2D(Collider2D coll) {
         if(coll.gameObject.CompareTag("HumanEnemy"))
         {
           speed = 1.0f;
           timeslow = true;
         }

        if(coll.gameObject.CompareTag("Door")){
            
          coll.GetComponent<Animator>().SetTrigger("Arrival");
          TimeScript.instance.stopTimer = true;
          if(GameManager.game.isLevel1){
            float aux_time = TimeScript.instance.ObtainTime();
            int minutes = Mathf.FloorToInt(aux_time / 60);
            int seconds = Mathf.FloorToInt(aux_time % 60);
            if (minutes < GameManager.game.minutes) {
                GameManager.game.minutes = minutes;
                GameManager.game.seconds = seconds;
                gm.DataSave();
            }else if (minutes == GameManager.game.minutes) {
                if (seconds < GameManager.game.seconds) {
                    GameManager.game.minutes = minutes;
                    GameManager.game.seconds = seconds;
                    gm.DataSave();
                }
            }
          }
          GameManager.game.isLevel1 = false;
          speed = 0.0f;
          fuel = 0.0f;
           // Debug.Log("GameOver");
           audio[0].PlayOneShot(audioclip[4]);
           StartCoroutine(ChangeScenes());
        }
    }
}
