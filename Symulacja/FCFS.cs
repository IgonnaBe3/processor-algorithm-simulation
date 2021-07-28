
using System.Collections.Generic;

namespace Symulacja
{
    class FCFS : Algorithm
    {
        public List<Process> processes;

        public override List<int> Sort_Processes(List<Process> processes_arg, int clock)
        {
            processes = processes_arg;
            processes.Sort(delegate (Process a, Process b)
            {
                if (a.process_arrival_time > b.process_arrival_time) return 1;
                else if (b.process_arrival_time > a.process_arrival_time) return -1;
                else return 0;
            }
            );
            List<int> timeline = new List<int>();
            int counter = 0;
            for (int i = 0; i < processes.Count; i++)
            {
                if ((processes[i].process_arrival_time - counter) > 0)
                {
                    for(int k=0;k<(processes[i].process_arrival_time - counter);k++)
                    {
                        timeline.Add(0);
                    }
                    counter += (processes[i].process_arrival_time - counter);
                }
                processes[i].start_time = counter;
                processes[i].waiting_time = (counter - processes[i].process_arrival_time);
                for(int j=0;j<processes[i].process_time;j++)
                {
                    timeline.Add(processes[i].process_number);
                }
                counter += processes[i].process_time;
                processes[i].end_time = counter;
                processes[i].turn_around_time = (counter - processes[i].process_arrival_time);
            }
            for(int l=0;l<(clock-counter);l++)
            {
                timeline.Add(0);
            }
            return timeline;
        }
    }
}
