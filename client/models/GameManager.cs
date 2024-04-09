using Godot;
using Mediator;
using Messages;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;

namespace GameComponents
{
    public partial class GameManager
    {
        static private GameManager instance = null!;
        public string LocalPlayerName { get; set; } = "";
        public string KeyWord { get; set; } = "";
        public int NumberOfPlayers { get; set; } = 0;
        public List<PlayerInfo> PlayersList { get; set; } = [];
        public int NumberOfTurns { get; set; } = 0;
        public bool GameState { get; set; } = false;
        public PlayerInfo CurrentPlayer { get; set; } = null!;
        public IMediator MediatorComp { get; set; } = null!;

        public void RequestConnect(string name)
        {
            ClientConnectionMessage msg = new ClientConnectionMessage(name);
            MediatorComp.Notify(this, msg);
        }

        private GameManager() {}

        static public GameManager GetInstance()
        {
            instance ??= new GameManager();
            return instance;
        }

        public void ConnectSuccess() {
            // MediatorComp.Notify(this, Mediator.Event.CONNECT_SUCCESS);
        }
        public void ConnectFail(ServerConnectionFailureMessage msg) {
            string ErrorContent = "InvalidName";
            ErrorContent = 
            msg.ErrorCode switch {
                ErrorCode.InvalidName => "InvalidName",
                ErrorCode.ServerIsFull => "ServerIsFull",
                ErrorCode.GameInProgress => "GameInProgress",
                ErrorCode.InternalServerError => "InternalServerError",
                ErrorCode.NameAlreadyTaken => "NameAlreadyTaken",
                _ => "Unknown"
            };
            
        }
        public void Ready() {
            // Send message to server
            // to start game
            // Notify mediator
            // this.Mediator.Notify(this, Event.READY);
        }
        public void Guess() {
            // Send message to server
            // to check guess
            // Notify mediator
            // this.Mediator.Notify(this, Event.GUESS);
        }
        public void TimeOut() {
            // Send message to server
            // to skip turn
            // Notify mediator
            // this.Mediator.Notify(this, Event.TIMEOUT);
        }

        internal void AddPlayer(string name)
        {
            PlayersList.Add(new PlayerInfo(name));
        }

        public void TransitionTo()
        {
        }

        public void ProcessMessage(Message msg)
        {
            // Process message from server
            // and update game state
            
        }
    }
}