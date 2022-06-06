namespace MvcMovie.EserciziLinq
{
    public class EserciziLinq
    {

        public static IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result;
                //yield non fa interompere il ciclo for, ma prende tutti i valori fino al completamento del ciclo
            }
        }

        public static void Esercizio1_yieldresult()
        {

            //IEnumerable<int> iePowerMethod = Power(2, 8);

            // Display powers of 2 up to the exponent of 8:
            foreach (int i in Power(2, 8))
            {
                Console.Write("{0} ", i);
            }
        }

        public static void Esercizio2_linq0()
        {
            // The Three Parts of a LINQ Query:
            // 1. Data source.
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            // 2. Query creation.
            // numQuery is an IEnumerable<int>
            IEnumerable<int> numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            // 3. Query execution.
            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }
            Console.WriteLine("\n");
            /*
             * MOLTO IMPORTANTE!!!!!
            In LINQ l'esecuzione della query è distinta dalla query stessa. 
            In altre parole, non sono stati recuperati dati solo creando una 
            variabile di query. Un modo per vederlo è l'esercizio che segue. 
            Se cambio numbers ma non tocco numQuery automaticamente l'esecuzione
            cambia.
           */
            numbers[0] = 32;
            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }
        }

    }
}
