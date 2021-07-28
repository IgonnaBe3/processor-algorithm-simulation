using System;
using System.Collections.Generic;


namespace Symulacja
{
    class Draw
    {
        public Draw()
        {

        }
        public void DrawGanttDiagramToFile(List<Process> processes, List<int> vector)
        {
            string text = "";
            for (int i = 0; i < processes.Count; i++)
            {
                text += "P" + (i + 1);
                for (int k = 0; k < (5 - (i + 1).ToString().Length); k++)
                {
                    text += " ";
                }
                text += ":";
                for (int j = 0; j < vector.Count; j++)
                {
                    if (vector[j] == i + 1)
                    {
                        text += "#";
                    }
                    else
                    {
                        text += " ";
                    }
                }
                text += "\n";
            }
            for (int i = 0; i < processes.Count; i++)
            {
                text +="******************" + "\n" + "process number: " + processes[i].process_number + "\n" + "process burst time: " + processes[i].process_time + "\n" + "process arrival time: " + processes[i].process_arrival_time + "\n" + "process start time: " + processes[i].start_time + "\n" + "process end time: " + processes[i].end_time + "\n" + "process waiting time: " + processes[i].waiting_time + "\n" + "process turnaround time: " + processes[i].turn_around_time + "\n" + "process priority: " + processes[i].priority +"\n";
            }
            text += "******************" + "\n";
            double average_waiting_time = 0;
            double average_turnaround_time = 0;
            for(int i=0;i<processes.Count;i++)
            {
                average_turnaround_time += processes[i].turn_around_time;
                average_waiting_time += processes[i].waiting_time;
            }
            average_waiting_time = average_waiting_time / processes.Count;
            average_turnaround_time = average_turnaround_time / processes.Count;
            text += "duration of the simulation: " + vector.Count + "\n" + "number of processes: " + processes.Count + "\n" + "average waiting time: " + average_waiting_time + "\n" + "average turnaround time: " + average_turnaround_time + "\n";
            System.IO.File.WriteAllText("raport.txt", text);
        }
        public void DrawGanttDiagram(List<int> vector, List<Process> processes, int clock)
        {
            for (int i = 0; i < processes.Count; i++)
            {
                Console.Write("P" + (i + 1));
                for(int k=0;k<(5-(i+1).ToString().Length);k++)
                {
                    Console.Write(" ");
                }
                Console.Write(":");
                for (int j = 0; j < clock; j++)
                {
                    if (vector[j] == i+1)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            for(int i = 0; i < (vector.Count + 7);i++)
            {
                Console.Write("_");
            }
            Console.WriteLine();
            for (int i = 0; i < processes.Count; i++)
            {
                Console.Write("P" + (processes[i].process_number));
                for (int k = 0; k < (5 - (processes[i].process_number).ToString().Length); k++)
                {
                    Console.Write(" ");
                }
                Console.Write(": Process arrival time: " + processes[i].process_arrival_time + " Process burst time: " + processes[i].process_time + " Process priority: " + processes[i].priority + "\n");
            }
        }
    }
}
