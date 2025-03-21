using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    private Rigidbody _playerRb;
    private Animator _playerAnim;
    
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource _audioSource;
    
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isGrounded;
    public bool gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _playerRb = GetComponent<Rigidbody>();
        _playerAnim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameOver) {
            _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            _playerAnim.SetTrigger("Jump_trig");
            _audioSource.PlayOneShot(jumpSound, 1.0f);
            dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            gameOver = true;
            Debug.Log("Game Over!");
            _playerAnim.SetBool("Death_b", true);
            _playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            _audioSource.PlayOneShot(crashSound, 1.0f);
            dirtParticle.Stop();
        }
        isGrounded = true;
    }

}