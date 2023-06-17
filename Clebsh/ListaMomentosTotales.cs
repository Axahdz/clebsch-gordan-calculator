
using System.Collections.Generic;
using System.Text;


public class ListaMomentosTotales
{
    public static string ValoresJ(int min, int max)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Intervalo: [jmin = {min}, jmax = {max}]");
        sb.AppendLine("Los valores posibles de j son:");

        int termCount = 0; // Contador de términos

        for (int i = min; i <= max; i++)
        {
            sb.Append(i);
            if (i != max)
            {
                sb.Append(", ");

                termCount++;
                if (termCount % 10 == 0) // Agregar un salto de línea después de cada 10 términos
                    sb.AppendLine();
            }
        }

        sb.AppendLine();

        for (int i = min; i <= max; i++)
        {
            sb.AppendLine($"Valor m para j = {i}:");
            sb.Append("[");

            int negativo = -i;
            termCount = 0; // Reiniciar el contador de términos

            for (int j = negativo; j <= i; j++)
            {
                sb.Append(j);
                if (j != i)
                {
                    sb.Append(", ");

                    termCount++;
                    if (termCount % 15 == 0) // Agregar un salto de línea después de cada 15 términos
                        sb.AppendLine();
                }
            }

            sb.Append("]\n");
        }

        return sb.ToString();
    }

    public static List<int> ObtenerValoresJ(int min, int max)
    {
        List<int> valoresJ = new List<int>();
        for (int i = min; i <= max; i++)
        {
            valoresJ.Add(i);
        }
        return valoresJ;
    }
}