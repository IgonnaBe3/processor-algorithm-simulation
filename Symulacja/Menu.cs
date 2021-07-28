using System;
using System.Collections.Generic;
using System.Threading;


namespace Symulacja
{
    class Menu
    {
        public Menu() { }
        public Algorithm ChooseAlgorithm()
        {

            int n = 0;
            Console.WriteLine("Choose the algorithm.\n1.FCFS.\n2.SJF.\n3.Priority Scheduling with Process Aging.");
            n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    return new FCFS();
                    
                case 2:
                    return new SJF();
                case 3:
                    return new Priority_Scheduling_with_Process_Aging();
                  
            }
            return new Algorithm();
        }
        public bool StartProgram()
        {
            while (true)
            {
                int n = 0;
                Console.WriteLine("1.Start.\n2.Exit.\n");
                n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        return true;
                    case 2:
                        return false;
                    default:
                        return false;
                }

            }
        }
        public void ChooseMethod(List<Process> procesy)
        {
            int n = 0;
            Console.WriteLine("Choose the input method for process statistics.\n1.Input them now.\n2.Take them from a file.\n3.Randomize them.");
            n = Convert.ToInt32(Console.ReadLine());
            switch(n)
            {
                case 1:
                    int count;
                    Console.WriteLine("Enter how many processes you want: ");
                    count = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < count; i++)
                    {
                        Process temp = new Process(0, 0, 0);
                        temp.process_number = i + 1;
                        Console.WriteLine("Enter the burst time of process number " + (i + 1));
                        temp.process_time =         Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter the arrival time of process number " + (i + 1));
                        temp.process_arrival_time = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter the priority of process number " + (i + 1));
                        temp.priority = Convert.ToInt32(Console.ReadLine());

                        procesy.Add(temp);
                    }
                    Console.WriteLine("Entered Processes:");
                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine("P" + procesy[i].process_number + " arrival time = " + procesy[i].process_arrival_time + " burst time = " + procesy[i].process_time);
                    }
                    break;
                case 2:
                    
                    string data = System.IO.File.ReadAllText("test.txt");
                    int k = 1;
                    foreach (var row in data.Split("\n"))
                    {
                        var fields = row.Split(" ");
                        int field1 = int.Parse(fields[0]);
                        int field2 = int.Parse(fields[1]);
                        int field3 = int.Parse(fields[2]);
                        Process temp = new Process(0, 0, 0);
                        temp.process_time = field1;
                        temp.process_arrival_time = field2;
                        temp.priority = field3;
                        temp.process_number = k;
                        procesy.Add(temp);
                        k++;
                    }
                    for (int j = 0; j < k-1; j++)
                    {
                        Console.WriteLine("P" + procesy[j].process_number + " arrival time = " + procesy[j].process_arrival_time + " burst time = " + procesy[j].process_time);
                    }
                    break;
                case 3:
                    Random rand = new Random();
                    int rand_count = rand.Next(1,25);
                    for(int i=0;i<rand_count;i++)
                    {
                        Process temp = new Process(0, 0, 0);
                        temp.process_time = rand.Next(1,25);
                        temp.process_arrival_time = rand.Next(0,100);
                        temp.process_number = i+1;
                        procesy.Add(temp);
                    }
                    for (int j = 0; j < procesy.Count; j++)
                    {
                        Console.WriteLine("P" + procesy[j].process_number + " arrival time = " + procesy[j].process_arrival_time + " burst time = " + procesy[j].process_time);
                    }
                    break;
            }
        }
        public void ProgramLoop()
        {
            bool program_continue = true;
            while (program_continue)
            {
                program_continue = StartProgram();
                int clock = 0;
                if (program_continue == false)
                {
                    break;
                }
                List<Process> procesy = new List<Process>();
                Algorithm algorytm = ChooseAlgorithm();
                List<int> vector = new List<int>();
                Draw whatever = new Draw();
                ChooseMethod(procesy);
                BoolWrapper continue_simulation = new BoolWrapper(true);
                while (continue_simulation.Value)
                {
                    Console.Clear();
                    vector = algorytm.Sort_Processes(procesy, clock);
                    whatever.DrawGanttDiagram(vector, procesy, clock);
                    Console.WriteLine("clock: " + clock);
                    clock++;
                    AddProcess(procesy, clock, continue_simulation);
                    Thread.Sleep(500);

                }
                whatever.DrawGanttDiagramToFile(procesy, vector);
            }
        }
        public void AddProcess(List<Process> procesy, int clock, BoolWrapper continue_simulation)
        {
            Console.WriteLine("Press any key to pause the simulation: ");
            if(Console.KeyAvailable == true)
            {
                int n = 0;
                Console.WriteLine("1.Add process.\n2.End simulation.\n3.Unpause.");
                n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Console.WriteLine("Type in the burst time of the processs you want to add: ");
                        int burst_of_added_process = Convert.ToInt32(Console.ReadLine());
                        int number_of_processes = procesy.Count;
                        procesy.Add(new Process(burst_of_added_process, clock, number_of_processes + 1));
                        break;
                    case 2:
                        continue_simulation.Value = false;
                        break;
                    case 3:
                        break;


                }
                
            }
        }

    }
}
