using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Image image; // L'image à laquelle on veut associer le bouton
    public GameObject buttonPrefab; // Le préfabriqué du bouton que l'on veut faire apparaître
    public float buttonOffset = 10f; // L'offset vertical du bouton par rapport à l'image

    private GameObject buttonInstance; // L'instance du bouton actuellement affiché (null si pas affiché)
    void Awake(){
        image = GetComponent<Image>();
    }
    void Update()
    {
        // On vérifie si le bouton n'est pas déjà affiché
        if (buttonInstance == null)
        {
            // On vérifie si l'utilisateur a cliqué sur l'image
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = Input.mousePosition;
                if (RectTransformUtility.RectangleContainsScreenPoint(image.rectTransform, mousePos))
                {
                    // On instancie le bouton et on le place en dessous de l'image
                    buttonInstance = Instantiate(buttonPrefab, transform);
                    buttonInstance.transform.position = image.transform.position - new Vector3(0f, image.rectTransform.rect.height / 2f + buttonOffset, 0f);
                    buttonInstance.GetComponent<Button>().onClick.AddListener(Die);
                }
            }
        }
        else
        {
            // On vérifie si l'utilisateur a cliqué en dehors du bouton
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = Input.mousePosition;
                if (!RectTransformUtility.RectangleContainsScreenPoint(buttonInstance.GetComponent<RectTransform>(), mousePos))
                {
                    // On détruit le bouton
                    Destroy(buttonInstance);
                    buttonInstance = null;
                }
            }
        }
        void Die()
        {
            Destroy(this.gameObject);
        }
    }
}
