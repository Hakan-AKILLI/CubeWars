using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target; // Player'ý takip edecek
    public float speed = 3f;
    public GameObject deathParticlePrefab; // Patlama efekti (Madde 3)

    void Start()
    {
        // Sahnedeki Player'ý otomatik bul (Tag "Player" olmalý)
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Madde 6: FixedUpdate (Fizik tabanlý veya düzenli hareketler için idealdir)
    void FixedUpdate()
    {
        if (target != null)
        {
            // Madde 2: Vector3 (Hareket hesaplamasý)
            // Player'a doðru yönel ve ilerle
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Yüzünü player'a dön
            transform.LookAt(target);
        }
    }

    public void Die()
    {
        // 1. Efekti oluþtur
        if (deathParticlePrefab != null)
        {
            // Oluþturulan efekti geçici bir deðiþkene al (vfx)
            GameObject vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);

            // 2. Bu efekti 2 saniye sonra sahneden sil (Temizlik)
            Destroy(vfx, 2f);
        }

        // 3. Düþmaný yok et
        Destroy(gameObject);
    }
}