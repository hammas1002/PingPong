using UnityEngine;
using UnityEngine.UI;

public class ball_movement : MonoBehaviour
{
    private Rigidbody2D ball;
    public float speed;
    public Vector2 direction;
    private AudioSource audioSource;
    public AudioSource gameMusic;
    public AudioClip hitSound;
    public AudioClip dieSound;
    public Text score_text;
    public Animator scoreAnimator;
    private player _player;
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        _player = GameObject.Find("Player").GetComponent<player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ball.velocity = new Vector2(direction.x, direction.y) * speed * Time.deltaTime;

    }
    private void Update()
    {
        if(transform.position.x< -9.25f|| transform.position.x > 9.25f|| transform.position.y < -5.27f|| transform.position.y > 5.27f)
        {
            death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name=="Paddle Floor")
        {
            direction.y *= -1;
        }
        else if (collision.name == "Paddle Wall")
        {
            direction.x *= -1;
        }
        hitEffect();
    }

    void hitEffect()
    {
        _player.playerScore += 1;

        audioSource.pitch = Random.Range(0.8f,1.3f);
        audioSource.PlayOneShot(hitSound);

        scoreAnimator.SetTrigger("effect");

        score_text.text = _player.playerScore.ToString();
        
    }
    void death()
    {
        gameMusic.Stop();
        transform.position = Vector2.zero;
        audioSource.PlayOneShot(dieSound);
        _player.playerScore =0;
        scoreAnimator.SetTrigger("effect");
        
        score_text.text = "Oh No!";
        gameMusic.Play();
    }
}
