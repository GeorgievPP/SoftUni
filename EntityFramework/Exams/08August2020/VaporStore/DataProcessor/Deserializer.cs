	namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{

		private const string ErrorMessage = "Invalid Data";

		private const string SuccessfullyImportedGames
			= "Added {0} ({1}) with {2} tags";

		private const string SuccessfullyImportedUsers
			= "Imported {0} with {1} cards";


		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

			ImportGameDto[] gameDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

			List<Game> games = new List<Game>();
			List<Developer> developers = new List<Developer>();
			List<Genre> genres = new List<Genre>();
			List<Tag> tags = new List<Tag>();


			foreach(ImportGameDto gameDto in gameDtos)
            {
				if (!IsValid(gameDto))
                {
					sb.AppendLine(ErrorMessage);
					continue;
                }

				DateTime releaseDate;
				bool isReleaseDateValid = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd",
												CultureInfo.InvariantCulture, DateTimeStyles.None,
												out releaseDate);

				if (!isReleaseDateValid)
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				Game game = new Game()
				{
					Name = gameDto.Name,
					Price = gameDto.Price,
					ReleaseDate = releaseDate
                };

                Developer developer = developers
                    .FirstOrDefault(x => x.Name == gameDto.Developer);

				if (developer == null)
                {
					developer = new Developer()
					{
						Name = gameDto.Developer
					};

					developers.Add(developer);
                }

				game.Developer = developer;

				Genre genre = genres
					.FirstOrDefault(x => x.Name == gameDto.Genre);

				if (genre == null)
                {
					genre = new Genre()
					{
						Name = gameDto.Genre
					};

					genres.Add(genre);
                }

				game.Genre = genre;

				foreach(string tag in gameDto.Tags)
                {
                    if (String.IsNullOrEmpty(tag))
                    {
						continue;
                    }

					var tagOrg = tags.FirstOrDefault(x => x.Name == tag);

					if (tagOrg == null)
                    {
						tagOrg = new Tag()
						{
							Name = tag
						};

						tags.Add(tagOrg);
                    }

					GameTag gameTag = new GameTag()
					{
						Game = game,
						Tag = tagOrg
					};

					game.GameTags.Add(gameTag);

				}

				if (game.GameTags.Count == 0)
                {
					sb.AppendLine(ErrorMessage);
					continue;
                }

				games.Add(game);
				sb.AppendLine(String.Format(SuccessfullyImportedGames, game.Name, game.Genre.Name, game.GameTags.Count));

            }

			context.Games.AddRange(games);
			context.SaveChanges();

			return sb.ToString().TrimEnd();

        }

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

			List<User> users = new List<User>();

			//List<Card> cards = new List<Card>();

			foreach(ImportUserDto userDto in userDtos)
            {
				bool hasInvalidCard = false;

				if (!IsValid(userDto))
                {
					sb.AppendLine(ErrorMessage);
					continue;
                }

				User user = new User()
				{
					Username = userDto.Username,
					FullName = userDto.FullName,
					Email = userDto.Email,
					Age = userDto.Age
				};

				foreach(ImportCardDto cardDto in userDto.Cards)
                {
					string[] validTypes = new string[] { "Debit", "Credit" };

					if (!IsValid(cardDto) || validTypes.Any(t => t == cardDto.Type) == false)
                    {
						hasInvalidCard = true;
						break;
                    }


					Card card = new Card()
					{
						Cvc = cardDto.CVC,
						Number = cardDto.Number
					};

					card.Type = cardDto.Type == "Debit" ? CardType.Debit : CardType.Credit;
					user.Cards.Add(card);
                }

				if (hasInvalidCard)
                {
					sb.AppendLine(ErrorMessage);
					continue;
				}

				users.Add(user);

				sb.AppendLine(String.Format(SuccessfullyImportedUsers, user.Username, user.Cards.Count));
			}

			context.Users.AddRange(users);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			throw new NotImplementedException();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}