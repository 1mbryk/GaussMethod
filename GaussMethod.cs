class GaussMethod
{
    double[][]? matrix;
    double[]? solution;
    double[]? residual;
    int size;
    public void Start()
    {
        Initialization();
        OutputMatrix();
        ToTriangular();
        OutputMatrix();
        ReverseMotion();
        if (residual == null ||
            solution == null)
            throw new("Null Value");
        Console.WriteLine("Solution: ");
        OutputSoltion("", solution);
        Console.WriteLine("Residual: ");
        OutputSoltion("d", residual);
    }
    void Initialization()
    {
        size = Convert.ToInt32(Console.ReadLine());
        solution = new double[size];
        residual = new double[size];
        if (matrix == null)
        {
            matrix = new double[size][];
            for (int i = 0; i < size; ++i)
            {
                matrix[i] = new double[size + 1];
            }
        }
        else
            throw new("Matrix is not null in initializations");

        for (int i = 0; i < size; ++i)
            for (int j = 0; j < size + 1; ++j)
                matrix[i][j] = Convert.ToDouble(Console.ReadLine());
    }
    void OutputMatrix()
    {
        if (matrix == null)
            throw new("Null Value");
        Console.WriteLine("Matrix: ");
        for (int i = 0; i < size; ++i)
        {
            for (int j = 0; j < size + 1; ++j)
            {
                if (j == size)
                    Console.Write("| ");
                if (matrix[i][j] >= 0)
                    Console.Write(" ");
                Console.Write(String.Format("{0:0.00}", matrix[i][j]) + " ");

            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    void OutputSoltion(string? prefix, double[] array)
    {
        if (solution == null)
            throw new("Null Value");
        for (int i = 0; i < size; ++i)
        {
            Console.WriteLine($"{prefix}x{(i + 1)}: " + array[i]);
        }
        Console.WriteLine();
    }
    void ToTriangular()
    {
        if (matrix == null)
            throw new("Null Value");
        double coeff = 0;
        for (int i = 0; i < size; ++i)
        {
            if (matrix[i][i] != 1 && matrix[i][i] != 0)
                RowDivide(ref matrix[i], matrix[i][i]);
            IsIndepended();

            for (int j = i + 1; j < size; ++j)
            {
                if (matrix[j][i] != 0)
                {
                    coeff = ((0 - matrix[j][i]) / matrix[i][i]);
                    matrix[j] = RowSummation(matrix[j], matrix[i], coeff);
                }
            }
        }


    }
    double[] RowSummation(double[] first_row, double[] second_row, double coeff)
    {
        for (int i = 0; i < size + 1; ++i)
        {
            first_row[i] += second_row[i] * coeff;
        }

        return first_row;
    }
    void ReverseMotion()
    {
        if (solution == null || matrix == null)
            throw new("Null Value");
        for (int i = size - 1; i >= 0; --i)
        {
            solution[i] = matrix[i][size];
            for (int j = size - 1; j > i; --j)
            {
                solution[i] -= matrix[i][j] * solution[j];
            }
        }
    }
    void CalculateResidual()
    {
        if (residual == null ||
            solution == null ||
            matrix == null)
            throw new("Null Value");
        for (int i = 0; i < size; ++i)
        {
            residual[i] = matrix[i][size];
            for (int j = 0; j < size; ++j)
            {
                residual[i] -= matrix[i][j] * solution[j];
            }
        }
    }
    void IsIndepended()
    {
        if (matrix == null)
            throw new("Null Value");

        double[] null_array = new double[size + 1];
        Array.Clear(null_array);

        for (int i = 0; i < size; ++i)
        {
            if (Enumerable.SequenceEqual(matrix[i], null_array))
                throw new Exception("System is not linear");

        }
    }
    void RowDivide(ref double[] row, double num)
    {
        for (int i = 0; i < size + 1; ++i)
            row[i] /= num;
    }
    // string.Format("{0:#.##E+0}", number1));
}