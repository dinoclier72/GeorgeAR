using UnityEngine;
using UnityEngine.EventSystems;

public class CircleController : MonoBehaviour, IPointerDownHandler
{
    public Transform imageTransform; // L'image dont on veut modifier la rotation
    public float maxRotation = 45f; // L'angle maximal de rotation de l'image
    public float circleRadius = 50f; // Le rayon du cercle

    private Vector2 center; // Le centre du cercle en pixels
    private float angleRange; // L'angle couvert par le cercle

    void Start()
    {
        // On calcule le centre du cercle en pixels
        center = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position);

        // On calcule l'angle couvert par le cercle
        angleRange = maxRotation * 2f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // On calcule la position du point cliqué par rapport au centre du cercle
        Vector2 clickPos = eventData.position;
        Vector2 offset = clickPos - center;

        // On calcule l'angle formé par le point cliqué par rapport à l'axe vertical passant par le centre du cercle
        float angle = Mathf.Atan2(offset.x, offset.y) * Mathf.Rad2Deg;

        // On limite l'angle à la plage couverte par le cercle
        angle = Mathf.Clamp(angle, -maxRotation, maxRotation);

        // On calcule la rotation de l'image en fonction de l'angle
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

        // On applique la rotation à l'image
        imageTransform.rotation = rotation;
    }

    // Optionnel : on peut dessiner le cercle pour déboguer
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, circleRadius);
    }
}
