using Photon.Pun;

namespace PingPongTask.Racket
{
    public class RacketMultiplayer : Racket
    {
        private PhotonView _photonView;

        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();
        }

        protected override void Move()
        {
            if (_photonView.IsMine)
            {
                base.Move();
            }
        }
    }
}