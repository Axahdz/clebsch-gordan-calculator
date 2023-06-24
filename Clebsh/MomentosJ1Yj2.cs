using System.Collections.Generic;
using System.Text;

namespace MiAplicacionWPF
{
    public class MomentosJ1Yj2
    {
        public static List<int> ObtenerValoresJ1(int j1)
        {
            int negJ1 = -j1;
            List<int> valoresJ1 = new List<int>();
            for (int i = negJ1; i <= j1; i++)
            {
                valoresJ1.Add(i);
            }
            return valoresJ1;
        }

        public static List<int> ObtenerValoresJ2(int j2)
        {
            int negJ2 = -j2;
            List<int> valoresJ2 = new List<int>();
            for (int i = negJ2; i <= j2; i++)
            {
                valoresJ2.Add(i);
            }
            return valoresJ2;
        }

        public static string ObtenerValoresJ1Texto(int j1)
        {
            List<int> valoresJ1 = ObtenerValoresJ1(j1);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < valoresJ1.Count; i++)
            {
                sb.Append(valoresJ1[i]);
                if (i != valoresJ1.Count - 1)
                {
                    sb.Append(", ");
                    if ((i + 1) % 10 == 0) // Agregar un salto de línea después de cada 10 términos
                        sb.AppendLine();
                }
            }
            return "[" + sb.ToString() + "]";
        }

        public static string ObtenerValoresJ2Texto(int j2)
        {
            List<int> valoresJ2 = ObtenerValoresJ2(j2);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < valoresJ2.Count; i++)
            {
                sb.Append(valoresJ2[i]);
                if (i != valoresJ2.Count - 1)
                {
                    sb.Append(", ");
                    if ((i + 1) % 10 == 0) // Agregar un salto de línea después de cada 10 términos
                        sb.AppendLine();
                }
            }
            return "[" + sb.ToString() + "]";
        }
    }
}
