using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagePlacer : MonoBehaviour
{
    // Arrastra la imagen que quieres usar desde el editor de Unity
    public Image imagePrefab;

    // El número máximo de imágenes que se pueden colocar en la pantalla
    public int maxImages = 20;

    // La lista de imágenes que se han colocado en la pantalla
    private List<Image> images = new List<Image>();

    // El ancho y el alto de la pantalla en píxeles
    private float screenWidth;
    private float screenHeight;

    // La posición inicial donde se colocará la primera imagen
    private Vector2 initialPosition = new Vector2(-6.69f, 3.28f);

    // La distancia horizontal y vertical entre cada imagen
    private float horizontalSpacing = 3.9f;
    private float verticalSpacing = 3.9f;

    // El índice de la fila y la columna actual donde se colocará la próxima imagen
    private int currentRow = 0;
    private int currentColumn = 0;

    void Start()
    {
        // Obtener el ancho y el alto de la pantalla en píxeles
        screenWidth = 17;
        screenHeight = 10;
    }

    void Update()
    {
        // Si se presiona la tecla A y no se ha alcanzado el número máximo de imágenes
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.R)) && images.Count < maxImages)
        {
            // Crear una nueva imagen y agregarla a la lista
            Image newImage = Instantiate(imagePrefab);
            images.Add(newImage);

            // Calcular la posición donde se colocará la imagen
            Vector2 position = initialPosition + new Vector2(horizontalSpacing * currentColumn, -verticalSpacing * currentRow);

            // Ajustar la posición si está fuera de los límites de la pantalla
            if (position.x + newImage.rectTransform.rect.width > screenWidth)
            {
                position.x = screenWidth - newImage.rectTransform.rect.width;
            }
            if (position.y - newImage.rectTransform.rect.height < screenHeight)
            {
                position.y = newImage.rectTransform.rect.height;
            }

            // Asignar la posición a la imagen
            newImage.rectTransform.anchoredPosition = position;

            // Incrementar el índice de la columna actual
            currentColumn++;

            // Si se ha llegado al final de la fila, pasar a la siguiente fila y reiniciar la columna
            if (position.x + newImage.rectTransform.rect.width + horizontalSpacing > screenWidth)
            {
                currentRow++;
                currentColumn = 0;
            }
            if (position.x + newImage.rectTransform.rect.height + verticalSpacing > screenHeight)
            {
                currentRow = 0;
                currentColumn++;
            }
        }
    }
}
