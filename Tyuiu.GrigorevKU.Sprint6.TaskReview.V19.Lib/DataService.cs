using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyuiu.GrigorevKU.Sprint6.TaskReview.V19.Lib
{
    public class DataService
    {

        public int GetMatrix(int[,] mx, int r, int k, int l)
        {
            int cols = mx.GetLength(1);
            int result = 0;

            for (int i = 0; i < cols; i += 2)
            {
                if (i >= k && i <= l)
                {
                   result++;
                }
            }
            return result;
        }

        public int[,] GenerateMatrix(int n1, int n2, int n, int m)
        {
            Random rnd = new Random();
            int[,] mtrx = new int[n, m];
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (((i > 2) && ((i-1)%3==0)) || ( i == 3))
                    {
                        mtrx[i, j] = mtrx[i-3, j] - mtrx[i-2, j] - mtrx[i-1 , j];
                    }
                    else
                    {
                        mtrx[i, j] = rnd.Next(n1, n2+1);
                    }
                }
            }
            return mtrx;
        }
    }
}
