using System.Text;

namespace MiAplicacionWPF
{
    public class CalculoCoeficientesClebsh
    {
        public static string GetSelectedValuesTextBlock(int j1, int j2, int j, int m)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("| j1 j2; j m > = ∑_{m1,m2} | j1 j2; m1 m2 > < j1 j2; m1 m2 | j1 j2;j m >");

            sb.AppendLine();
            sb.Append("|").Append(j1).Append(",").Append(j2).Append("; ").Append(j).Append(",  ").Append(m).Append("> = ");

            bool firstTerm = true;
            int termCount = 0;

            // Obtener los valores de m1 y m2 que cumplan la condición m = m1 + m2
            for (int m1 = -j1; m1 <= j1; m1++)
            {
                int m2 = m - m1;

                if (m2 >= -j2 && m2 <= j2)
                {
                    if (!firstTerm)
                    {
                        sb.Append(" + ");
                    }
                    else
                    {
                        firstTerm = false;
                    }

                    sb.Append("<").Append(j1).Append(" ").Append(j2).Append(" ").Append(m1).Append(" ").Append(m2)
                      .Append("|").Append(j1).Append(",").Append(j2).Append("; ").Append(j).Append(",  ").Append(m)
                      .Append(">|").Append(j1).Append(" ").Append(j2).Append(" ").Append(m1).Append(" ").Append(m2).Append(">");

                    termCount++;

                    if (termCount % 3 == 0) // Agregar un salto de línea después de cada 3 términos
                    {
                        sb.AppendLine();
                    }
                }
            }

            return sb.ToString();
        }
    }
}