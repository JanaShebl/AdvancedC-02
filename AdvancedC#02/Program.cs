namespace AdvancedC_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region starter code

            #endregion

            #region Task01

            /* Write a single method called SearchProducts that accepts 
                two parameters:  
                1. The product list (List<Product>)  
                2. A delegate representing the filter condition (Func<Product , bool>)  
                The method should return a List containing only the products that satisfy the 
                condition. Then, call this method four times with different lambda expressions to 
                perform the following searches:  
                1. All Electronics products  
                2. Products cheaper than $50  
                3. Products that are in stock (Stock > 0)  
                4. Clothing products under $100
            */ 

            // استخدمت func عشان عايزة اباصي الاوبجيكت و بعد كده اعمل فلتر على حسب ما اليوزر يدخل و بعدها يرجع bool 
            // كان ممكن استخدم pridicate بس الفايل كاتب func ف استخدمتها
            Func<Product, bool> isElectronic = p => p.Category == "Electronics";
            Func<Product, bool> isCheaperThan50 = p => p.Price < 50;
            Func<Product, bool> inStock = p => p.Stock > 0;
            Func<Product, bool> clothesUnder100 = p => p.Category == "Clothing";
            List<Product> electronis=Product.SearchProducts(Product.catalog,isElectronic);
            Console.WriteLine("--Electronics--");
            foreach (Product item in electronis)
            {
                //Console.WriteLine($"{item.Name} - {item.Price} (Stock : {item.Stock})");
                Console.WriteLine(item);

            }

            Console.WriteLine("");

            List<Product> cheaperThan50 = Product.SearchProducts(Product.catalog, isCheaperThan50);
            Console.WriteLine("--Under 50$--");

            foreach (Product item in cheaperThan50)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("");

            List<Product> stocked=Product.SearchProducts(Product.catalog, inStock);
            Console.WriteLine("--In stock--");

            foreach (Product item in stocked)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("");

            List<Product> clothesUnderOneHandared=Product.SearchProducts(Product.catalog, clothesUnder100);
            Console.WriteLine("--Clothing under 100$--");

            foreach (Product item in clothesUnderOneHandared)
            {
                if (item.Price < 100) { Console.WriteLine(item); }
                
            }

            #endregion
        }
    }
}
