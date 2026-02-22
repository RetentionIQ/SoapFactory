using UnityEngine;
using System.Collections.Generic;

public class Cannon : Machines
{
    [SerializeField] private Transform cannonVisual;
    public Rigidbody projectilePrefab;   // The projectile to shoot
    public Transform spawnPoint;         // Where the projectile should spawn
    public float launchSpeed = 20f;      // How strong the shot is
    public float spinSpeed = 1f;
    public Transform targetTransform;

    private float timeBtwShoot;
    private CannonInventory cannonInventory;


    // Controls the magnitude of the error when a miss occurs.
    private const float MissErrorMagnitude = 0.5f;

    public List<ProducedProduct> productObjectPooling = new List<ProducedProduct>();

    public static Cannon Instance;

    private Rigidbody projectile;



    private void Awake()
    {
        Instance = this;
        // Ensure Machines.cs has a 'GetComponent<CannonInventory>()' if CannonInventory is on a different object
        cannonInventory = GetComponent<CannonInventory>();
    }

    private void Start()
    {
        timeBtwShoot = actionSpeed;
    }

    private void Update()
    {
        timeBtwShoot -= Time.deltaTime;
        if (timeBtwShoot > 0) return;

        if (cannonInventory.GetProductQueue().Count <= 0) return;


        OnProductPassedEventCaller();

        //Get the parent(not prefab) cannonInventory.GetProductQueue().Peek()

        SetProjectilePrefab(cannonInventory.GetProductQueue().Peek().GetProducedProduct());

        timeBtwShoot = actionSpeed;

        ShootAt(targetTransform.position);
    }

    public void ShootAt(Vector3 target)
    {
        if (projectilePrefab == null || spawnPoint == null)
        {
            Debug.LogWarning("Assign projectilePrefab and spawnPoint!");
            return;
        }

        Product currentProductToShoot = null;
        if (cannonInventory.GetProductQueue().TryDequeue(out currentProductToShoot) == false)
        {
            Debug.LogError("Cannon attempted to shoot but the product queue was empty. Stopping shot.");
            return;
        }

        bool productFoundInPool = false;

        // Reusing pool logic from previous version...
        if (productObjectPooling.Count > 0)
        {
            for (int i = 0; i < productObjectPooling.Count; i++)
            {
                if (productObjectPooling[i].productParent.GetProductName() == currentProductToShoot.GetProductName())
                {
                    productObjectPooling[i].transform.position = spawnPoint.position;
                    productObjectPooling[i].gameObject.SetActive(true);
                    projectile = productObjectPooling[i].GetComponent<Rigidbody>();
                    projectile.GetComponent<ProducedProduct>().productParent = currentProductToShoot;
                    productObjectPooling.RemoveAt(i);
                    productFoundInPool = true;
                    break;
                }
            }
        }

        if (productFoundInPool == false)
        {
            projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
            projectile.GetComponent<ProducedProduct>().productParent = currentProductToShoot;
        }


        // 1. Calculate the initial, perfect direction (using your known working 0.3f factor)
        // This is the ideal trajectory required to hit the target.
        Vector3 perfectDirection = (target - spawnPoint.position).normalized + Vector3.up * 0.3f;
        perfectDirection = perfectDirection.normalized;

        Vector3 launchDirection = perfectDirection;

        if (Random.value < cannonMissChance)
        {
            // If the roll is less than missChance (e.g., Random.value = 0.2, missChance = 0.3), 
            // INTRODUCE A SIGNIFICANT ERROR.

            // Generate a random deviation vector.
            Vector3 randomError = Vector3.Cross(perfectDirection, Random.insideUnitSphere).normalized;

            // Scale the error by the constant MissErrorMagnitude to ensure the miss is significant.
            randomError *= MissErrorMagnitude;

            // Combine the perfect direction with the error.
            launchDirection = perfectDirection + randomError;

            // Optional: Log the miss for debugging
            Debug.Log($"Miss Roll Succeeded! Introducing error with {cannonMissChance * 100}% chance.");
        }


        projectile.velocity = launchDirection.normalized * launchSpeed;

        cannonVisual.transform.forward = -launchDirection;

        // Add spin for realism
        projectile.angularVelocity = Random.onUnitSphere * (spinSpeed * Mathf.Deg2Rad);

        projectile.transform.rotation = Quaternion.LookRotation(projectile.velocity);
    }

    public void SetProjectilePrefab(Rigidbody projectilePrefab)
    {
        this.projectilePrefab = projectilePrefab;
    }


    public void AddProductToPool(ProducedProduct product)
    {
        productObjectPooling.Add(product);
        product.transform.position = spawnPoint.position;
        product.gameObject.SetActive(false);
    }

    public override void BuySpeed()
    {
        // Example logic for speed upgrade
        actionSpeed -= .3f;
        timeBtwShoot = 0f;
    }

    public override void BuyAccuracy()
    {
        const float accuracyImprovementStep = 0.05f;

        cannonMissChance -= accuracyImprovementStep;

        cannonMissChance = Mathf.Max(0f, cannonMissChance);

        Debug.Log($"Cannon accuracy improved! New Miss Chance: {cannonMissChance * 100}%");
    }

    public override void BuyPerfection()
    {
        throw new System.NotImplementedException();
    }
}