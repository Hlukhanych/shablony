using System;
using System.Collections.Generic;

// Шаблон: "Команда"

interface ICommand
{
    void Execute();
    void Undo();
}

class Item
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public bool IsPurchased { get; set; }

    public Item(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
        IsPurchased = false;
    }
}

class UndoCommand : ICommand
{
    private readonly List<ICommand> commands;

    public UndoCommand(List<ICommand> commands)
    {
        this.commands = commands;
    }

    public void Execute()
    {
        Console.WriteLine("Відміна останньої зміни...");
        if (commands.Count > 0)
        {
            var lastCommand = commands[commands.Count - 1];
            lastCommand.Undo();
            commands.RemoveAt(commands.Count - 1);
        }
        else
        {
            Console.WriteLine("Немає змін для відміни.");
        }
    }

    public void Undo() { }
}

class PurchaseCommand : ICommand
{
    private readonly Item item;

    public PurchaseCommand(Item item)
    {
        this.item = item;
    }

    public void Execute()
    {
        Console.WriteLine($"Покупка \"{item.Name}\" відмічена як виконана.");
        item.IsPurchased = true;
    }

    public void Undo()
    {
        Console.WriteLine($"Відміна покупки \"{item.Name}\".");
        item.IsPurchased = false;
    }
}

class EditItemCommand : ICommand
{
    private readonly Item item;
    private readonly string previousName;
    private readonly int previousQuantity;

    public EditItemCommand(Item item, string previousName, int previousQuantity)
    {
        this.item = item;
        this.previousName = previousName;
        this.previousQuantity = previousQuantity;
    }

    public void Execute()
    {
        Console.WriteLine($"Товар \"{previousName}\" редагований. Нова назва: \"{item.Name}\", Нова кількість: {item.Quantity}.");
    }

    public void Undo()
    {
        Console.WriteLine($"Відміна редагування товару. Попередня назва: \"{previousName}\", Попередня кількість: {previousQuantity}.");
        item.Name = previousName;
        item.Quantity = previousQuantity;
    }
}

class ShoppingList
{
    private readonly List<Item> items;
    private readonly List<ICommand> commands;

    public ShoppingList()
    {
        items = new List<Item>();
        commands = new List<ICommand>();
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public Item GetItemByName(string name)
    {
        return items.Find(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public void MarkAsPurchased(Item item)
    {
        var purchaseCommand = new PurchaseCommand(item);
        purchaseCommand.Execute();
        commands.Add(purchaseCommand);
    }

    public void EditItem(Item item, string newName, int newQuantity)
    {
        var editCommand = new EditItemCommand(item, item.Name, item.Quantity);
        editCommand.Execute();
        item.Name = newName;
        item.Quantity = newQuantity;
        commands.Add(editCommand);
    }

    public void UndoLastChange()
    {
        var undoCommand = new UndoCommand(commands);
        undoCommand.Execute();
    }

    public void DisplayList()
    {
        Console.WriteLine("Список покупок:");
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Name} - Кількість: {item.Quantity}, Куплено: {item.IsPurchased}");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        var shoppingList = new ShoppingList();

        shoppingList.AddItem(new Item("Хліб", 2));
        shoppingList.AddItem(new Item("Молоко", 1));
        shoppingList.AddItem(new Item("Яйця", 12));

        shoppingList.DisplayList();

        shoppingList.EditItem(shoppingList.GetItemByName("Хліб"), "Багет", 3);
        shoppingList.MarkAsPurchased(shoppingList.GetItemByName("Молоко"));

        shoppingList.DisplayList();

        shoppingList.UndoLastChange();

        shoppingList.DisplayList();

        Console.ReadLine();
    }
}
