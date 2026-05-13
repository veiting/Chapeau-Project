namespace Chapeau_Project.Models;

public class MenuItem
{
    public MenuItem(int menuItemId, string name, string description, double price, int stock, string category, string card, bool isActive)
    {
        MenuItemId = menuItemId;
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Category = category;
        Card = card;
        IsActive = isActive;
    }

    public int MenuItemId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public double Vat { get; set; }
    public int Stock { get; set; }
    public string Category { get; set; }
    public string Card {get; set;}
    public bool IsActive { get; set; }

    public MenuItem()
    {
        
    }
}