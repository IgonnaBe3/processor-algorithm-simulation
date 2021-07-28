

namespace Symulacja
{
    class Process
    {
        public int process_time;
        public int process_arrival_time;
        public int process_number;
        public int priority;
        public int turn_around_time;
        public int response_time;
        public int waiting_time;
        public int end_time;
        public int start_time;

        public Process(int process_time_arg, int process_arrival_time_arg, int process_number_arg)
        {
            process_time = process_time_arg;
            process_arrival_time = process_arrival_time_arg;
            process_number = process_number_arg;
        }
    }
}
