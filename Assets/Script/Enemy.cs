using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private float speed;
    [SerializeField] private float rangeshoot = 1f;
    [SerializeField] private LayerMask playerlayer;
    [SerializeField] private Transform fireposition;
    [SerializeField] private GameObject bulletEnemy;
    [SerializeField] private float cooldownshoot;
    [SerializeField] private float bulletSpeed;

    private bool canshoot;
    private bool isDead = false;
    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDead)
        {
            EnemyMove();

            Collider2D col = Physics2D.OverlapCircle(fireposition.position, rangeshoot, playerlayer);
            if (col != null && !canshoot)
            {
                canshoot = true;
                StartCoroutine(enemiattack());
            }
        }
    }

    private void EnemyMove()
    {
        float distance = Vector2.Distance(transform.position, Player.Instance.gameObject.transform.position);
        if (distance > range)
        {
            Vector2 direction = (Player.Instance.gameObject.transform.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDead && collision.CompareTag("bulletplayer"))
        {
            isDead = true;
            this.GetComponent<Collider2D>().enabled = false;
            Destroy(collision.gameObject);
            animator.SetTrigger("die");
            Destroy(gameObject, 1.5f);
        }
    }

    IEnumerator enemiattack()
    {
        while (true)
        {
            Collider2D col = Physics2D.OverlapCircle(fireposition.position, rangeshoot, playerlayer);
            if (col == null)
            {
                canshoot = false;
                yield break;
            }

            GameObject bullet = Instantiate(bulletEnemy, fireposition.position, fireposition.rotation);
            Vector2 direction = (Player.Instance.gameObject.transform.position - transform.position).normalized;
            bullet.transform.right = direction;

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * bulletSpeed;
            }

            yield return new WaitForSeconds(cooldownshoot);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(fireposition.position, rangeshoot);
    }
}
