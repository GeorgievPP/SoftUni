namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using Core.Factories;
    using Core.Factories.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using IO;
    using IO.Contracts;
    using Models.BattleFields;
    using Models.BattleFields.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
          //  IPlayerRepository playerRepository = new PlayerRepository();
          //  IPlayerFactory playerFactory = new PlayerFactory();
          //  ICardFactory cardFactory = new CardFactory();
          //  ICardRepository cardRepository = new CardRepository();
          //  IBattleField battleField = new BattleField();

            IManagerController managerController = new ManagerController();

            IEngine engine = new Engine();

            engine.Run();
        }
    }
}