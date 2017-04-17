using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads_Simulation
{
    class Program
    {
        public static int[,] flowers = new int[4, 10] { { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                              { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                              { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                              { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}  };
        static void Main(string[] args)
        {

            Thread flowersdying = new Thread(new ThreadStart(FlowerDie));
            Thread firstworking = new Thread(new ThreadStart(FirstWorker));
            Thread secondworking = new Thread(new ThreadStart(SecondWorker));


            flowersdying.Start();
            firstworking.Start();
            secondworking.Start();

        }

        public static void DrawGarden()
        {
            Console.Clear();
            for(int i=0; i<4; i++)
            {
                for (int j=0; j<10; j++)
                {
                    Console.Write(flowers[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static void FlowerDie()
        {
            while (true)
            {
                for (int i=0; i<4; i++)
                {
                    for (int j=0; j<10; j++)
                    {
                        flowers[i, j] = 0;
                    }
                }

                DrawGarden();
                Thread.Sleep(30000);
            }
        }
        public static void FirstWorker()
        {
            while (true)
            {
                int i = 0;
                for (int j=0; j < 10; j++)
                {
                    if (i == 0)
                    {
                        while (i <= 3)
                        {
                            if (flowers[i, j] == 0)
                            {
                                Interlocked.Add(ref Program.flowers[i, j], 7);
                                Thread.Sleep(1000);
                                DrawGarden();
                            }
                            i++;
                        }
                        i--;
                        continue;
                    }
                    if (i == 3)
                    {
                        while (i >= 0)
                        {
                            if (flowers[i, j] == 0)
                            {
                                Interlocked.Add(ref Program.flowers[i, j], 7);
                                Thread.Sleep(1000);
                                DrawGarden();
                            }
                            i--;
                        }
                        i++;
                        continue;
                    }
                        
                }
            }
        }
        public static void SecondWorker()
        {
            while (true)
            {
                for (int i = 3; i >= 0; i--)
                {
                    for (int j = 9; j >= 0; j--)
                    {
                        if (flowers[i, j] == 0)
                        {
                            Interlocked.Add(ref Program.flowers[i, j], 8);
                            Thread.Sleep(1000);
                        }
                    }
                }
            }
        }
        
    }
}
