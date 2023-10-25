public class Book
{
    public string Title { get; set; }
}

public class Program
{
    public static void Main()
    {
        // Skapa en instans av Book med default-konstruktorn
        Book book = new Book();

        // Sätt egenskapen Title
        book.Title = "The Great Gatsby";

        // Nu har du en instans av Book med Title satt
        Console.WriteLine($"Bokens titel är: {book.Title}");
    }
}
aafaljgfagjpoagoåad