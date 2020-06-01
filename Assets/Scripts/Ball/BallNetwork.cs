using Photon.Pun;

namespace PingPongTask.Ball
{
    public class BallNetwork : Ball
    {
        protected override void Move()
        {
            if (!PhotonNetwork.IsMasterClient) return;
            base.Move();
        }
    }
}