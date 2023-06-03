using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dissolution_of_a_solid_dosage_form
{
    class CellularAutomata
    {
        public int CurrentGeneration { get; private set;}
        public Cells[,] Field;
        private Random _random = new Random();
        double D = 5;
        public Calculation[,] Field_for_calculation;

        public double quantity = 0;
        public double difference;
        public List<int> quantityCurve = new List<int>();


            static void StartCreate(Cells[,] Field, Calculation[,] Field_for_calculation)
            {
            for (int x = 0; x < Field.GetLength(0); x++)
            {
                for (int y = 0; y < Field.GetLength(1); y++)
                {
                    Field[x, y] = new Cells();
                    Field[x, y].concentration = 0;
                    Field_for_calculation[x, y] = new Calculation();
                    Field_for_calculation[x, y].accumulation_concentration = 0;
                }
            }
            }

        public void Initialisation(int rows, int cols, int X, int Y,int MaxConc,int saturated_solution)
        {
            Field = new Cells[rows, cols];
            Field_for_calculation = new Calculation[rows, cols];

            CellularAutomata.StartCreate(Field, Field_for_calculation);

            bool intersection_with_other_tablets;
            double R = D / 2;

           
            intersection_with_other_tablets = false;

            while (!intersection_with_other_tablets)
            {
                for (int x = -(int)R; x <= +(int)R; x++)
                {
                    for (int y = -(int)R; y <= +(int)R; y++)
                    {
                        var I = (X + x + Field.GetLength(0)) % Field.GetLength(0);
                        var J = (Y + y + Field.GetLength(1)) % Field.GetLength(1);

                        if (Field[I, J].concentration >= saturated_solution)
                        {
                            intersection_with_other_tablets = true;
                            continue;
                        }
                    }
                }
                if (!intersection_with_other_tablets)
                {
                    for (int x = -(int)R; x <= +(int)R; x++)
                    {
                        for (int y = -(int)R; y <= +(int)R; y++)
                        {
                            var I = (X + x + Field.GetLength(0)) % Field.GetLength(0);
                            var J = (Y + y + Field.GetLength(1)) % Field.GetLength(1);
                           
                            Field[I, J].concentration = MaxConc;
                        }
                    }
                }
            }
        }

        public void Transition_Rule_dissolution(double k, int saturated_solution)
        {
            for (int x = 0; x < Field.GetLength(0); x++)
            {
                for (int y = 0; y < Field.GetLength(1); y++)
                {
                    if (Field[x, y].concentration >= saturated_solution)
                    {
                        double dC;

                        for (int i = -1; i <= +1; i++)
                        {
                            for (int j = -1; j <= +1; j++)
                            {
                                var I = (x + i + Field.GetLength(0)) % Field.GetLength(0);
                                var J = (y + j + Field.GetLength(1)) % Field.GetLength(1);

                                var isSelfChecking = I == x && J == y;
                                if (isSelfChecking)
                                    continue;

                                if (Field[I, J].concentration < saturated_solution)
                                {
                                    if ((I != (x - 1) & J == y) | (I == x & J != (y + 1)) | (I != (x + 1) & J == y) | (I == x & J != (y - 1)))
                                    {
                                        if (saturated_solution > Field[x, y].concentration)
                                        {
                                            dC = -k * (saturated_solution - Field[x, y].concentration);
                                        }
                                        else
                                        {
                                            dC = k;
                                        }
                                        double limitation = Field[x, y].concentration - dC;
                                        if (limitation >= 0)
                                        {
                                            Field[I, J].concentration += dC;
                                            Field[x, y].concentration -= dC;
                                            quantity += dC;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public void Transition_Rule_diffusion(double constD, int saturated_solution)
        {
            for (int x = 0; x < Field.GetLength(0); x++)
            {
                for (int y = 0; y < Field.GetLength(1); y++)
                {
                    if (Field[x, y].concentration == 0)
                        continue;

                    difference = 0;
                    double recalculation = 0;
                    if (Field[x, y].concentration < saturated_solution)
                    {
                        double dC;
                        for (int i = -1; i <= +1; i++)
                        {
                            for (int j = -1; j <= +1; j++)
                            {
                                var I = (x + i + Field.GetLength(0)) % Field.GetLength(0);
                                var J = (y + j + Field.GetLength(1)) % Field.GetLength(1);

                                var isSelfChecking = I == x && J == y;
                                if (isSelfChecking)
                                    continue;

                                if ((I != (x - 1) & J == y) | (I == x & J != (y + 1)) | (I != (x + 1) & J == y) | (I == x & J != (y - 1)))
                                {
                                    if (Field[I, J].concentration < 0)
                                        throw new Exception("Косяк с законом сохранения масс");
                                    if (Field[I, J].concentration < saturated_solution)
                                    {
                                        if (Field[I, J].concentration < Field[x, y].concentration)
                                        {
                                            dC = constD * (Field[x, y].concentration - Field[I, J].concentration);

                                            double limitation = Field[x, y].concentration - dC;

                                            if (limitation >= 0)
                                            {
                                                difference += dC;

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (Field[x, y].concentration + Field_for_calculation[x, y].accumulation_concentration - difference < 0)
                    {
                        recalculation = Field[x, y].concentration + Field_for_calculation[x, y].accumulation_concentration / difference;

                        if (Field[x, y].concentration + Field_for_calculation[x, y].accumulation_concentration < saturated_solution)
                        {

                            for (int i = -1; i <= +1; i++)
                            {
                                for (int j = -1; j <= +1; j++)
                                {
                                    var I = (x + i + Field.GetLength(0)) % Field.GetLength(0);
                                    var J = (y + j + Field.GetLength(1)) % Field.GetLength(1);

                                    var isSelfChecking = I == x && J == y;
                                    if (isSelfChecking)
                                        continue;
                                    if ((I != (x - 1) & J == y) | (I == x & J != (y + 1)) | (I != (x + 1) & J == y) | (I == x & J != (y - 1)))
                                    {
                                        if (Field[I, J].concentration < 0)
                                            //continue;
                                            throw new Exception("Косяк с законом сохранения масс");
                                        if (Field[I, J].concentration + Field_for_calculation[I, J].accumulation_concentration < saturated_solution)
                                        {
                                            if (Field[I, J].concentration + Field_for_calculation[I, J].accumulation_concentration < Field[x, y].concentration + Field_for_calculation[x, y].accumulation_concentration)
                                            {
                                                double dC = constD * (Field[x, y].concentration - Field[I, J].concentration);
                                                double remainder = dC * recalculation;

                                                Field_for_calculation[x, y].accumulation_concentration = Field_for_calculation[x, y].accumulation_concentration - remainder;
                                                Field_for_calculation[I, J].accumulation_concentration = Field_for_calculation[I, J].accumulation_concentration + remainder;
                                                quantity += remainder;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        double dC;

                        if (Field[x, y].concentration < saturated_solution)
                        {

                            for (int i = -1; i <= +1; i++)
                            {
                                for (int j = -1; j <= +1; j++)
                                {
                                    var I = (x + i + Field.GetLength(0)) % Field.GetLength(0);
                                    var J = (y + j + Field.GetLength(1)) % Field.GetLength(1);

                                    var isSelfChecking = I == x && J == y;
                                    if (isSelfChecking)
                                        continue;
                                    if ((I != (x - 1) & J == y) | (I == x & J != (y + 1)) | (I != (x + 1) & J == y) | (I == x & J != (y - 1)))
                                    {
                                        if (Field[I, J].concentration < 0)
                                            //continue;
                                            throw new Exception("Косяк с законом сохранения масс");
                                        if (Field[I, J].concentration < saturated_solution)
                                        {

                                            if (Field[I, J].concentration < Field[x, y].concentration)
                                            {
                                                dC = constD * (Field[x, y].concentration - Field[I, J].concentration);

                                                double limitation = Field[x, y].concentration - dC;

                                                if (limitation >= 0)
                                                {
                                                    Field_for_calculation[x, y].accumulation_concentration = Field_for_calculation[x, y].accumulation_concentration - dC;
                                                    Field_for_calculation[I, J].accumulation_concentration = Field_for_calculation[I, J].accumulation_concentration + dC;
                                                    quantity += dC;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }


            CurrentGeneration++;
        }
        
        public void Transformation(int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {

                    Field[i, j].concentration = Field[i, j].concentration + Field_for_calculation[i, j].accumulation_concentration;
                    Field_for_calculation[i, j].accumulation_concentration = 0;
                    if (Field[i, j].concentration < 0)
                    {
                        Field[i, j].concentration = 0;
                    }
                }
            }

        }

        
        public void Iteration_Count(ref bool no_end, int X, int Y)
        {
            bool equality = false;
            double approximate_concentration = Math.Round(Field[0, 0].concentration, 3);
            if (approximate_concentration == Math.Round(Field[X, Y].concentration, 3))
            {
                equality = true;
            }

            if (equality || CurrentGeneration >= 3000)
            {
                Console.WriteLine("The total time for the dissolution of Arogel:" + CurrentGeneration);
                no_end = false;
            }
           
        }
    }
}
