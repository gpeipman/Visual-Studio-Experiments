namespace Experiments.MeasuringTools
{
    public interface ICommand
    {
        string Title { get; set; }
        void Execute();
        bool RequiresWarmupCall { get; }
    }
}
