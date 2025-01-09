using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;
    public GameObject ProjectilePrefab;
    public Transform ProjectileSpawnPoint;
    public float WalkSpeed = 2f;
    public float ProjectileSpeed = 10f;
    public float ProjectileDelay = 0.19f;
    public float InitialAngle = 0f; 

    private Animator animator;
    private Animator EnemyAnimator;

    void Start()
    {
        animator = Player.GetComponent<Animator>();
        EnemyAnimator = Enemy.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            WalkF();
        }
        else
        {
            StopWalkingF();
        }

        if (Input.GetKey(KeyCode.A))
        {
            WalkB();
        }
        else
        {
            StopWalkingB();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) SuAtack();
        if (Input.GetKeyDown(KeyCode.Alpha2)) SdAtack();
        if (Input.GetKeyDown(KeyCode.W)) Jump();
        if (Input.GetKeyDown(KeyCode.S)) Hide();
        if (Input.GetKeyDown(KeyCode.Alpha3)) StartCoroutine(LuAtack());
        if (Input.GetKeyDown(KeyCode.Alpha4)) StartCoroutine(LdAtack());

        if (EnemyAnimator.GetBool("Lose") == true)
        {
            Win();
        }
    }

    public void Win()
    {
        animator.SetBool("Win", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Killer"))
        {
            Lose();
        }
    }
    public void Lose()
    {
        animator.SetBool("Lose", true);
    }

    public void SdAtack()
    {
        animator.SetTrigger("SdAtack");
    }

    public void SuAtack()
    {
        animator.SetTrigger("SuAtack");
    }

    public void WalkF()
    {
        animator.SetBool("WalkF", true);
        Player.transform.Translate(Vector3.forward * WalkSpeed * Time.deltaTime);
    }

    public void StopWalkingF()
    {
        animator.SetBool("WalkF", false);
    }

    public void WalkB()
    {
        animator.SetBool("WalkB", true);
        Player.transform.Translate(-Vector3.forward * WalkSpeed * Time.deltaTime);
    }

    public void StopWalkingB()
    {
        animator.SetBool("WalkB", false);
    }

    public IEnumerator LuAtack()
    {
        animator.SetTrigger("LuAtack");
        yield return new WaitForSeconds(ProjectileDelay);

        // Disparo completamente horizontal
        ShootProjectile(Vector3.forward);
    }

    public IEnumerator LdAtack()
    {
        animator.SetTrigger("LdAtack");
        yield return new WaitForSeconds(ProjectileDelay);

        // Disparo diagonal hacia abajo
        ShootProjectile(new Vector3(0, -0., 1));
    }

    public void Hide()
    {
        animator.SetTrigger("Hide");
    }

    public void Jump()
    {
        animator.SetTrigger("Jump");
    }

    private void ShootProjectile(Vector3 direction)
    {
        if (ProjectilePrefab != null && ProjectileSpawnPoint != null)
        {
            // Normalizar la dirección para garantizar magnitud consistente
            direction = direction.normalized;

            // Calcular la rotación para que apunte en la dirección correcta
            Quaternion rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(90, 0, 0); // Añadir 90 grados en el eje X

            // Instanciar el proyectil en el punto de generación con la rotación ajustada
            GameObject projectile = Instantiate(ProjectilePrefab, ProjectileSpawnPoint.position, rotation);

            // Aplicar movimiento al proyectil
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = direction * ProjectileSpeed;
            }

            // Opcional: Destruir el proyectil después de un tiempo
            Destroy(projectile, 5f);
        }
    }
}
