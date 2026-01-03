using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target; // Player'ý takip edecek
    public float speed = 3f;
    public GameObject deathParticlePrefab;

    void Start()
    {
        // Sahnedeki Player'ý otomatik bulma
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player").transform;
    }

 
    void FixedUpdate()
    {
        if (target != null)
        {
            
            // Player'a doðru yönel ve ilerle
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Yüzünü player'a dön
            transform.LookAt(target);
        }
    }

    public void Die()
    {
        //Efekti oluþtur
        if (deathParticlePrefab != null)
        {
            GameObject vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);

            // Bu efekti 2 saniye sonra sahneden sil (Temizlik)
            Destroy(vfx, 2f);
        }
        Destroy(gameObject);
    }
}