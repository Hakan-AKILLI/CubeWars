using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Ayarlar")]
    public float mouseSensitivity = 2f;


    public Transform playerCamera;

    [Header("Ateþ Etme")]
    public Animator gunAnimator;
    public float range = 100f;

    [Header("Can Sistemi")]
    public int health = 3;
    public GameObject gameOverText;

    float xRotation = 0f;
    bool isDead = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (gameOverText != null) gameOverText.SetActive(false);
    }

    void Update()
    {
        if (isDead) return;

        // --- Mouse ayarlarý ---
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        //  KAFANIN (KAMERANIN) BAKMASI 
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        if (playerCamera != null)
        {
            playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }

        // VÜCUDUN (BU OBJENÝN) DÖNMESÝ (Saða/Sola)
        transform.Rotate(Vector3.up * mouseX);

        //  Ateþ Etme
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (gunAnimator != null) gunAnimator.SetTrigger("Shoot");


        RaycastHit hit;
        if (playerCamera != null && Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, range))
        {
            EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.Die();
            }
        }
    }

    //ÇARPIÞMA
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isDead)
        {
            TakeDamage();
            Destroy(collision.gameObject); // Düþmaný yok et
        }
    }

    void TakeDamage()
    {
        health--;
        Debug.Log("Hasar alýndý! Kalan Can: " + health);

        if (health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isDead = true;
        if (gameOverText != null) gameOverText.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }
}