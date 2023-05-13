using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageSpamer : MonoBehaviour { 
    // Arrastra la imagen que quieres usar desde el editor de Unity

public Image imagePrefab; 
    // El número máximo de imágenes que se pueden colocar en la pantalla
    public int maxImages = 10; 
    // La lista de imágenes que se han colocado en la pantalla
    private List<Image> images = new List<Image>(); 
     //El ancho y el alto de la pantalla en píxeles
    private float screenWidth; 
    // La posición inicial donde se colocará la primera imagen
    private Vector2 initialPosition = new Vector2(-6.5f, 2.99f); 
    // La distancia horizontal y vertical entre cada imagen
    private float horizontalSpacing = 0.1f; 
    private float verticalSpacing = 0.1f; 
    //La posición actual donde se colocará la próxima imagen
    private float currentX; 
    private float currentY; 
    void Start() { 
        // Obtener el ancho y el alto de la pantalla en píxeles
        screenWidth = 10; 
           // Inicializar la posición actual con la posición inicial
           currentX = initialPosition.x; currentY = initialPosition.y; 
    } 
    void Update() { 

        // Si se presiona la tecla A y no se ha alcanzado el número máximo de imágenes

               if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.R)) && images.Count < maxImages) { 
            // Crear una nueva imagen y agregarla a la lista
            Image newImage = Instantiate(imagePrefab); images.Add(newImage); 
            // Asignar la posición actual a la imagen
            newImage.rectTransform.anchoredPosition = new Vector2(currentX, currentY); 
            // Incrementar la posición x por el ancho de la imagen más el espaciado horizontal
            currentX += newImage.rectTransform.rect.width + horizontalSpacing; 
            // Si la posición x supera el ancho de la pantalla, reiniciarla a la posición inicial y decrementar la posición y por el alto de la imagen más el espaciado vertical
            
            if (currentX > screenWidth) 
            { 
                currentX = initialPosition.x; 
                currentY -= newImage.rectTransform.rect.height + verticalSpacing; 
            }
        }
    }
}