using System.Collections.Generic;

namespace Experiments.MeasuringTools
{
    public class UnitOfWork
    {
        private readonly List<ICommand> _commands = new List<ICommand>();

        public virtual void Commit()
        {
            foreach (var command in Commands)
                command.Execute();
        }

        public IList<ICommand> Commands
        {
            get { return _commands; }
        }

        public void Merge(UnitOfWork uow)
        {
            foreach (var command in uow.Commands)
                Commands.Add(command);
        }
    }
}
