class CartSingleton
{
    private static CartSingleton instance;

    private CartSingleton()
    { }

    public static CartSingleton getInstance()
    {
        if (instance == null)
            instance = new CartSingleton();
        return instance;
    }

    public List<Furniture> furnitures = new List<Furniture>();
    public bool isMadeOrder = false;
}

