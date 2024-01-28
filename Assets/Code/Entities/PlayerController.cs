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
    public AudioSource[] audio;
    // public AudioClip[] audio;
    /*
    audio[0] = pedo impulso
    audio[1] = kaka
    audio[2] = ouch
    audio[3] = blablabla
    audio[4] = closing_door
    audio[5] = pedo menu
    audio[6] = Musica menu
    audio[7] = musica tutorial
    audio[8] = musica level 1
    */
    public float speed = 7.0f, fuel = 0.0f, force = 7.0f;
    public GameDataController gm;
    private bool grounded = false;
    public bool isPause = false;
    public bool timeslow;
    public float timetoslow;
    public GameObject corktime;
    public bool count;
    public float countime;

    void Start(){
        timeslow = false;
        timetoslow = 550.0f;
        corktime.SetActive(false);
        countime=0;
        count=false;
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

        Vector3 position = player.transform.position;
        position.y = Mathf.Clamp(position.y, -2.0f, 11.0f);
        transform.position = position;

        grounded = Physics2D.Raycast(this.transform.position, Vector2.down, 2.0f, groundMask.value);
        animator.SetBool("Flying", !grounded);

        if (Input.GetKeyDown(KeyCode.Space) && fuel > 0.0f) {
            rb.velocity = new Vector2(rb.velocity.x, force);
            fuel -= 10.0f;
            Instantiate(fartVFX, this.transform.position, Quaternion.identity);
            // audio[0].PlayOneShot(audio[0], 1.0f);
            audio[0].Play();
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            Time.timeScale = 0.0f;
            isPause = true;
            pauseMenu.SetActive(true);
        }
        if(count){
          countime++;
          if(countime>=500){

            corktime.SetActive(false);
            count=false;
            countime=0;
          }

        }
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
          corktime.SetActive(true);
          count=true;
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
          speed = 0.0f;
          fuel = 0.0f;
          audio[4].Play();
          StartCoroutine(poopsound());
          SceneManager.LoadScene(1);
        }
        }
}