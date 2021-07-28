
using System.Collections.Generic;


namespace Symulacja
{
    class Priority_Scheduling_with_Process_Aging : Algorithm
    {
        public List<Process> processes;
        List<Process> queue = new List<Process>();
        public override List<int> Sort_Processes(List<Process> processes_arg, int clock)
        {
            processes = processes_arg;

            for (int i=0;i<processes.Count;i++)
            {
                if(clock==processes[i].process_arrival_time)
                {
                    queue.Add(processes[i]);
                }
            }
            queue.Sort(delegate (Process a, Process b)
            {
                if (a.process_arrival_time > b.process_arrival_time) return 1;
                else if (b.process_arrival_time > a.process_arrival_time) return -1;
                else if (a.priority > b.priority) return 1;
                else if (b.priority > a.priority) return -1;
                else return 0;

            }
            );
            List<int> timeline = new List<int>();
            int counter = 0;
            for (int i = 0; i < queue.Count; i++)
            {
                if ((queue[i].process_arrival_time - counter) > 0)
                {
                    for (int k = 0; k < (queue[i].process_arrival_time - counter); k++)
                    {
                        timeline.Add(0);
                    }
                    counter += (queue[i].process_arrival_time - counter);
                }
                queue[i].start_time = counter;
                queue[i].waiting_time = (counter - queue[i].process_arrival_time);
                for (int j = 0; j < queue[i].process_time; j++)
                {
                    timeline.Add(queue[i].process_number);
                }
                counter += queue[i].process_time;
                queue[i].end_time = counter;
                queue[i].turn_around_time = (counter - queue[i].process_arrival_time);
            }
            for (int l = 0; l < (clock - counter); l++)
            {
                timeline.Add(0);
            }
            for(int i=0;i<queue.Count;i++)
            {
                if(queue[i].waiting_time>0)
                {
                    if(queue[i].priority>0)
                    {
                        queue[i].priority--;
                    }
                }
            }
            return timeline;
        }
    }
}
