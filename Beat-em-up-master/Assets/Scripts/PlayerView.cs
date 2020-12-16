using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator animator;
    private bool isTouchGround;
    [SerializeField] private GameObject Sword; 
    public ReactiveProperty<bool> IsTurn = new ReactiveProperty<bool>(false);
    public ReactiveProperty<int> coinCount = new ReactiveProperty<int>();
    public ReactiveProperty<int> playerHP =  new ReactiveProperty<int>(3);
    [SerializeField] private GameObject[] hearts = new GameObject[0];
    [SerializeField] private Image[] heartImage =  new Image[0];
    [SerializeField] private Sprite fullHP;
    [SerializeField] private Sprite emptyHP;
    [SerializeField] private SpriteRenderer playerRenderer;
    [SerializeField] private GameObject playerHitBox;

    bool canShot;

    private const int PLAYER_DEFAULT_LAYER = 12;
    private const int PLAYER_INVINCIBLE_LAYER = 11;
    void Start()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();

        playerRenderer = this.gameObject.GetComponent<SpriteRenderer>();

        animator = this.gameObject.GetComponent<Animator>();
        canShot = true;

        for (int i = 0; i < hearts.Length; i++)
        {
            //if(hearts[i] == null)
            //{
                heartImage[i] = hearts[i].gameObject.GetComponent<Image>(); 
            //}
        }

        // playerHP.Value = hearts.Length;

    }

    void Update()
    {
        
    }

    
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Ground"){
            isTouchGround = true;
            animator.SetBool("isJump",false);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag=="Ground"){
            isTouchGround = false;
            animator.SetBool("isJump",true);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Coin"){
            coinCount.Value += 1;
            other.gameObject.SetActive(false);
            AudioManager.Instance.GetCoin();
        }
        if(other.gameObject.tag == "Enemy"){
            StartCoroutine("EnabledPlayerHit");
            Debug.Log("Imageのナンバー" + playerHP.Value);
            heartImage[playerHP.Value - 1].sprite = emptyHP;
            playerHP.Value --;
        }
    }


    public void ChangeDirection(){
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void Move(float speed){
        _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
        animator.SetBool("isRun",true);
        Debug.Log(speed);
    }

    public void MoveStop(){
        animator.SetBool("isRun",false);
    }

    public void Junp(){
        if(isTouchGround){
            _rigidbody2D.AddForce(transform.up * 1300);
            AudioManager.Instance.Jump();
        }
    }

    public void ThrowSword(){
        if(!canShot) return;
        if(Sword.gameObject.activeInHierarchy==false){
            if(this.transform.localScale.x <= 0){
                Sword.transform.rotation = Quaternion.Euler(0,0,180);
            }else{
                Sword.transform.rotation = Quaternion.Euler(0,0,0);
            }
            Sword.transform.position = this.transform.position;
            Sword.gameObject.SetActive(true);
            canShot = false;
            AudioManager.Instance.ThrowSword();
            StartCoroutine("EnabledShot");
        }
    }

    IEnumerator EnabledShot(){
        yield　return new WaitForSeconds(0.8f);
        canShot = true;
    }

    IEnumerator EnabledPlayerHit(){
        Debug.Log("Hitした");
        this.gameObject.layer = PLAYER_INVINCIBLE_LAYER;
        playerHitBox.gameObject.layer = PLAYER_INVINCIBLE_LAYER;
        for(int i = 0;i < 10;i++){
            this.playerRenderer.color = new Color(0,0,0,0);
            yield return new WaitForSeconds(0.1f);
            this.playerRenderer.color = new Color(1,1,1,1.0f);
            yield return new WaitForSeconds(0.1f);
            //Debug.Log("点滅回数" + i);
        }
        this.gameObject.layer = PLAYER_DEFAULT_LAYER;
        playerHitBox.gameObject.layer = PLAYER_DEFAULT_LAYER;
    }
}
