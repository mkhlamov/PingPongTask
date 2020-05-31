namespace PingPongTask.Interfaces
{
    public interface IRandomService
    {
        float Value();
        //Return a random integer number between min [inclusive] and max [exclusive] 
        int Range(int min, int max);
        string Color();
    }
}