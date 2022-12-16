
public interface IBossState
{
    //The 'BossBehavior boss' argument is to allow this to access all the data from the 'BossBehavior' class
    IBossState DoState(BossBehavior boss);
    
    //The return value 'IBossState' return the state for the 'BossBehavior' to do in the next frame
}
