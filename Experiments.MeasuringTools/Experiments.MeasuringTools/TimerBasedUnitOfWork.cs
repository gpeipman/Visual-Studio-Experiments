using System.Collections.Generic;
using System.Diagnostics;

namespace Experiments.MeasuringTools
{
    public class TimerBasedUnitOfWork : UnitOfWork
    {
        public override void Commit()
        {
            var stopper = new Stopwatch();

            Time = 0;
            TimeTable = new Dictionary<ICommand, long>();

            foreach (var command in Commands)
            {
                if (command.RequiresWarmupCall)
                    command.Execute();

                stopper.Reset();
                stopper.Start();
                command.Execute();
                stopper.Stop();

                TimeTable.Add(command, stopper.ElapsedMilliseconds);
                Time += stopper.ElapsedMilliseconds;
            }
        }

        public long Time { get; private set; }
        public Dictionary<ICommand, long> TimeTable { get; private set; }
    }
}
