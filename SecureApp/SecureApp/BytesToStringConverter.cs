using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureApp
{
    public class BytesToStringConverter
    {
        public static void Foo()
        {
            for (int i = 0; i <= 255; i++)
            {
                string myString = Convert.ToBase64String(new byte[] { (byte)i });
                byte[] myBytes = Encoding.Unicode.GetBytes(myString);
                byte[] myFromBase64 = Convert.FromBase64String(myString);
                Console.WriteLine($"{i} → \"{myString}\" → [{string.Join(", ", myBytes)}]");
                Console.WriteLine($"             └→ [{string.Join(", ", myFromBase64)}]");
            }
            Console.ReadLine();
        }
        //Check how bytes and string converts
        
    }
}
