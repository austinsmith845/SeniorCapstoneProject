namespace SeniorCapstoneProject
{
    public delegate void TimerTick(int secs);
    public interface ITimeTickObserver
    {
        void RegisterTimerListener(TimerTick tick);
        void TimerHasTicked(int secs);
    }
}