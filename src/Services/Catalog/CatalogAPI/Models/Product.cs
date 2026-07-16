namespace CatalogAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        /*
         * string is not null type. string? is null type
         * default (The Literal): Evaluates to the absolute default value of the target type. 
         * For reference types (like string or custom classes), this value is null. 
         * For value types, it is usually zero or false (0 for int, false for bool).
         * 
         * ! (The Null-Forgiving Operator): Tells the C# compiler: 
         * "I know this expression evaluates to null right now, but trust me, 
         * it won't be null when the program runs. Do not throw a warning.
         * 
         * */

        public string Description { get; set; } = default!;
        public List<string> Category { get; set; } = new();
        public string ImageFile { get; set; } = default!;
        public decimal Price { get; set; }

    }
}
