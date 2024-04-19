using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    // Variables para mantener el estado del jugador
    public int currentHP;
    public bool isAlive;
    public string playerName;
    // Agrega más variables según sea necesario para el manejo de datos del jugador

    private void Awake()
    {
        // Asegurar que solo haya una instancia del PlayerManager en la escena
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantener el GameObject en las transiciones de escena
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruir este GameObject
        }
    }

    private void Start()
    {
        // Inicializar valores iniciales del jugador
        currentHP = 30;
        isAlive = true;
        playerName = "Heroe"; // Nombre predeterminado del jugador
    }

    // Método para actualizar la vida del jugador
    public void UpdateHP(int amount)
    {
        currentHP += amount;
        if (currentHP <= 0)
        {
            currentHP = 0;
            isAlive = false;
            // Lógica adicional para el manejo de muerte del jugador
        }
    }

    // Otros métodos para el manejo de acciones del jugador, compra de items, etc.
}
